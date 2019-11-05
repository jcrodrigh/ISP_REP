using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace isp.platformb2b.data.DatabaseModels
{
    public class tipo_documento
    {
        public tipo_documento()
        {
            formato_ruc_proveedor = "^20[0-9]{9}$";
            formato_serie_electronica = "^([A-Za-z0-9]{0,20})$";
            formato_serie_fisica = "^([A-Za-z0-9]{0,20})$";
            formato_correlativo = "^([1-9][0-9]{0,19})$";
            iva = (decimal)0.18;
            nombre_iva = "Monto IGV";
            nombre_afecto = "Valor Venta";
            
            orden_compra_requerido = false;
            serie_requerido = true;
            lista_serie = false;
            valor_venta_requerido = false;
            igv_calculado = true;
            nombre_carpeta = "";
        }

        [Key]
        [Column(TypeName = "char(2)")]
        [Display(Name = "Identificador tipo documento")]
        public string id_tipo_documento { get; set; }

        [Required]
        [Column(TypeName = "varchar(300)")]
        [Display(Name = "Tipo Documento")]
        public string nombre_documento { get; set; }

        [Required]
        [Column(TypeName = "numeric(4,3)")]
        [Display(Name = "Iva del documento")]
        public decimal iva { get; set; }

        [Column(TypeName = "varchar(400)")]
        [Display(Name = "Nombre del impuesto.")]
        public string nombre_iva { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        [Display(Name = "formato regex del numero de serie fisico del tipo de documento :v")]
        public string formato_serie_fisica { get; set; }

        [Column(TypeName = "smallint")]
        [Display(Name = "Máscara del formato serie físico")]
        public int mascara_serie_fisica { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        [Display(Name = "formato regex del numero de serie electrónico del tipo de documento :v")]
        public string formato_serie_electronica { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        [Display(Name = "formato regex del correlativo del tipo de documento :v")]
        public string formato_correlativo { get; set; }

        [Column(TypeName = "smallint")]
        [Display(Name = "Máscara del correlativo")]
        public int mascara_correlativo { get; set; }

        [Required]
        [Column(TypeName = "varchar(40)")]
        [Display(Name = "formato del ruc del proveedor (natrual- juridico)")]
        public string formato_ruc_proveedor { get; set; }

        [Required]
        [Column(TypeName = "boolean")]
        [Display(Name = "Requiere o no la orden de compra :V")]
        public Boolean orden_compra_requerido {get; set; }

        
        [Column(TypeName = "varchar(400)")]
        [Display(Name = "Nombre Afecto.")]
        public string nombre_afecto { get; set; }

        [Column(TypeName = "varchar(800)")]
        [Display(Name = "Formato Factura Origen Serie")]
        public string formato_factura_origen_serie { get; set; }

        [Column(TypeName = "boolean")]
        [Display(Name = "Serie requerido")]
        public Boolean serie_requerido { get; set; }

        [Column(TypeName = "boolean")]
        [Display(Name = "lista Serie requerido")]
        public Boolean lista_serie { get; set; }

        [Column(TypeName = "boolean")]
        [Display(Name = "Valor venta requerido")]
        public Boolean valor_venta_requerido { get; set; }

        

        [Column(TypeName = "boolean")]
        [Display(Name = "Valor venta requerido")]
        public Boolean factura_origen { get; set; }

        [Column(TypeName = "boolean")]
        [Display(Name = "Valor venta requerido")]
        public Boolean factura_origen_requerido { get; set; }

        [Column(TypeName = "boolean")]
        [Display(Name = "Valor venta requerido")]
        public Boolean monto_isc { get; set; }

        [Column(TypeName = "boolean")]
        [Display(Name = "detraccion requerido")]
        public Boolean detraccion { get; set; }

        [Column(TypeName = "boolean")]
        [Display(Name = "factura negociable requerido")]
        public Boolean factura_negociable { get; set; }

        [Column(TypeName = "boolean")]
        [Display(Name = "se va a calcular el IGV")]
        public Boolean igv_calculado { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "se va a calcular el IGV")]
        public string nombre_carpeta { get; set; }

    }
}
