using AutoMapper;
using isp.platformb2b.data;
using isp.platformb2b.data.DatabaseModels;
using isp.platformb2b.models.DTOs.documents;
using isp.platformb2b.models.entities;
using isp.platformb2b.models.Helpers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using AutoMapper.QueryableExtensions;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Globalization;

namespace isp.platformb2b.models.UnitOfWork
{
    public interface IServiceDocument
    {
        Document InsertNewDocument(documentDTO documentDTO, string ruc_supplier, string user_supplier);
        Document getDocumentByID(string ruc_supplier, string id_type_document, string id_document);
        List<Document> GetDocumentByRucProvider(string ruc_provider);  
        Document GetDocumentByInternalId(int id_interno);
        void UpdateDcoument(Document doc);
        List<Document> DocumentsWithoutImage(string ruc_supplier);
        List<Document> GetDocumentByRucClient(string ruc_client);
        void InsertErrorDocument(documentDTO NewDocument,Dictionary<string,List<string>> errores);
        List<ErrorsByDocument> GetDocumentWithError();
        Document InsertNewDocument2(documentDTO documentDTO, string ruc_supplier);
        List<Document> DocumentWithQuery(int[] id_tipo_documento_estado,string[] ruc_empresa_cliente, string[] ruc_empresa_proveedor);
        List<Document> filtrable(DocumentFilter filter);
        //Nuevo
        List<DocumentGestion> filtrableGestion(DocumentFilter filter);

        Document ObtenerMapperDocument(documentDTO documentDTO);
        ResultMessage InsertNewDocumentMasivo(Document[] listdocument, string ruc_supplier);
    }

