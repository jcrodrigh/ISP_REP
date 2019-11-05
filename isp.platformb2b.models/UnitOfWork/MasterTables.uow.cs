using AutoMapper;
using isp.platformb2b.data;
using isp.platformb2b.data.DatabaseModels;
using isp.platformb2b.models.entities;
using isp.platformb2b.models.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
//using System.Data.Entity.Infrastructure;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace isp.platformb2b.models.UnitOfWork
{

    public interface IServiceMasterTables
    {
        IEnumerable<KeyValue> getAllTypesDocuments();
        IEnumerable<KeyValue> getAllTypesCurrency();
        TypeDocument getTypeDocumentByID(string id_document);

        List<TypeDocument> getAllTypesDocumentsComplete();
        

        KeyValuePair<string, string> GetCurrencyById(string id_tipo_moneda);

        IEnumerable<KeyValue> getAllReject();

        List<detracciones> GetAllDetractions();

        detracciones GetDetractionById(string key);

        List<SerialDocuments> GetAllDocumentSerialByTypeDocument();
        SerialDocuments GetDocumentSerialById(string id_tipo_documento,string id_tipo_documento_serie);

        TypeDocument GetTypeOfDocumentByID(string id_tipo_documento);

        Dictionary<int, string> GetTypesEnterprisesERP();
        KeyValuePair<int, string> GetTypeEnterpriseERPByID(int id_tipo_empresa_erp);

    }
    class ServiceMasterTables : IServiceMasterTables
    {

        private readonly EFDataContext _dbContext;
        private readonly IMapper _mapper;
        public ServiceMasterTables(EFDataContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<KeyValue> getAllTypesDocuments()
        {
            tipo_moneda tmo = new tipo_moneda();

            return _dbContext.tipo_documento
                .Select(kv =>
                    new KeyValue() {
                        key = kv.id_tipo_documento.ToString(),
                        value = kv.nombre_documento
                    });

        }

       

        public TypeDocument getTypeDocumentByID(string id_document)
        {
            var temp =  _dbContext.tipo_documento
                .Where(td => td.id_tipo_documento.Equals(id_document))
                .FirstOrDefault();

            TypeDocument typeDoc = new TypeDocument();

            _mapper.Map(temp, typeDoc);

            return typeDoc;
        }

        public IEnumerable<KeyValue> getAllTypesCurrency()
        {



            return _dbContext.tipo_moneda
                .Where(tm=>tm.usual)
                .Select(kv =>
                    new KeyValue()
                    {
                        key = kv.id_tipo_moneda,
                        value = kv.divisa,
                    });
        }

        public IEnumerable<KeyValue> getAllReject()
        {
            return _dbContext.tipo_documento_devolucion
                .Select(kv =>
                    new KeyValue()
                    {
                        key = kv.id_tipo_documento_devolucion.ToString(),
                        value = kv.motivo,
                    });
        }

        public List<TypeDocument> getAllTypesDocumentsComplete()
        {
            var temp =  _dbContext.tipo_documento
               .ToList();

            List<TypeDocument> typeDocs = new List<TypeDocument>();

            _mapper.Map(temp,typeDocs);

            return typeDocs;

        }
        
        public TypeDocument GetTypeOfDocumentByID(string id_tipo_documento)
        {
            var temp = _dbContext.tipo_documento.SingleOrDefault(typ => typ.id_tipo_documento.Equals(id_tipo_documento));
            var result = _mapper.Map<TypeDocument>(temp);
            return result;
        }

        public KeyValuePair<string, string> GetCurrencyById(string id_tipo_moneda)
        {
            var temp = _dbContext.tipo_moneda
                 .Select(tc => new { tc.id_tipo_moneda, tc.divisa })
                 .Where(tc => tc.id_tipo_moneda.Equals(id_tipo_moneda))
                 .AsEnumerable()
                 .Select(kv => new KeyValuePair<string, string>(kv.id_tipo_moneda, kv.divisa))
                 .SingleOrDefault();

            return temp;
        }

        

        public List<detracciones> GetAllDetractions ()
        {
            return _dbContext.tipo_detracciones.
                Select(det =>
               new detracciones
               {
                   id_tipo_detracciones = det.id_tipo_detracciones,
                   descripcion_detracciones = det.descripcion_detracciones,
                   valor_detracciones = det.valor_detracciones
               }).ToList();
        }

        public detracciones GetDetractionById(string key)
        {
            var detx = _dbContext.tipo_detracciones.
                Where (det => det.id_tipo_detracciones.Equals(key)).
                Select(det =>
               new detracciones
               {
                   id_tipo_detracciones = det.id_tipo_detracciones,
                   descripcion_detracciones = det.descripcion_detracciones,
                   valor_detracciones = det.valor_detracciones
               }).FirstOrDefault();

            if (detx == null) return null;
            if (string.IsNullOrEmpty(detx.id_tipo_detracciones)) return null;
            return detx;
        }

       

        public List<SerialDocuments> GetAllDocumentSerialByTypeDocument()
        {
            return _dbContext.tipo_documento_serie
                .Select(ser => new SerialDocuments()
                {
                    id_tipo_documento_serie    = ser.id_tipo_documento_serie,
                    id_tipo_documento = ser.id_tipo_documento,
                    descripcion = ser.descripcion
                }).ToList();
        }
        public SerialDocuments GetDocumentSerialById(string id_tipo_documento, string id_tipo_documento_serie)
        {
            var temp = _dbContext.tipo_documento_serie
                .Where(doc => doc.id_tipo_documento.Equals(id_tipo_documento)
                 && doc.id_tipo_documento_serie.Equals(id_tipo_documento_serie))
                .Select(doc => new SerialDocuments ()
                {
                    id_tipo_documento_serie = doc.id_tipo_documento_serie,
                    id_tipo_documento = doc.id_tipo_documento,
                    descripcion = doc.descripcion,
                })
                .SingleOrDefault();

            return temp;
        }

        public Dictionary<int,string> GetTypesEnterprisesERP ()
        {
            var temp = _dbContext.tipo_empresa_erp.
                ToDictionary(t => t.id_tipo_empresa_erp, t2 => t2.nombre_tipo_empresa_erp);
            return temp;
        }

        public KeyValuePair<int,string> GetTypeEnterpriseERPByID (int id_tipo_empresa_erp)
        {
            var temp = _dbContext.tipo_empresa_erp.FirstOrDefault(erp => erp.id_tipo_empresa_erp.Equals(id_tipo_empresa_erp));
            if ((temp!=null)?!string.IsNullOrEmpty(temp.nombre_tipo_empresa_erp):false)
            {
                return new KeyValuePair<int, string>(temp.id_tipo_empresa_erp, temp.nombre_tipo_empresa_erp);
            }
            return new KeyValuePair<int, string>();
        }

    }
}
