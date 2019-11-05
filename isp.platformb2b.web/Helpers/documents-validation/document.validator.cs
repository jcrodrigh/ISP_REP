using FluentValidation;
using isp.platformb2b.models.DTOs.documents;
using isp.platformb2b.models.entities;
using isp.platformb2b.models.UnitOfWork;
using isp.platformb2b.web.Helpers.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace isp.platformb2b.web.Helpers.documents_validation
{
    public class DocumentValidator : AbstractValidator<documentDTO>
    {
        

        //IDocumentShared _iDocService;

        private string rucJuridico = "^([1-2]{1}0)([0-9]{9})$";
        public TypeDocument _typeDocument;
        public PurcharseOrder _purcharseOrder;
        private IDocumentValidatorService _iDocService;
        private documentDTO _tempDocument;
        private Enterprise _enterpriseProvider;
        private Enterprise _enterpriseClient;

        public DocumentValidator(IDocumentValidatorService iDocService)
        {

            _iDocService = iDocService;
            _typeDocument = _iDocService.TipoDocumento();
            _tempDocument = new documentDTO();
            _purcharseOrder = _iDocService.OrdenDeCompraPorID();
            _enterpriseProvider = _iDocService.EmpresaProveedor();
            _enterpriseClient = _iDocService.EmpresaCliente();

        }
        public void _NumSerie()
        {
            
            _tempDocument.num_serie = !string.IsNullOrEmpty(_iDocService.getDocument().num_serie)?
                _iDocService.getDocument().num_serie.Trim():"";

            //aplicar la máscara
            if (_typeDocument.mascara_serie_fisica > 0 
                && _iDocService.getDocument().fis_elec
                && _typeDocument.mascara_serie_fisica > _tempDocument.num_serie.Length)
            {

                _tempDocument.num_serie = 
                        new string('0', _typeDocument.mascara_serie_fisica - _tempDocument.num_serie.Length) + _tempDocument.num_serie;

            }

            _iDocService.setMaskedDocument(_tempDocument);

            RuleFor(doc => doc.num_serie).NotEmpty()
                .When(doc=>_typeDocument.serie_requerido)
                .WithMessage("Se requiere el Número de Serie.");
            //si es documento electrónico
            RuleFor(doc => doc.num_serie).Matches(_typeDocument.formato_serie_fisica)
                .When(doc => doc.fis_elec 
                && !string.IsNullOrEmpty(doc.num_serie)
                && _typeDocument.serie_requerido
                && !_typeDocument.lista_serie)
                .WithMessage("No es una Número de serie adecuado para la un(a) " + _typeDocument.nombre_documento + " físico.");
            //si es documento físico
            RuleFor(doc => doc.num_serie).Matches(_typeDocument.formato_serie_electronica)
                .When(doc => !doc.fis_elec 
                && !string.IsNullOrEmpty(doc.num_serie)
                 && !_typeDocument.serie_requerido)
                .WithMessage("No es una Número de serie adecuado para la un(a) " + _typeDocument.nombre_documento + " Electrónico.");
            RuleFor(doc => doc.num_serie).Must(num_serie => ExistsSerialInDatabase(num_serie))
                .When(doc => _typeDocument.lista_serie)
                .WithMessage("Este intenficador no existe para el número de serie");

        }

        public void _NumCorrelativo ()
        {
            _tempDocument.num_correlativo = !string.IsNullOrEmpty(_iDocService.getDocument().num_correlativo)?
                _iDocService.getDocument().num_correlativo:"";
            if (_typeDocument.mascara_correlativo > 0 &&  _typeDocument.mascara_correlativo > _tempDocument.num_correlativo.Length)
            {

                _tempDocument.num_correlativo =
                        new string('0', _typeDocument.mascara_correlativo - _tempDocument.num_correlativo.Length) + _tempDocument.num_correlativo;

            }
            _iDocService.setMaskedDocument(_tempDocument);

            RuleFor(doc => doc.num_correlativo).NotEmpty().WithMessage("Se requiere el Número de Correlativo.");
            RuleFor(doc => doc.num_correlativo).Matches(_typeDocument.formato_correlativo)
                .When(doc => !string.IsNullOrEmpty(doc.num_correlativo))
                .WithMessage("No es una Número de correlativo adecuado para la un(a) " + _typeDocument.nombre_documento);
            //existe duplicidad con el documento?
            RuleFor(doc => doc.num_correlativo).Must(doc=> DocumentIsDuplicated())
                .When(doc => (!string.IsNullOrEmpty(doc.num_correlativo) && !string.IsNullOrEmpty(doc.num_serie)) ?
                                    (Regex.IsMatch(doc.num_correlativo, _typeDocument.formato_correlativo) &&
                                        Regex.IsMatch(doc.num_serie, 
                                                (doc.fis_elec ? 
                                                _typeDocument.formato_serie_fisica :
                                                _typeDocument.formato_serie_electronica))) : 
                               false)
                .WithMessage("El documento está duplicado.");
        }

        public void _OrdenCompra()
        {
            _tempDocument.id_orden_compra = !string.IsNullOrEmpty(_iDocService.getDocument().id_orden_compra)?
                _iDocService.getDocument().id_orden_compra:"--";
            _iDocService.setMaskedDocument(_tempDocument);

            RuleFor(doc => doc.id_orden_compra).NotNull()
                .WithMessage("Se requiere la orden de compra.");
            RuleFor(doc => doc.id_orden_compra).NotEmpty ()
                .When(doc => !string.IsNullOrEmpty(doc.id_orden_compra))
                .WithMessage("Debe especificar la orden de compra.");
            RuleFor(doc => doc.id_orden_compra).Must(id_orden_compra => PurcharseOrderCheckOrGetNull())
                .WithMessage("La orden de compra no existe.");
        }

        public void _FisEelec()
        {
            _tempDocument.fis_elec = _iDocService.getDocument().fis_elec;
            _iDocService.setMaskedDocument(_tempDocument);

            RuleFor(doc => doc.fis_elec).NotNull().WithMessage("Debe Especificar si es físico o electrónico");
        }

        public void _TipoMoneda ()
        {
            _tempDocument.id_tipo_moneda = _iDocService.getDocument().id_tipo_moneda.Trim();
            _iDocService.setMaskedDocument(_tempDocument);

            RuleFor(doc => doc.id_tipo_moneda).NotNull().WithMessage("Se requiere el tipo de moneda.");
            RuleFor(doc => doc.id_tipo_moneda).Length(3, 3)
                .When(doc => !string.IsNullOrEmpty(doc.id_tipo_moneda))
               .WithMessage("Se requiere El Tipo Documento de 3 carateres.");
            RuleFor(doc => doc.id_tipo_moneda).Must(CurrencyValid)
                .When (doc=> !string.IsNullOrEmpty(doc.id_tipo_moneda) && doc.id_tipo_moneda.Length == 3)
                .WithMessage("El tipo de moneda no está definido.");
            RuleFor(doc => doc.id_tipo_moneda).Must(id_tipo_moneda => id_tipo_moneda.Equals(_purcharseOrder.id_tipo_moneda))
                .When(doc => ((_purcharseOrder != null)?!_purcharseOrder.id_orden_compra.Equals("--"):false && _typeDocument.orden_compra_requerido))
                .WithMessage("La moneda no coincide con la orden de compra");

                

        }

        public void _RucEmpresaCliente()
        {
            _tempDocument.ruc_empresa_cliente = (!string.IsNullOrEmpty(_iDocService.getDocument().ruc_empresa_cliente) ?
                _iDocService.getDocument().ruc_empresa_cliente.Trim() : "");
            _iDocService.setMaskedDocument(_tempDocument);

            RuleFor(doc => doc.ruc_empresa_cliente).NotEmpty().WithMessage("Se requiere el Número de RUC del cliente.");
            RuleFor(doc => doc.ruc_empresa_cliente).Matches(rucJuridico)
                .When(doc => !string.IsNullOrEmpty(doc.ruc_empresa_cliente))
                .WithMessage("Se requiere el Número de RUC del cliente adecuado.");

            RuleFor(doc => doc.ruc_empresa_cliente).Must(doc => ExistsEnterpriceInDatabase())
                .When(doc => !string.IsNullOrEmpty(doc.ruc_empresa_cliente) &&
                    Regex.IsMatch(doc.ruc_empresa_cliente, rucJuridico, RegexOptions.IgnoreCase))
                .WithMessage("La empresa no existe en la base de datos.");

            RuleFor(doc => doc.ruc_empresa_cliente).Must(doc => _enterpriseClient.activo)
                .When(doc => _enterpriseClient != null)
                .WithMessage("El proveedor está inactivo en nuestra base de datos.");

            RuleFor(doc => doc.ruc_empresa_cliente).Must(doc => _enterpriseClient.habido)
                .When(doc => _enterpriseClient != null)
                .WithMessage("El proveedor está no habido por la SUNAT.");
        }

        public void _RucEmpresaProveedor ()
        {
            _tempDocument.ruc_empresa_proveedor = (!string.IsNullOrEmpty(_iDocService.getDocument().ruc_empresa_proveedor)?
                _iDocService.getDocument().ruc_empresa_proveedor.Trim():"");
            _iDocService.setMaskedDocument(_tempDocument);



            RuleFor(doc => doc.ruc_empresa_proveedor).NotEmpty().WithMessage("Se requiere el Número de RUC del proveedor.");
            RuleFor(doc => doc.ruc_empresa_proveedor).Matches(_typeDocument.formato_ruc_proveedor)
                .When(doc => !string.IsNullOrEmpty(doc.ruc_empresa_proveedor))
                .WithMessage("Se requiere el Número de RUC del proveedor adecuado.");
            //No se debe mandar a si mismo un documento que no sea chistoso :V
            RuleFor(doc => doc.ruc_empresa_cliente).Must((doc, ruc_empresa_cliente) => !doc.ruc_empresa_proveedor.Equals(ruc_empresa_cliente))
                .When(doc => !string.IsNullOrEmpty(doc.ruc_empresa_cliente) && !(string.IsNullOrEmpty(doc.ruc_empresa_proveedor)))
                .WithMessage("Se manda así mismo el documento?");

            RuleFor(doc => doc.ruc_empresa_proveedor).Must(doc => _enterpriseProvider != null)
                .When(doc => !string.IsNullOrEmpty(doc.ruc_empresa_cliente)
                        && !(string.IsNullOrEmpty(doc.ruc_empresa_proveedor))
                        && !doc.ruc_empresa_proveedor.Equals(doc.ruc_empresa_cliente))
                 .WithMessage("El proveedor no existe en nuestra base de datos");

            RuleFor(doc => doc.ruc_empresa_proveedor).Must(doc => _enterpriseProvider.activo)
                .When(doc => _enterpriseProvider != null)
                .WithMessage("El proveedor está inactivo en nuestra base de datos.");

            RuleFor(doc => doc.ruc_empresa_proveedor).Must(doc => _enterpriseProvider.habido)
                .When(doc => _enterpriseProvider != null)
                .WithMessage("El proveedor está no habido por la SUNAT.");

        }

        public void _FechaEmisión ()
        {
            _tempDocument.fecha_emision = _iDocService.getDocument().fecha_emision;
            _iDocService.setMaskedDocument(_tempDocument);

            //fecha de emisión diferente a la creada al inicio :V fecha de emisión debe ser mayor a la fecha inicio
            RuleFor(doc => doc.fecha_emision).Must(fecha_emision => fecha_emision.CompareTo(new DateTime()) != 0)
                .WithMessage("Debe ingresar una fecha de emsión.");
            RuleFor(doc => doc.fecha_emision).Must(fecha_emision => fecha_emision.CompareTo(DateTime.Today) <= 0)
                .When(doc => doc.fecha_emision.CompareTo(new DateTime()) != 0)
                .WithMessage("La fecha de emisión debe ser menor o igual al día de hoy.");
            RuleFor(doc => doc.fecha_emision)
                .Must(fecha_emision => fecha_emision.CompareTo(new DateTime(2000, 1, 1)) >= 0)
                .When(doc => doc.fecha_emision.CompareTo(new DateTime()) != 0)
                .WithMessage("La fecha debe ser mayor al año 2000.");
        }

       

        public void _TipoDocumento()
        {
            _tempDocument.id_tipo_documento = _iDocService.getDocument().id_tipo_documento;
            _iDocService.setMaskedDocument(_tempDocument);

            //tipo de documento:no nulo y tiene que tener dos caracteres :V
            RuleFor(doc => doc.id_tipo_documento).NotEmpty().WithMessage("Se requiere el Tipo de Documento.");
            RuleFor(doc => doc.id_tipo_documento).Length(2, 2)
               .When(doc => !string.IsNullOrEmpty(doc.id_tipo_documento))
               .WithMessage("Se requiere El Tipo Documento de 2 carateres.");        
        }

        /*public void _anticipo()
        {
            RuleFor(doc => doc.anticipo).GreaterThan(0).WithMessage("Debe incluir el Monto Anticipo.");
        }*/

        public void _FacturaOrigenCorrelativo()
        {
            

            _tempDocument.factura_origen_correlativo = !string.IsNullOrEmpty(_iDocService.getDocument().factura_origen_correlativo) ?
                _iDocService.getDocument().factura_origen_correlativo : "";
            if (_typeDocument.mascara_correlativo > 0 && 
                _typeDocument.mascara_correlativo > _tempDocument.factura_origen_correlativo.Length &&
                !string.IsNullOrEmpty(_tempDocument.factura_origen_correlativo))
            {

                _tempDocument.factura_origen_correlativo =
                        new string('0', _typeDocument.mascara_correlativo - _tempDocument.factura_origen_correlativo.Length) + _tempDocument.factura_origen_correlativo;

            }
            _iDocService.setMaskedDocument(_tempDocument);

            RuleFor(doc => doc.factura_origen_correlativo).NotEmpty().
                When(doc => _typeDocument.factura_origen_requerido).
                WithMessage("Se requiere la Factura Origen.");

            RuleFor(doc => doc.factura_origen_correlativo)
                .Matches( _iDocService.getTypeDocument().formato_correlativo)//E001|F[A-Z0-9]{3}|[1-9][0-9]{0,3})-
                .When(doc => !string.IsNullOrEmpty(doc.factura_origen_correlativo))
                .WithMessage("Se requiere un número de correlativo adeacudo para la factura origen.");

            RuleFor(doc => doc.factura_origen_correlativo)
                .Must(factura_origen_correlativo => !string.IsNullOrEmpty(factura_origen_correlativo))
                .When(doc => !string.IsNullOrEmpty(doc.factura_origen_serie))
                .WithMessage("Debe incluir el correlativo de la factura origen si incluye el número de serie.");

        }

        public void _FacturaOrigenSerie()
        {
            _tempDocument.factura_origen_serie = !string.IsNullOrEmpty(_iDocService.getDocument().factura_origen_serie)?
                _iDocService.getDocument().factura_origen_serie:"";
            _iDocService.setMaskedDocument(_tempDocument);

            RuleFor(doc => doc.factura_origen_serie).NotEmpty().
                When(doc => _typeDocument.factura_origen_requerido).
                WithMessage("Se requiere la Factura Origen.");

            RuleFor(doc => doc.factura_origen_serie)
                .Matches("^(E001|F[A-Z0-9]{3}|[1-9][0-9]{0,3})$")//E001|F[A-Z0-9]{3}|[1-9][0-9]{0,3})-
                .When(doc => !string.IsNullOrEmpty(doc.factura_origen_serie))
                .WithMessage("Se requiere un número de correlativo adeacudo para la factura origen.");

            RuleFor(doc => doc.factura_origen_serie)
                .Must(factura_origen_serie => !string.IsNullOrEmpty(factura_origen_serie))
                .When(doc => !string.IsNullOrEmpty(doc.factura_origen_correlativo))
                .WithMessage("Debe incluir el serie de la factura origen si incluye el número de correlativo.");
        }





        public void _MontoTotal ()
        {
            _tempDocument.monto_total = _iDocService.getDocument().monto_total;
            _iDocService.setMaskedDocument(_tempDocument);

            RuleFor(doc => doc.monto_total).GreaterThan(0)
                   .WithMessage("Se requiere un monto total.");
            RuleFor(doc => doc.monto_total)
                .Must((doc, monto_total) => doc.monto_subtotal_afecto + 
                                            doc.monto_subtotal_inafecto + 
                                            doc.monto_isc +
                                            doc.monto_igv == doc.monto_total)
                .WithMessage("El monto total no coincide con la suma de todos los subtotales.");
        }

        public void _MontoSubtotalAfecto ()
        {
            _tempDocument.monto_subtotal_afecto = _iDocService.getDocument().monto_subtotal_afecto;
            _iDocService.setMaskedDocument(_tempDocument);

            RuleFor(doc => doc.monto_subtotal_afecto).GreaterThan(0)
                .When (doc => _typeDocument.valor_venta_requerido)
                .WithMessage("Debe incluir un monto subtotal.");
        }

        public void _MontoSubtotalInafecto(Boolean required)
        {
            _tempDocument.monto_subtotal_inafecto = _iDocService.getDocument().monto_subtotal_inafecto;
            _iDocService.setMaskedDocument(_tempDocument);

            if (required)
            {
                RuleFor(doc => doc.monto_subtotal_inafecto).GreaterThan(0).WithMessage("Debe incluir un monto subtotal Inafecto.");                
            }
            else
            {
                RuleFor(doc => doc.monto_subtotal_inafecto).Must(monto => monto >(decimal)-0.01).WithMessage("Coloque un valor coherente.");
            }
        }

        public void _MontoSubtotalIgv()
        {
            _tempDocument.monto_igv = _iDocService.getDocument().monto_igv;
            _iDocService.setMaskedDocument(_tempDocument);

            RuleFor(doc=> doc.monto_igv).GreaterThan(0).
                When(doc=> doc.monto_subtotal_afecto>0).
                WithMessage("Debe incluir el monto IGV.");

            var temp = Math.Round((_tempDocument.monto_subtotal_afecto + _tempDocument.monto_isc)
                * _typeDocument.iva, 2);
            var temp2 = Math.Round(_tempDocument.monto_igv,2);

            RuleFor(doc => doc.monto_igv)
                .Must((doc,monto_igv) => Math.Round((doc.monto_subtotal_afecto + doc.monto_isc) 
                * _typeDocument.iva, 2) == Math.Round(doc.monto_igv,2))
                .When(doc => doc.monto_igv>0 && 
                                doc.monto_subtotal_afecto >0 && 
                                _iDocService.TipoDocumento().igv_calculado)
                .WithMessage("El Monto IGV que ha ingresado no es el correcto.");

        }

        public void _Ceco ()
        {
            _tempDocument.ceco = !string.IsNullOrEmpty(_iDocService.getDocument().ceco) ? _iDocService.getDocument().ceco.Trim() : "--";
            _iDocService.setMaskedDocument(_tempDocument);

            /*RuleFor(doc => doc.ceco).Must(ceco => !string.IsNullOrEmpty(ceco))
                .When(doc => doc.fis_elec && doc.id_orden_compra.Equals("--"))
                .WithMessage("Se requiere la CECO al no adjuntar la orden de compra");*/

            

            RuleFor(doc => doc.ceco).Must((doc,ceco) => doc.orden.Equals("--") ^ ceco.Equals("--"))
               .When(doc => doc.fis_elec 
                && doc.id_orden_compra.Equals("--"))
               .WithMessage("Se requiere bien el CECO o la orden.");

            RuleFor(doc => doc.ceco).Must(ceco => ceco.Equals("--"))
               .When(doc => doc.fis_elec
                && !doc.id_orden_compra.Equals("--")
               && !doc.orden.Equals("--"))
               .WithMessage("No se puede colocar CECO y Orden en un mismo documento.");
        }

        //no es orden de compraaaaa!!!!!!!!!!!!!!!!!!!!!!!!!!
        
        public void _Orden()
        {
            _tempDocument.orden = !string.IsNullOrEmpty(_iDocService.getDocument().orden)? _iDocService.getDocument().orden:"--";
            _iDocService.setMaskedDocument(_tempDocument);


            RuleFor(doc => doc.orden).Must((doc, orden) => doc.ceco.Equals("--") ^ orden.Equals("--"))
              .When(doc => doc.fis_elec
               && doc.id_orden_compra.Equals("--"))
              .WithMessage("Se requiere bien el CECO o la orden.");

            RuleFor(doc => doc.orden).Must(orden => orden.Equals("--"))
               .When(doc => doc.fis_elec
               && !doc.id_orden_compra.Equals("--")
               && !doc.ceco.Equals("--"))
               .WithMessage("No se puede colocar CECO y Orden en un mismo documento.");

            /*RuleFor(doc => doc.orden).Must(orden => !string.IsNullOrEmpty(orden))
                .When(doc => doc.fis_elec && doc.id_orden_compra.Equals("--"))
                .WithMessage("Se requiere la ORDEN al no adjuntar la orden de compra");*/

        }

        

        public void _MontoIsc()
        {
            _tempDocument.monto_isc = _iDocService.getDocument().monto_isc;
            _iDocService.setMaskedDocument(_tempDocument);

            //RuleFor(doc=> doc.monto_isc)
            RuleFor(doc => doc.monto_igv).GreaterThan((decimal)-0.01).WithMessage("Debe incluir el monto ISC Coherente.");

        }

        public void _FacturaNegociable ()
        {
            _tempDocument.factura_negociable = _iDocService.getDocument().factura_negociable;
            _iDocService.setMaskedDocument(_tempDocument);

            RuleFor(doc => doc.factura_negociable).NotNull()
                .WithMessage("Se requiere saber si la factura es Negociable o no.");
        }

        public void _detraccion ()
        {
            _tempDocument.id_tipo_detracciones = _iDocService.getDocument().id_tipo_detracciones;
            _iDocService.setMaskedDocument(_tempDocument);

            RuleFor(doc => doc.id_tipo_detracciones).NotNull()
                .WithMessage("Se requiere el tipo de Detracciones.");

            RuleFor(doc => doc.id_tipo_detracciones).Must(det => ExistsDetractionInDatabase(det))
                .When(doc => !string.IsNullOrEmpty(doc.id_tipo_detracciones)).
                WithMessage("Esa detracción no existe en nuestra base de datos");
        }

        public void _ObtenerArchivosAsociados()
        {

            _tempDocument.nombre_documento_excel = _iDocService.getDocument().nombre_documento_excel;
            _tempDocument.url_imagen = _iDocService.getDocument().url_imagen;
            _iDocService.setMaskedDocument(_tempDocument);

            /*
            if (_iDocService.getDocument().fis_elec)
            {
                
            }
            else
            {
                if (!string.IsNullOrEmpty(_iDocService.getTypeDocument().nombre_carpeta))
                {
                    string url_pdf = "/app/leerbuzoncorreo/correosdescarga/inbox/";
                    url_pdf += _iDocService.getTypeDocument().nombre_carpeta;
                    //url_pdf += 
                }
                
            }

    */
           

        }



        #region utilitarios 

        private bool PurcharseOrderCheckOrGetNull ()
        {
            return (_iDocService.OrdenDeCompraPorID() != null);
        }
        private bool CurrencyValid(string currency)
        {

            if (!_iDocService.TipoMoneda().Equals(new KeyValuePair<string, string>())) return true;
            return false;
        }

        private bool DocumentIsDuplicated()
        {
            if (_iDocService.DocumentoPorID() == null)
            {
                return true;
            }
            return false;

        }


        private bool ExistsEnterpriceInDatabase()
        {
            if (_iDocService.EmpresaCliente() != null) return true;
            return false;
        }

        public bool ExistsDetractionInDatabase(string id_tipo_detracciones)
        {
            if (_iDocService.detracciones(id_tipo_detracciones) != null) return true;
            return false;
        }

        private bool ExistsSerialInDatabase (string id_tipo_documento_serie)
        {
            return _iDocService.SerieDocumento(id_tipo_documento_serie) != null;
                
        }

        #endregion
    }
}