    public class ServiceDocument : IServiceDocument, IDisposable
    {
        private readonly EFDataContext _dbContext;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        public ServiceDocument(EFDataContext dbContext,
            IOptions<AppSettings> appSettings,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        public Document ObtenerMapperDocument(documentDTO documentDTO)
        {
           try
            {
                var new_documento = _mapper.Map<documento>(documentDTO);
                return _mapper.Map<Document>(new_documento);
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        public  Document InsertNewDocument(documentDTO documentDTO,string ruc_supplier,string user_supplier)
        {
            try
            {

                var new_documento = _mapper.Map<documento>(documentDTO);
                new_documento.usuario_modificacion = user_supplier;
                new_documento.usuario_verificacion = user_supplier;
                //_dbContext.documento.Add(new_documento);
                //var temp = _mapper.Map<Document>(new_documento);
                //_dbContext.SaveChanges();
                //var temp2 = _mapper.Map<Document>(new_documento);
                return InsertDocument(new_documento).Result;
                //return _mapper.Map<Document>(new_documento);

                
            }
            catch (Exception err)
            {
                throw err;
            }

        }


        public ResultMessage InsertNewDocumentMasivo(Document[] listdocument, string ruc_supplier)
        {
            try
            {
                Document doc = new Document();
                var new_documento = _mapper.Map<documento>(doc);
                return InsertarDocumentMasivo(listdocument,ruc_supplier);
            }
            catch (Exception err)
            {
                throw err;
            }

        }


        public void UpdateDcoument (Document doc)
        {
            using (var _context = _dbContext)
            {
                var docOld = _context.documento.FirstOrDefault(doci => doci.id_interno.Equals(doc.id_interno));
                var docx = _mapper.Map<documento>(doc);
                _dbContext.Entry(docOld).CurrentValues.SetValues(docx);
                //_dbContext.documento.Update(docx);
                _dbContext.SaveChanges();
            }
        }

        public List<Document> DocumentsWithoutImage (string ruc_supplier)
        {
            var list_docx = _dbContext.documento.
                Where(doc => (doc.ruc_empresa_proveedor.Equals(ruc_supplier) 
                        && (doc.url_imagen.Equals(new string[] { })
                        || doc.url_imagen.Length ==0)
                        ))
                .ToList();

            List<Document> docx = new List<Document>();

            _mapper.Map(list_docx, docx);

            return docx;
        }

        public Dictionary<string, List<string>> ApproveDocument (string ruc_supplier, string id_type_document, string id_document)
        {
            var document = _dbContext.documento.FirstOrDefault(doc => doc.ruc_empresa_proveedor.Equals(ruc_supplier) &&
                                                                      doc.id_tipo_documento.Equals(id_type_document) &&
                                                                      doc.id_documento.Equals(id_document));
            
            if (document != null || !string.IsNullOrEmpty(document.id_interno.ToString()))
            {
                if (document.id_tipo_documento_estado!= 1)
                {
                    var purcharseOrder = _dbContext.ordenes_compra.FirstOrDefault(po => po.id_orden_compra == document.id_orden_compra &&
                                                                                        po.ruc_empresa_cliente == document.ruc_empresa_cliente);

                    var enterpriseClient = _dbContext.empresas.FirstOrDefault(ent => ent.ruc_empresa == document.ruc_empresa_cliente);

                    var purcharseOrdertemp = Tolerance.ToleranceCalculate(purcharseOrder, enterpriseClient, document);

                    if (!purcharseOrdertemp.Equals(purcharseOrder))
                    {
                        document.id_tipo_documento_estado = 2;
                        transaccion(purcharseOrder, document);
                    }
                    else
                    {
                        return new Dictionary<string, List<string>> { { "orden_orden", new List<string> { "El documento supera." } } };
                    }

                }
                else
                {
                    return new Dictionary<string, List<string>> { { "id_tipo_documento", new List<string> { "EL documento no se puede aprobar" } } };
                }
                
                
            }
            return new Dictionary<string, List<string>> { { "id_tipo_documento", new List<string> { "El documento no se encuentra en la base de datos." } } };

        }

        
        public Document insertdocument (documentDTO newdocument)
        {


            return null;
        }

        public Document InsertNewDocument2(documentDTO documentDTO, string ruc_supplier)
        {
            try
            {

                using (var context = _dbContext)
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var new_documento = _mapper.Map<documento>(documentDTO);
                        new_documento.usuario_modificacion = ruc_supplier;
                        _dbContext.documento.Add(new_documento);
                        _dbContext.SaveChanges();
                        return _mapper.Map<Document>(new_documento);
                    }
                }

                        

                
            }
            catch (Exception err)
            {
                throw err;
            }

        }



        public void RejectDocument(string ruc_supplier, string id_type_document, string id_document)
        {
            using (var context = _dbContext)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var document = context.documento.FirstOrDefault(doc => doc.ruc_empresa_proveedor.Equals(ruc_supplier) &&
                                                                          doc.id_tipo_documento.Equals(id_type_document) &&
                                                                          doc.id_documento.Equals(id_document));
                    if (document != null)
                    {
                        var anterior = new { id_tipo_documento_estado = document.id_tipo_documento_estado };
                        var nuevo = new { id_tipo_documento_estado = 3 };

                        document.id_tipo_documento_estado = 3;
                        context.documento.Update(document);

                        
                        _dbContext.SaveChanges();
                    }
                }
            }
        }
            
