using isp.platformb2b.models.DTOs.documents;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace isp.platformb2b.models.entities
{
    public class Document
    {
        public int id_interno { get; set; }
        public string ruc_empresa_proveedor { get; set; }

        public string razon_social_proveedor { get; set; }
        public string id_documento { get; set; }
        public string id_tipo_documento { get; set; }
        public int id_tipo_documento_estado { get; set; }
        public string id_tipo_moneda { get; set; }
        public DateTime fecha_emision { get; set; }
        
        public Boolean fis_elec { get; set; }
        
        public decimal monto_subtotal_afecto { get; set; }
        public decimal monto_subtotal_inafecto { get; set; }
        public decimal monto_isc { get; set; }
        public decimal monto_igv { get; set; }
        public decimal monto_total { get; set; }
        public string ruc_empresa_cliente { get; set; }
        public string razon_social_cliente { get; set; }
        public string id_orden_compra { get; set; }
        public string id_tipo_detracciones { get; set; }
        public Boolean? factura_negociable { get; set; }
        
        public string ceco { get; set; }
        public DateTime ultima_modificacion { get; set; }
        public string usuario_modificacion { get; set; }
        public string[] url_imagen { get; set; }

        public string nombre_documento_excel { get; set; }
        public int id_tipo_documento_devolucion { get; set; }

        public string num_serie { get; set; }

       
        public string num_correlativo { get; set; }


        public string factura_origen { get; set; }

        public string factura_origen_serie { get; set; }
        public string factura_origen_correlativo { get; set; }

        public DateTime fecha_verificacion { get; set; }
        public string hora_verificacion { get; set; }
        public string usuario_verificacion { get; set; }

        public DateTime? fecha_transferencia { get; set; }

        public string orden { get; set; }

       
    }


    public class DocumentGestion
    {
        
        public string ruc_empresa_proveedor { get; set; }
        public string id_tipo_documento { get; set; }
        public string id_documento { get; set; }
        public int id_interno { get; set; }
        public string num_serie { get; set; }
        public string num_correlativo { get; set; }
        public Boolean fis_elec { get; set; }
        public string ruc_empresa_cliente { get; set; }
        public string id_orden_compra { get; set; }
        public string id_tipo_moneda { get; set; }
        public decimal monto_subtotal_afecto { get; set; }
        public decimal monto_subtotal_inafecto { get; set; }
        public decimal monto_igv { get; set; }
        public decimal monto_isc { get; set; }
        public decimal monto_total { get; set; }
        public int id_tipo_documento_estado { get; set; }
        public DateTime fecha_emision { get; set; }
        public string id_tipo_detracciones { get; set; }
        public Boolean? factura_negociable { get; set; }
        public string ceco { get; set; }
        public DateTime ultima_modificacion { get; set; }
        public string usuario_modificacion { get; set; }
        public string[] url_imagen { get; set; }
        public int id_tipo_documento_devolucion { get; set; }
        public string factura_origen_serie { get; set; }
        public string nombre_documento_excel { get; set; }
        public string orden { get; set; }


        public DateTime fecha_contabilizacion { get; set; }
        public string nro_registro_contable { get; set; }
        public string nro_conformidad_oc { get; set; }


        public string factura_origen_correlativo { get; set; }
        public string razon_social_proveedor { get; set; }
        public string razon_social_cliente { get; set; }

        public DateTime fecha_verificacion { get; set; }
        public string hora_verificacion { get; set; }
        public string usuario_verificacion { get; set; }

        public DateTime? fecha_transferencia { get; set; }
        //public string usuario_transferencia { get; set; }


        //nuevos campos
        public string nombre_documento { get; set;}
        public decimal iva { get; set; }
        public string tipo_documento_estado { get; set; }


        public string acreedor { get; set; }

    }

    public class TypeDocument
    {

        public string id_tipo_documento { get; set; }
        public string nombre_documento { get; set; }
        public string formato_serie_fisica { get; set; }
        public string formato_serie_electronica { get; set; }
        public string formato_correlativo { get; set; }
        public string formato_ruc_proveedor { get; set; }
        public decimal iva { get; set; }
        public string nombre_iva { get; set; }
        public string nombre_afecto { get; set; }
        public string nombre_inafecto { get; set; }
        public int mascara_correlativo { get; set; }
        public int mascara_serie_fisica { get; set; }
        public Boolean orden_compra_requerido { get; set; }

        public string formato_factura_origen_serie { get; set; }

        public Boolean serie_requerido { get; set; }

        public Boolean lista_serie { get; set; }

        public Boolean valor_venta_requerido { get; set; }

        public Boolean factura_origen { get; set; }

        public Boolean factura_origen_requerido { get; set; }

        public Boolean monto_isc { get; set; }
        
        public Boolean detraccion { get; set; }

        public Boolean factura_negociable { get; set; }

        public Boolean igv_calculado { get; set; }

        public string nombre_carpeta { get; set; }
    }

    public class DocumentFilter
    {
        public string[]  ruc_empresa_cliente { get; set; }
        public int[] id_tipo_documento_estado { get; set; }
        public string[] ruc_empresa_proveedor { get; set; }
        public DateTime? fecha_emision_inferior { get; set; }
        public DateTime? fecha_emision_superior { get; set; }
        public DateTime? fecha_recepcion { get; set; }
        public Boolean[] fis_elec { get; set; }
    }

    public class FileDocument 
    {
        public string nombre_file { get; set; }
        public string content_type { get; set; } 
        public String data { get; set; }
    }



    public class ErrorsByDocument
    {
        public int id_documento_errores { get; set; }
        public string id_tipo_documento { get; set; }
        public documentDTO documento { get; set; }        
        public Dictionary<string,List<string>> errores { get; set; }
        public DateTime ultima_modificacion { get; set; }
        public string usuario_modificacion { get; set; }
        public string num_serie { get; set; }

        
        public string num_correlativo { get; set; }

        #region Proveedor
        public string ruc_empresa_proveedor { get; set; }
        public string razon_social_proveedor { get; set; }
        public string[] correos { get; set; }

        #endregion

        #region cliente

      
        public string ruc_empresa_cliente { get; set; }

        
        public string razon_social_cliente { get; set; }

        #endregion 

      
        public DateTime fecha_emision { get; set; }

    }


}
