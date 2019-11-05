using isp.platformb2b.models.DTOs;
using isp.platformb2b.models.entities;
using isp.platformb2b.models.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using isp.platformb2b.models.DTOs.documents;

namespace isp.platformb2b.web.Helpers
{
    public  class Verify
    {
        private readonly IServiceDocument _iserviceDocument;
        private readonly IServicePurcharseOrder _iservicePurcharseOrder;
        private readonly IServiceMasterTables _iServiceMasterTables;
        private readonly IServiceEnterprise _iServiceEnterprice;

        List<TypeDocument> _typeDocs;
        decimal _igv;


        public Verify(
            IServiceDocument iserviceDocument,
            IServicePurcharseOrder iservicePurcharseOrder,
            IServiceMasterTables iServiceMasterTables,
                IServiceEnterprise iServiceEnterprise)
        {
            _iserviceDocument = iserviceDocument;
            _iservicePurcharseOrder = iservicePurcharseOrder;
            _iServiceMasterTables = iServiceMasterTables;
            _iServiceEnterprice = iServiceEnterprise;

            
        }

        
        public void verify_document(documentDTO new_document, ref Dictionary<string,List<string>> errorx)
        {
            // ########################################################################################################
            //                                  logica de negocio 0
            // ########################################################################################################
            //                      Primera verificación :V [decorator Data Anotation]
            
            var context = new ValidationContext(new_document);
            var results = new List<ValidationResult>();
            

            //new_document.ruc_empresa_cliente = null;

            if (DateTime.Compare(new_document.fecha_emision, new DateTime())==0)
            {
                InsertErrorIntoDiccionary(ref errorx, nameof(new_document.fecha_emision), "Debe Insertar una fecha de Emisión");
            }

            var temp= Validator.TryValidateObject(new_document, context, results, true);

            foreach (ValidationResult vr in results)
            {
                InsertErrorIntoDiccionary(ref errorx, vr.MemberNames.First(), vr.ErrorMessage);
                
            }

            // ########################################################################################################
            //                                  logica de negocio 1
            // ########################################################################################################
            //                      verificar todo lo relacionado al tipo de documento

            //el tipo de documento 
            TypeDocument typeDoc = _typeDocs.Find(t => t.id_tipo_documento.Equals(new_document.id_tipo_documento)); 
            if (typeDoc != null)
            {
                //hay que identificar si es físico o electrónico 
                string formatSerial = (new_document.fis_elec) ? typeDoc.formato_serie_fisica : typeDoc.formato_serie_electronica;

                //valuamos las expresiones regulares del número de serie y el correlativo 
                var matchSerial = Regex.Match(new_document.num_serie, formatSerial, RegexOptions.IgnoreCase);
                var matchCorrelative = Regex.Match(new_document.num_correlativo, typeDoc.formato_correlativo, RegexOptions.IgnoreCase);

                //si no cumplen con el formato, lo insertamos en el diccionario :V
                if (matchSerial.Success)
                {
                    if(matchCorrelative.Success)
                    {
                        if (_iserviceDocument.getDocumentByID(new_document.ruc_empresa_proveedor, new_document.id_tipo_documento, new_document.num_serie + "-" + new_document.num_correlativo) != null)
                            InsertErrorIntoDiccionary(ref errorx,nameof(new_document.num_correlativo), $"Existe duplicidad con este correlativo.");
                    }
                    else
                    {
                        InsertErrorIntoDiccionary(ref errorx, nameof(new_document.num_correlativo), $"El Formato no cumple para el número correlativo.");
                    }

                }
                else
                {
                    InsertErrorIntoDiccionary(ref errorx, nameof(new_document.num_serie), $"El Formato no cumple para el número serial.");
                    if (!matchCorrelative.Success) InsertErrorIntoDiccionary(ref errorx, nameof(new_document.num_correlativo), $"El Formato no cumple para el número correlativo.");
                }
                

            }
            else
            {
                InsertErrorIntoDiccionary(ref errorx, nameof(new_document.id_tipo_documento), $"No existe ese tipo de documento.");
                return;
            }
            //duplicidad en los documentos 
           
            

            // ########################################################################################################
            //                                  logica de negocio 2
            // ########################################################################################################
            //                              Todo lo relacionado a los permisos 


            // Primero: preguntamos si la empresa cliente existe
            Enterprise enterprise_client = _iServiceEnterprice.getIfTheEnterpriseIsClient(new_document.ruc_empresa_cliente.Trim());

            if (enterprise_client != null)
            {
                //segundo: preguntamos si existe la relacion entre el cliente y el proveedor
                Boolean RelationClientProvider = _iServiceEnterprice
                    .getIfExistRelationBetweenClientAndProvider(
                        new_document.ruc_empresa_cliente.Trim(), 
                        new_document.ruc_empresa_proveedor);

                if (RelationClientProvider)
                {
                    //Tercero: Preguntamos si existe la orden de compra                    
                    PurcharseOrder po = null;

                    //tercero - primero:
                    //si la id de la orden de compra es "--" signfica que el proveedor no 
                    //ha adjuntado la orden de compra :V
                    if (new_document.id_orden_compra.Equals("--"))
                    {
                        //cuarto - primero: preguntamos si el cliente permite que se le adjunten facturas nulas
                        po = _iservicePurcharseOrder.GetPurcharseOrderNullIfClientAllowsIt(new_document.ruc_empresa_cliente);
                        if (po != null)
                        {
                            //quinto: calcular si los montos son correctos: :V
                            calculateAmounts(ref errorx, new_document, enterprise_client);
                            return;
                        }
                        else
                        {
                            InsertErrorIntoDiccionary(ref errorx, nameof(new_document.id_orden_compra), $"El cliente exige una orden de compra.");
                            return;
                        }

                    }
                    //tercero - segundo:
                    //El cliente exige la orden de compra
                    else
                    {
                        po = _iservicePurcharseOrder.GetPurcharseOrderIfNotExistReturnNull(
                                    new_document.ruc_empresa_cliente,
                                    new_document.id_orden_compra);
                        //cuarto - segundo: Existe esa orden de compra?
                        if (po!= null)
                        {
                            //quinto: calcular si los montos son correctos: :V
                            calculateAmounts(ref errorx, new_document, enterprise_client);
                            return;
                        }
                        else
                        {
                            InsertErrorIntoDiccionary(ref errorx, nameof(new_document.id_orden_compra), $"La orden de compra no existe.");
                            return;
                        }
                    }
                }
                else
                {
                    InsertErrorIntoDiccionary(ref errorx, nameof(new_document.ruc_empresa_cliente), $"Usted no tiene permisos de realizar una subida de datos a ese cliente.");
                    return;
                }
            }
            else
            {
                InsertErrorIntoDiccionary(ref errorx, nameof(new_document.ruc_empresa_cliente), $"No existe ese RUC de empresa cliente.");
                return;
            }


            
            

            


        }