        public Document GetDocumentByInternalId (int id_interno)
        {
            var docx = _dbContext.documento.FirstOrDefault(doc => doc.id_interno == id_interno);
            if (docx == null) return null;
            if (string.IsNullOrEmpty(docx.ruc_empresa_proveedor)) return null;



            Document docr = new Document();

            _mapper.Map(docx, docr);

            return docr;
            
        }
        private void transaccion (OrdenesCompra oc, documento doc )
        {
            using (var context = _dbContext)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        _dbContext.ordenes_compra.Update(oc);                        
                        context.SaveChanges();
                        _dbContext.documento.Update(doc);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        public Document getDocumentByID(string ruc_supplier, string id_type_document,string id_document)
        {
            

            var document = from doc in _dbContext.documento
                                 where (doc.ruc_empresa_proveedor == ruc_supplier
                                        && doc.id_documento == id_document
                                        && doc.id_tipo_documento == id_type_document)
                                 select doc;

            var temp = document.ToList();
            if (temp.Count() == 0) return null;

            return  _mapper.Map<Document> (temp[0]);
        }

       



        public List<Document> GetDocumentByRucProvider(string ruc_provider)
        {
            var list_docx = _dbContext.documento.
                Where(doc => doc.ruc_empresa_proveedor.Equals(ruc_provider))                
                .ToList();
            List<Document> docx = new List<Document>();

            _mapper.Map(list_docx, docx);

            return docx;
        }


        public List<Document> GetDocumentByRucClient(string ruc_client)
        {
            using (var context = _dbContext)
            {
                return context.documento.
                ProjectTo<Document>(_mapper.ConfigurationProvider).
                Where(doc => doc.ruc_empresa_cliente.Equals(ruc_client))                
                .ToList();
            }

            
        }
       
       
        
        


        public void InsertErrorDocument(documentDTO NewDocument, Dictionary<string, List<string>> errores)
        {
            var empresaCliente = _dbContext.empresas.Where(ent => ent.ruc_empresa.Equals(NewDocument.ruc_empresa_cliente)).FirstOrDefault();
            var empresaProveedor = _dbContext.empresas.Where(ent => ent.ruc_empresa.Equals(NewDocument.ruc_empresa_proveedor)).FirstOrDefault();

            string razon_social_cliente = (empresaCliente != null) ? empresaCliente.razon_social : "--";
            string razon_social_proveedor = (empresaProveedor != null) ? empresaProveedor.razon_social : "--";

            ErrorsByDocument doc = new ErrorsByDocument()
            {
                razon_social_cliente = razon_social_cliente,
                razon_social_proveedor = razon_social_proveedor,
                documento = NewDocument,
                errores = errores,
                //correos = empresaProveedor.correo,
            };

            
            var docx = _mapper.Map<documento_errores>(doc);
            _dbContext.documento_errores.Add(docx);
            _dbContext.SaveChanges();

           

            /*
            string output = JsonConvert.SerializeObject(NewDocument);

            string erroresx = JsonConvert.SerializeObject(errores);

            Document deserializedProduct = JsonConvert.DeserializeObject<Document>(output);

            Dictionary<string, List<string>> mecmec = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(erroresx);

            var temp = "a";

            var tempx = output.Length;
            */

        }

        public List<ErrorsByDocument> GetDocumentWithError ()
        {
            var tempDoc = _dbContext.documento_errores.ToList();

            var query = from err in _dbContext.documento_errores
                        join cli in _dbContext.empresas on err.ruc_empresa_cliente equals cli.ruc_empresa
                        join pro in _dbContext.empresas on err.ruc_empresa_proveedor equals pro.ruc_empresa
                        
                        select new ErrorsByDocument
                        {
                           correos = pro.correo,
                           documento = JsonConvert.DeserializeObject<documentDTO>(err.documento),
                           errores = JsonConvert.DeserializeObject<Dictionary<string,List<string>>>(err.errores),
                           fecha_emision = err.fecha_emision,
                           id_documento_errores = err.id_documento_errores,
                           id_tipo_documento = err.id_tipo_documento,
                           num_correlativo = err.num_correlativo,
                           ruc_empresa_cliente = err.ruc_empresa_cliente,
                           num_serie = err.num_serie,
                           razon_social_proveedor = pro.razon_social,
                           razon_social_cliente = cli.razon_social,
                           ruc_empresa_proveedor = err.ruc_empresa_proveedor,
                           ultima_modificacion = err.ultima_modificacion,
                           usuario_modificacion = err.usuario_modificacion,
                        };
            var temp = query.ToList();
            /*List<ErrorsByDocument> errorx = new List<ErrorsByDocument>();

            _mapper.Map(tempDoc, errorx);*/

            return temp;


        }

        private ResultMessage InsertarDocumentMasivo(Document[] listdocumento,string ruc_supplier)
        {
            ResultMessage resultado = new ResultMessage();

            using (var context = _dbContext)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var doc in listdocumento)
                        {

                            var new_documento = _mapper.Map<documento>(doc);
                            new_documento.usuario_modificacion = ruc_supplier;

                                context.documento.Add(new_documento);
                                //context.SaveChangesAsync();

                            OrdenesCompra purcharseOrder = context.ordenes_compra.
                                Where(po => po.id_orden_compra == new_documento.id_orden_compra &&
                                po.ruc_empresa_cliente == new_documento.ruc_empresa_cliente).
                            FirstOrDefault();

                            //throw new Exception();

                            if ((purcharseOrder != null) ? !purcharseOrder.id_orden_compra.Equals("--") : false)
                            {
                                var empresa = context.empresas.FirstOrDefault(ent => ent.ruc_empresa.Equals(purcharseOrder.ruc_empresa_cliente));
                                purcharseOrder = Tolerance.ToleranceCalculate(purcharseOrder, empresa, new_documento);
                                //context.SaveChangesAsync();
                            }

                        }

                        context.SaveChanges();
                        transaction.Commit();
                        resultado.code = 0;
                        resultado.message = "";

                    }
                    catch (Exception err)
                    {
                        transaction.Rollback();
                        resultado.code = 1;
                        resultado.message = err.ToString();
                        throw err;
                    }
                    finally
                    {
                        transaction.Dispose();
                    }

                }

            }


            return resultado;
        }

        private async  Task<Document> InsertDocument(documento new_documento)
        {
            using (var transaction = _dbContext.Database.CurrentTransaction ?? _dbContext.Database.BeginTransaction())
            {
                try
                {
                    int last_id = _dbContext.documento.Max(doc => doc.id_interno);
                    new_documento.id_interno = last_id + 1;
                    _dbContext.documento.Add(new_documento);
                    await _dbContext.SaveChangesAsync();
                    // Insert a row
                    OrdenesCompra purcharseOrder = _dbContext.ordenes_compra.
                                Where(po => po.id_orden_compra == new_documento.id_orden_compra &&
                                    po.ruc_empresa_cliente == new_documento.ruc_empresa_cliente).
                                FirstOrDefault();

                    //throw new Exception();

                    if ((purcharseOrder != null) ? !purcharseOrder.id_orden_compra.Equals("--") : false)
                    {
                        var empresa = _dbContext.empresas.FirstOrDefault(ent => ent.ruc_empresa.Equals(purcharseOrder.ruc_empresa_cliente));
                        purcharseOrder = Tolerance.ToleranceCalculate(purcharseOrder, empresa, new_documento);
                        await _dbContext.SaveChangesAsync();
                    }
                    
                    transaction.Commit();
                    return _mapper.Map<Document>(new_documento);
                }
                catch (Exception err)
                {
                    transaction.Rollback();
                    throw err;                    
                }
                finally
                {
                    transaction.Dispose();
                }
               
            }

            //OrdenesCompra purcharseOrder = _dbContext.ordenes_compra.
            //    Where(po => po.id_orden_compra == new_documento.id_orden_compra &&
            //        po.ruc_empresa_cliente == new_documento.ruc_empresa_cliente).
            //    FirstOrDefault();
            /*PurcharseOrder pox = _mapper.Map<PurcharseOrder>(purcharseOrder);
            OrdenesCompra purcharseOrdernew = _mapper.Map<OrdenesCompra>(pox);*/
            //var purcharseOrdernew = new OrdenesCompra();
            /*if ((purcharseOrder != null) ? !purcharseOrder.id_orden_compra.Equals("--") : false)
            {
                var empresa = _dbContext.empresas.FirstOrDefault(ent => ent.ruc_empresa.Equals(purcharseOrder.ruc_empresa_cliente));

                purcharseOrdernew.monto_acumulado = 455879;
                var tenp = "klkss";
                //purcharseOrdernew = Tolerance.ToleranceCalculate(purcharseOrder, empresa, new_documento);
                var temp = AuditoriaHelper.OrdenDeCompraAuditorias(purcharseOrder, purcharseOrdernew);
            }*/

            /*
            using (var context = _dbContext)
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        //documento nuevo 
                        _dbContext.documento.Add(new_documento);

                        await _dbContext.SaveChangesAsync();

                        OrdenesCompra purcharseOrder = _dbContext.ordenes_compra.
                            Where(po => po.id_orden_compra == new_documento.id_orden_compra &&
                                po.ruc_empresa_cliente == new_documento.ruc_empresa_cliente).
                            FirstOrDefault();

                        if ((purcharseOrder != null) ? !purcharseOrder.id_orden_compra.Equals("--") : false)
                        {
                            var empresa = _dbContext.empresas.FirstOrDefault(ent => ent.ruc_empresa.Equals(purcharseOrder.ruc_empresa_cliente));
                            purcharseOrder = Tolerance.ToleranceCalculate(purcharseOrder, empresa, new_documento);
                            await _dbContext.SaveChangesAsync();
                        }

                        var document = _mapper.Map<documento>(new_documento);


                        transaction.Commit();
                    }
                    catch (Exception err)
                    {
                        transaction.Rollback();
                        throw err;
                    }
                    finally
                    {
                        transaction.Dispose();
                        context.Dispose();
                        //transaction.Commit();
                    }
                }
            }*/
        }

        private PurcharseOrder getPurcharseOrderByID(string ruc_client, string purcharse_order_code)
        {
            purcharse_order_code = (string.IsNullOrEmpty(purcharse_order_code)) ? "--" : purcharse_order_code;
            IQueryable<OrdenesCompra> query = from ord in _dbContext.ordenes_compra
                                              where (ord.ruc_empresa_cliente == ruc_client &&
                                                     ord.id_orden_compra == purcharse_order_code)
                                              select ord;
            var temp = query.ToList();
            if (temp == null || temp.Count() == 0)
            {

                return null;

            }

            return _mapper.Map<PurcharseOrder>(temp[0]);
        }


        public List<Document> DocumentWithQuery(int[] id_tipo_documento_estado, string[] ruc_empresa_cliente ,string [] ruc_empresa_proveedor)
        {
            /*var query = _dbContext.documento.AsQueryable();
            var pred = PredicateBuilder.New<documento>(true);
            if (id_tipo_documento_estado.Length != 0)
                pred = pred.And(doc => id_tipo_documento_estado.Contains(doc.id_tipo_documento_estado));*/



            using (var context = _dbContext)
            {

                var query = context.documento.AsQueryable();
                if (id_tipo_documento_estado.Length != 0)
                    query = query.Where(doc => id_tipo_documento_estado.Contains(doc.id_tipo_documento_estado));
                if (ruc_empresa_cliente.Length!=0)
                    query = query.Where(doc => ruc_empresa_cliente.Contains(doc.ruc_empresa_cliente));
                if (ruc_empresa_proveedor.Length != 0)
                    query = query.Where(doc => ruc_empresa_proveedor.Contains(doc.ruc_empresa_proveedor));

                return query.AsQueryable().
                ProjectTo<Document>(_mapper.ConfigurationProvider)
                .OrderByDescending(d => d.ultima_modificacion)
                .ToList();
            }

        }

        public List<Document> filtrable (DocumentFilter filter)
        {
            using (var context = _dbContext)
            {

                var query = context.documento.AsQueryable();
                if (filter.id_tipo_documento_estado.Length != 0 && filter.id_tipo_documento_estado!=null)
                    query = query.Where(doc => filter.id_tipo_documento_estado.Contains(doc.id_tipo_documento_estado));
                if (filter.ruc_empresa_cliente.Length != 0 && filter.ruc_empresa_cliente != new string[] { })
                    query = query.Where(doc => filter.ruc_empresa_cliente.Contains(doc.ruc_empresa_cliente));
                if (filter.ruc_empresa_proveedor.Length != 0 && filter.ruc_empresa_cliente != new string[] { })
                    query = query.Where(doc => filter.ruc_empresa_proveedor.Contains(doc.ruc_empresa_proveedor));
                if (filter?.fecha_emision_inferior != DateTime.MinValue && filter?.fecha_emision_inferior != null)
                    query = query.Where(doc => filter.fecha_emision_inferior <= doc.fecha_verificacion);
                if (filter?.fecha_emision_superior != DateTime.MinValue && filter?.fecha_emision_superior != null)
                    query = query.Where(doc => filter.fecha_emision_superior.Value.AddDays(1) > doc.fecha_verificacion);

                if (filter?.fecha_recepcion != DateTime.MinValue && filter?.fecha_recepcion != null)
                    query = query.Where(doc => filter.fecha_recepcion == doc.ultima_modificacion);

                if (filter.fis_elec.Length != 0 &&  filter?.fis_elec != null)
                    query = query.Where(doc => filter.fis_elec.Contains(doc.fis_elec));


                return query.AsQueryable().
                ProjectTo<Document>(_mapper.ConfigurationProvider)
                .OrderByDescending(d => d.ultima_modificacion)
                .ToList();
            }
        }



        public List<DocumentGestion> filtrableGestion(DocumentFilter filter)
        {
            using (var context = _dbContext)
            {

                var result = from a in context.documento
                             join b in context.tipo_documento on a.id_tipo_documento equals b.id_tipo_documento
                             join c in context.empresas on a.ruc_empresa_cliente equals c.ruc_empresa  //cliente
                             join d in context.empresas on a.ruc_empresa_proveedor equals d.ruc_empresa  //proveedor
                             join e in context.tipo_documento_estado on a.id_tipo_documento_estado equals e.id_tipo_documento_estado // documento estado
                             select new DocumentGestion
                             {
                                 id_interno = a.id_interno,
                                 ruc_empresa_proveedor = a.ruc_empresa_proveedor,
                                 razon_social_proveedor = d.razon_social,
                                 id_documento = a.id_documento,
                                 id_tipo_documento = a.id_tipo_documento,
                                 id_tipo_documento_estado = a.id_tipo_documento_estado,
                                 id_tipo_moneda = a.id_tipo_moneda,
                                 fecha_emision = a.fecha_emision,
                                 fis_elec = a.fis_elec,
                                 monto_subtotal_afecto = a.monto_subtotal_afecto,
                                 monto_subtotal_inafecto = a.monto_subtotal_inafecto,
                                 monto_isc = a.monto_isc,
                                 monto_igv = a.monto_igv,
                                 monto_total = a.monto_total,
                                 ruc_empresa_cliente = a.ruc_empresa_cliente,
                                 razon_social_cliente = c.razon_social,
                                 id_orden_compra = a.id_orden_compra,
                                 id_tipo_detracciones = a.id_tipo_detracciones,
                                 factura_negociable = a.factura_negociable,
                                 ceco = a.ceco,
                                 ultima_modificacion = a.ultima_modificacion,
                                 usuario_modificacion = a.usuario_modificacion,
                                 url_imagen = a.url_imagen,
                                 nombre_documento_excel = a.nombre_documento_excel,
                                 id_tipo_documento_devolucion = a.id_tipo_documento_devolucion,
                                 num_serie = a.num_serie,
                                 num_correlativo = a.num_correlativo,
                                 factura_origen_correlativo = a.factura_origen_correlativo,
                                 factura_origen_serie = a.factura_origen_serie,
                                 orden = a.orden,
                                 nombre_documento = b.nombre_documento,
                                 iva = b.iva,
                                 fecha_verificacion = a.fecha_verificacion,
                                 usuario_verificacion = a.usuario_verificacion,
                                 hora_verificacion = a.fecha_verificacion.ToString("HH:mm:ss", CultureInfo.InvariantCulture),
                                 fecha_transferencia =(a.fecha_transferencia.HasValue)? (DateTime?)a.fecha_transferencia.Value:null,
                                 tipo_documento_estado = e.estado,
                                 nro_conformidad_oc = a.nro_conformidad_oc,
                                 acreedor = d.acreedor,


                             };

                

                if (filter.id_tipo_documento_estado.Length != 0 && filter.id_tipo_documento_estado != null)
                    result = result.Where(doc => filter.id_tipo_documento_estado.Contains(doc.id_tipo_documento_estado));
                if (filter.ruc_empresa_cliente.Length != 0 && filter.ruc_empresa_cliente != new string[] { })
                    result = result.Where(doc => filter.ruc_empresa_cliente.Contains(doc.ruc_empresa_cliente));
                if (filter.ruc_empresa_proveedor.Length != 0 && filter.ruc_empresa_cliente != new string[] { })
                    result = result.Where(doc => filter.ruc_empresa_proveedor.Contains(doc.ruc_empresa_proveedor));
                if (filter?.fecha_emision_inferior != DateTime.MinValue && filter?.fecha_emision_inferior != null)
                    result = result.Where(doc => filter.fecha_emision_inferior.Value.Date <= doc.fecha_verificacion);
                if (filter?.fecha_emision_superior != DateTime.MinValue && filter?.fecha_emision_superior != null)
                    result = result.Where(doc => filter.fecha_emision_superior.Value.Date.AddDays(1) > doc.fecha_verificacion);

                if (filter.fis_elec.Length != 0 && filter?.fis_elec != null)
                    result = result.Where(doc => filter.fis_elec.Contains(doc.fis_elec));

                return result.ToList();
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            
            //throw new NotImplementedException();
        }
    }
}