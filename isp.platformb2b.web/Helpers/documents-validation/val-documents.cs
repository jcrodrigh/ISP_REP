using FluentValidation;
using FluentValidation.Results;
using isp.platformb2b.models.DTOs.documents;
using isp.platformb2b.models.entities;
using isp.platformb2b.models.Helpers;
using isp.platformb2b.models.UnitOfWork;
using isp.platformb2b.web.Helpers.Services;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace isp.platformb2b.web.Helpers.documents_validation
{
    public class ValDocuments
    {
        
        protected Dictionary<string, List<string>> _dictError;
        protected DocumentValidator _validationRules;        

        protected Enterprise _enterpriseClient;
        protected Enterprise _enterpriseProvider;

        protected PurcharseOrder po;

        IDocumentValidatorService _IDocValService;

        public ValDocuments(IDocumentValidatorService iDocService)
        {

            _IDocValService = iDocService;
            _IDocValService.ResetAllValues();
            _validationRules = new DocumentValidator(_IDocValService);
            _dictError = new Dictionary<string, List<string>>();

        }

        protected Dictionary<string, List<string>> GetError(AbstractValidator<documentDTO> validator)
        {
            
            ValidationResult results = validator.Validate(_IDocValService.getMaskedDocument());
            if (results.IsValid)
            {
                return null;
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                return convertErrorList(failures);
            }

        }

        public void resetError()
        {
            _dictError = new Dictionary<string, List<string>>();
        }


        public Dictionary<string, List<string>> verificador()
        {
            _validationRules._TipoDocumento();

            var tempType = _IDocValService.TipoDocumento();

            if (tempType != null)
            {
                {
                    var _ = _validationRules;
                    _._NumSerie();
                    _._NumCorrelativo();
                    _._FechaEmisión();
                    _._TipoMoneda();
                    _._MontoTotal();
                    _._RucEmpresaProveedor();
                    _._RucEmpresaCliente();
                    _._FisEelec();
                    //_._OrdenCompra();
                    _._ObtenerArchivosAsociados();
                    _._MontoSubtotalAfecto();
                    //_._Orden();
                    //_._Ceco();
                }

                // Si el valor venta no es requerido, entonces
                // los valores inafectos e igv no se requieren :V 
                if (!tempType.valor_venta_requerido)
                {
                    {
                        var _ = _validationRules;
                        _._MontoSubtotalIgv();
                        _._MontoSubtotalInafecto(false);
                    }
                }

                //requiere el monto isc?
                if (tempType.monto_isc) { _validationRules._MontoIsc(); }

                //Se requiere la factura negociable?
                if (tempType.factura_negociable) { _validationRules._FacturaNegociable(); }

                //Se requiere la detracción?
                if (tempType.detraccion) { _validationRules._detraccion(); }

                //va a tener factura origen?
                if (tempType.factura_origen)
                {
                    {
                        var _ = _validationRules;
                        _._FacturaOrigenCorrelativo();
                        _._FacturaOrigenSerie();
                    }
                }

                if (_validationRules._typeDocument.orden_compra_requerido)
                {
                    {
                        var _ = _validationRules;
                        _._OrdenCompra();
                        _._Orden();
                        _._Ceco();
                    }
                }




            }
            else
            {            
                {
                    var _ = _validationRules;
                    _._TipoDocumento();
                }                
            }


            /*
             
            if (!string.IsNullOrEmpty(_IDocValService.getDocument().id_tipo_documento))
            {
                {
                    var _ = _validationRules;
                    _._NumSerie();
                    _._NumCorrelativo();
                    _._FechaEmisión();
                    _._TipoMoneda();
                    _._MontoTotal();
                    _._RucEmpresaProveedor();
                    _._RucEmpresaCliente();
                    _._FisEelec();
                    //_._OrdenCompra();
                    _._ObtenerArchivosAsociados();
                    //_._Orden();
                    //_._Ceco();
                }
            }
            */


            /*
            switch (_IDocValService.getDocument().id_tipo_documento)
            {
                case "00":
                    {
                        var _ = _validationRules;
                       
                    }
                    break;
                case "01":
                    {
                        var _ = _validationRules;
                        //_._MontoSubtotalAfecto();
                        //_._MontoSubtotalInafecto(false);
                        _._MontoIsc();
                        //_._MontoSubtotalIgv();
                        _._FacturaNegociable();
                        _._detraccion();

                    }
                    break;
                case "02":
                    {
                        var _ = _validationRules;
                        //_._MontoSubtotalAfecto();
                    }
                    break;
                case "03":
                    {
                        var _ = _validationRules;
                        //_._MontoSubtotalAfecto();
                    }
                    break;
                case "05":
                    {
                        var _ = _validationRules;
                        //_._MontoSubtotalAfecto();
                        //_._MontoSubtotalInafecto(false);
                        //_._MontoSubtotalIgv();
                    }
                    break;
                case "07"://07 - Nota de crédito

                    {
                        var _ = _validationRules;
                        _._FacturaOrigenSerie();
                        _._FacturaOrigenCorrelativo();
                        //_._MontoSubtotalAfecto();
                        //_._MontoSubtotalInafecto(false);
                        //_._MontoSubtotalIgv();
                        _._MontoIsc();
                                                
                    }
                    break;
                case "08":
                    {
                        var _ = _validationRules;
                        //_._MontoSubtotalAfecto();
                        //_._MontoSubtotalInafecto(false);
                        //_._MontoSubtotalIgv();
                        _._MontoIsc();
                        //_._FacturaOrigenSerie();
                        //_._FacturaOrigenCorrelativo();
                    }
                    break;
                case "10": //10 – Recibo de Arrendamiento
                    {
                        var _ = _validationRules;

                        //_._MontoSubtotalAfecto();
                        
                    }
                    break;
                case "12"://12 - Ticket o cinta emitido por máquina registradora

                    {
                        var _ = _validationRules;
                        //_._MontoSubtotalAfecto();
                        //_._MontoSubtotalInafecto(false);
                        //_._MontoSubtotalIgv();
                    }
                    break;
                case "13"://13 - Documento emitido por bancos, instituciones financieras, crediticias y de seguros que se encuentren bajo el control de la Superintendencia de Banca y Seguros

                    {
                        var _ = _validationRules;
                        //_._MontoSubtotalAfecto();                        
                        //_._MontoSubtotalIgv();
                    }
                    break;
                case "14"://14 - Recibo por servicios públicos de suministro de energía eléctrica, agua, teléfono, telex y telegráficos y otros servicios complementarios que se incluyan en el recibo de servicio público

                    {
                        var _ = _validationRules;
                        //_._MontoSubtotalAfecto();
                        //_._MontoSubtotalIgv();
                    }
                    break;
                case "50"://50 - Declaración Única de Aduanas - Importación definitiva          

                    {
                        var _ = _validationRules;
                        //_._MontoSubtotalAfecto();
                        _._MontoIsc();
                        //_._MontoSubtotalIgv();
                    }
                    break;
                case "91": //91 - Comprobante de No Domiciliado                                                 
                    {
                        var _ = _validationRules;
                        //_._FacturaOrigenSerie();
                        //_._FacturaOrigenCorrelativo();
                        //_._MontoSubtotalAfecto();
                        //_._FacturaOrigenSerie();
                        //_._FacturaOrigenCorrelativo();

                    }
                    break;
                case "97"://97 - Nota de Crédito - No Domiciliado                                            
                    {
                        var _ = _validationRules;
                        _._FacturaOrigenSerie();
                        _._FacturaOrigenCorrelativo();
                        //_._MontoSubtotalAfecto();
                        

                    }
                    break;
                //case "AS":
                    //{
                    //    var _ = _validationRules;
                    //    _._Cuenta();
                    //}
                    //break;
                case "ER":
                    {
                        var _ = _validationRules;
                        
                        
                        _._anticipo();
                        
                    }
                    break;
                default:
                    {
                        var _ = _validationRules;
                        _._TipoDocumento();
                    }
                    break;
            }
        */
            

            var docMasked = _IDocValService.getMaskedDocument();

            _dictError = GetError(_validationRules);

            //primera validación
             if (_dictError != null) return _dictError;
            resetError();


            bool RelationClientProvider = _IDocValService.relacionEntreClienteYProveedor();
            if (RelationClientProvider)
            {
                if (_IDocValService.TipoDocumento().orden_compra_requerido)
                {
                    //segunda validación
                    //match with the purcharse orden 
                    _dictError = continuacion();
                    if ( _dictError.Count > 0) return _dictError;

                    //tercera validacion la tolerancia
                    if (!CalculateTolerance())
                        InsertErrorIntoDiccionary(ref _dictError, "monto_subtotal_afecto", $"El monto sobrepasa a la tolerancia definida por el cliente.");
                }
                else
                {
                    //si esl documento no lo requiere simplemente se guarda la orden de compra cero 
                    
                    var temp = _IDocValService.getMaskedDocument();
                    temp.id_orden_compra = "--";
                    _IDocValService.setMaskedDocument(temp);
                }
            }
            else
            {
                InsertErrorIntoDiccionary(ref _dictError, "ruc_empresa_cliente", $"Usted no tiene permisos de realizar una subida de datos a ese cliente.");
                return _dictError;
            }

            return _dictError;

            /*
            _enterpriseClient = _IDocValService.EmpresaCliente();

            bool RelationClientProvider = _IDocValService.relacionEntreClienteYProveedor();


            /*
            if (RelationClientProvider)
            {
                //Tercero: Preguntamos si existe la orden de compra                    
                po = null;
                if (string.IsNullOrEmpty(_IDocValService.getDocument().id_orden_compra)) _IDocValService.getDocument().id_orden_compra = "--";
                //tercero - primero:
                //si la id de la orden de compra es "--" signfica que el proveedor no 
                //ha adjuntado la orden de compra :V
                if (_IDocValService.getDocument().id_orden_compra.Equals("--"))
                {
                    //cuarto - primero: preguntamos si el cliente permite que se le adjunten facturas nulas
                    po = _IDocValService.OrdenDeCompraNulaSiElClienteLoPermite();
                    if (po != null)
                    {
                       
                        return _dictError;
                    }
                    else
                    {
                        InsertErrorIntoDiccionary(ref _dictError, "id_orden_compra", $"El cliente exige una orden de compra.");
                        return _dictError;
                    }

                }
                //tercero - segundo:
                //El cliente exige la orden de compra
                else
                {
                    po = _IDocValService.OrdenDeCompraPorID();
                    //cuarto - segundo: Existe esa orden de compra?
                    if (po != null)
                    {
                        //quinto: calcular si los montos son correctos: :V
                        
                        return _dictError;
                    }
                    else
                    {
                        InsertErrorIntoDiccionary(ref _dictError, "id_orden_compra", $"La orden de compra no existe.");
                        return _dictError;
                    }
                }
            }
            else
            {
                InsertErrorIntoDiccionary(ref _dictError, "ruc_empresa_cliente", $"Usted no tiene permisos de realizar una subida de datos a ese cliente.");
                return _dictError;
            }*/
            //return GetError(_validationRules);
        }


        private Dictionary<string, List<string>>  continuacion ()
        {
            Dictionary<string, List<string>> _dictError = new Dictionary<string, List<string>>();
            var entClient = _IDocValService.EmpresaCliente();
            var po = _IDocValService.OrdenDeCompraPorID();

            if (po!= null)
            {
                if (po.id_orden_compra.Equals("--"))
                {
                    if (entClient.con_pedido && !entClient.sin_pedido)
                    {
                        InsertErrorIntoDiccionary(ref _dictError, "id_orden_compra", "EL cliente exige la orden de compra");
                    }
                }
                else
                {
                    if (!po.ruc_empresa_proveedor.Equals(_IDocValService.EmpresaProveedor().ruc_empresa))
                    {
                        InsertErrorIntoDiccionary(ref _dictError, "id_orden_compra", "Usted no tiene permisos para subir en esta orden de compra.");
                    }
                }
               
            }
            else
            {
                InsertErrorIntoDiccionary(ref _dictError,"id_orden_compra", "La orden de compra no existe.");
                
            }
            return _dictError;
        }

        private bool CalculateTolerance()
        {

            if (_IDocValService.OrdenDeCompraPorID().id_orden_compra.Equals("--")) return true;
            /*decimal max;
            decimal min;*/
            decimal monto_orden = _IDocValService.OrdenDeCompraPorID().monto_orden_compra;
            decimal monto_acumulado = _IDocValService.OrdenDeCompraPorID().monto_acumulado;
            decimal total_venta = _IDocValService.getMaskedDocument().monto_subtotal_afecto +
                 _IDocValService.getMaskedDocument().monto_subtotal_inafecto;
            /*
             if (_enterpriseClient.tipo_tolerancia == 1)
            {
                max = _IDocValService.getDocument().monto_total * (_enterpriseClient.tolerancia+1);
                min = _IDocValService.getDocument().monto_total * (-_enterpriseClient.tolerancia + 1);

                if (monto_orden <= max && monto_orden >= min) return true;
                

             }
             else if (_enterpriseClient.tipo_tolerancia == 2)
             {
                max = _IDocValService.getDocument().monto_total + _enterpriseClient.tolerancia ;
                min = _IDocValService.getDocument().monto_total - _enterpriseClient.tolerancia;
                if (monto_orden <= max && monto_orden >= min) return true;
            }
             */
            if (_IDocValService.EmpresaCliente().tipo_tolerancia == 1)
            {
                //max = _IDocValService.getDocument().monto_total * (_enterpriseClient.tolerancia+1);
                monto_orden = monto_orden *
                    (_IDocValService.EmpresaCliente().tolerancia + 1);
                //min = _IDocValService.getDocument().monto_total * (-_enterpriseClient.tolerancia + 1);

                //if (monto_orden <= max && monto_orden >= min) return true;


            }
             else if (_IDocValService.EmpresaCliente().tolerancia == 2)
             {
                monto_orden = monto_orden +
                    _IDocValService.EmpresaCliente().tolerancia;
                //max = _IDocValService.getDocument().monto_total + _enterpriseClient.tolerancia ;
                //min = _IDocValService.getDocument().monto_total - _enterpriseClient.tolerancia;
                //if (monto_orden <= max && monto_orden >= min) return true;
            }

            if (monto_orden >= total_venta + monto_acumulado) return true;
            return false;


        }

      

        #region some methods

        private Dictionary<string, List<string>> convertErrorList(IList<ValidationFailure> failures)
        {
            foreach (var error in failures)
                InsertErrorIntoDiccionary(ref _dictError, error.PropertyName, error.ErrorMessage);
            return _dictError;
        }

        protected void InsertErrorIntoDiccionary(ref Dictionary<string, List<string>> DictErrores, string key, string value)
        {
            if (!DictErrores.ContainsKey(key))
                DictErrores[key] = new List<string>();
            DictErrores[key].Add(value);

            return;
        }

        #endregion


        

     

        
        



        


    }
}