        private  void InsertErrorIntoDiccionary ( ref Dictionary<string, List<string>> DictErrores, string key, string value)
        {
            if (!DictErrores.ContainsKey(key))
                DictErrores[key] = new List<string>();
            DictErrores[key].Add(value);

            return;
        }

        private void calculateAmounts (ref Dictionary<string, List<string>> DictErrores,documentDTO new_document, Enterprise enterprise_client)
        {
            decimal subtotal_afecto = new_document.monto_subtotal_afecto;
            decimal subtotal_inafecto = new_document.monto_subtotal_inafecto;
            decimal igv = new_document.monto_igv;
            decimal total = new_document.monto_total;

            //primero: el igv es del 18%?
            if (igv == Math.Round(subtotal_afecto * _igv, 2))
            {
                //segundo: el monto total es la suma de todos los subtotales incluyendo el IGV?
                if (total == subtotal_afecto + subtotal_inafecto + igv)
                {
                    
                    return;
                }
                else
                {
                    InsertErrorIntoDiccionary(ref DictErrores, nameof(new_document.monto_total), $"El monto Total está mal calculado.");
                    return;
                }
            }
            else
            {
                InsertErrorIntoDiccionary(ref DictErrores, nameof(new_document.monto_igv), $"El IGV está mal calculado.");
                return;
            }
            
        }

    }
}
