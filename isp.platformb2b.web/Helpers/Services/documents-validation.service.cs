using isp.platformb2b.models.DTOs.documents;
using isp.platformb2b.models.entities;
using isp.platformb2b.models.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace isp.platformb2b.web.Helpers.Services
{
    public interface IDocumentValidatorService
    {
        documentDTO getDocument();
        void setDocument(documentDTO _documentDTO);
        void setMaskedDocument(documentDTO newDocumentDTO);
        documentDTO getMaskedDocument();
        TypeDocument getTypeDocument();
        void ResetAllValues();
        documentDTO EmptyDocument();
        Enterprise EmpresaProveedor();
        Enterprise EmpresaCliente();
        TypeDocument TipoDocumento();
        Boolean relacionEntreClienteYProveedor();
        KeyValuePair<string, string> TipoMoneda();
        Document DocumentoPorID();
        PurcharseOrder OrdenDeCompraNulaSiElClienteLoPermite();
        PurcharseOrder OrdenDeCompraPorID();
        detracciones detracciones(string id);
        SerialDocuments SerieDocumento(string id_tipo_documento_serie);
    }
    public class DocumentValidatorService: IDocumentValidatorService
    {
        private IServiceDocument _iserviceDocument;
        private IServicePurcharseOrder _iservicePurcharseOrder;
        private IServiceMasterTables _iServiceMasterTables;
        private IServiceEnterprise _iServiceEnterprise;

        private documentDTO _documentDTO;
        private documentDTO _maskedDocumentDTO;
        private PurcharseOrder _purcharseOrder;
        private Enterprise _enterpriseClient;
        private Enterprise _enterpriseProvider;
        private TypeDocument _typeDocument;

        public DocumentValidatorService (IServiceDocument iserviceDocument,
            IServicePurcharseOrder iservicePurcharseOrder,
            IServiceMasterTables iServiceMasterTables,
                IServiceEnterprise iServiceEnterprise)
        {
            _iserviceDocument = iserviceDocument;
            _iservicePurcharseOrder = iservicePurcharseOrder;
            _iServiceMasterTables = iServiceMasterTables;
            _iServiceEnterprise = iServiceEnterprise;


            setMaskedDocument(EmptyDocument());

        }

        public documentDTO getDocument()
        {
            return _documentDTO;
        }

        public void setDocument(documentDTO newDocumentDTO)
        {
            this._documentDTO = newDocumentDTO;
        }

        public void setMaskedDocument(documentDTO newDocumentDTO)
        {
            this._maskedDocumentDTO = newDocumentDTO;
        }

        public documentDTO getMaskedDocument()
        {
            return  _maskedDocumentDTO;
        }

        public TypeDocument getTypeDocument()
        {
            if (_typeDocument != null) return _typeDocument;
            _typeDocument = _iServiceMasterTables.getTypeDocumentByID(_documentDTO.id_tipo_documento);
            return _typeDocument;
        }

        public void ResetAllValues()
        {
            _typeDocument = null;            
            _maskedDocumentDTO = null;
            _purcharseOrder = null;
            _enterpriseClient = null;
            _enterpriseProvider = null;
        
    }

        public Enterprise EmpresaCliente()
        {
            if (_enterpriseClient != null) return _enterpriseClient;
            _enterpriseClient = _iServiceEnterprise.getEnterpriseById(_documentDTO.ruc_empresa_cliente);
            return _enterpriseClient;
        }

        public Enterprise EmpresaProveedor()
        {
            if (_enterpriseProvider != null) return _enterpriseProvider;
            _enterpriseProvider = _iServiceEnterprise.getEnterpriseById(_documentDTO.ruc_empresa_proveedor);
            return _enterpriseProvider;
        }

        public TypeDocument TipoDocumento()
        {
            if (this._typeDocument != null) return _typeDocument;
            _typeDocument =  _iServiceMasterTables.getTypeDocumentByID(this._documentDTO.id_tipo_documento);
            return _typeDocument;
        }

        public Boolean relacionEntreClienteYProveedor()
        {
            return _iServiceEnterprise
                    .getIfExistRelationBetweenClientAndProvider(
                        _documentDTO.ruc_empresa_cliente.Trim(),
                        _documentDTO.ruc_empresa_proveedor);
        }

        public KeyValuePair<string, string> TipoMoneda()

        {
            return _iServiceMasterTables.GetCurrencyById(_documentDTO.id_tipo_moneda);
        }


        public Document DocumentoPorID()
        {
            return _iserviceDocument.getDocumentByID(_maskedDocumentDTO.ruc_empresa_proveedor,
                 _documentDTO.id_tipo_documento,
                 _maskedDocumentDTO.num_serie + "-" + _maskedDocumentDTO.num_correlativo);
        }

        public PurcharseOrder OrdenDeCompraNulaSiElClienteLoPermite()
        {
            return _iservicePurcharseOrder.GetPurcharseOrderNullIfClientAllowsIt(_documentDTO.ruc_empresa_cliente);
        }

        public PurcharseOrder OrdenDeCompraPorID()
        {
            if (_purcharseOrder != null) return _purcharseOrder;

            _purcharseOrder =  _iservicePurcharseOrder.GetPurcharseOrderIfNotExistReturnNull(
                                _documentDTO.ruc_empresa_cliente,
                               _documentDTO.id_orden_compra);
            return _purcharseOrder;
        }

        public detracciones detracciones (string id)
        {
            return _iServiceMasterTables.GetDetractionById(id);
        }

        public SerialDocuments SerieDocumento (string id_tipo_documento_serie)
        {
            return _iServiceMasterTables.GetDocumentSerialById(_typeDocument.id_tipo_documento, id_tipo_documento_serie);
        }

        public documentDTO EmptyDocument()
        {
            return new documentDTO()
            {
                ruc_empresa_cliente = "",
                ruc_empresa_proveedor = "",                
                num_correlativo = "",
                num_serie = "",
                id_tipo_documento = "",
                id_orden_compra = null,
                id_tipo_detracciones = null,
                id_tipo_moneda = null,
                monto_igv = 0,
                monto_isc = 0,
                monto_subtotal_afecto = 0,
                monto_subtotal_inafecto = 0,
                monto_total = 0,
                
                ceco = null,
                orden = null,

                
                factura_negociable = null,
                factura_origen_correlativo = null,
                factura_origen_serie = null,
                fecha_emision = new DateTime(),
                
                fis_elec = true,                
                
                url_imagen= new string[] { },

                
                nombre_documento_excel = null,
                


            };
        }

        
    }
}
