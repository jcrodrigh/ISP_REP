using System;
using System.ComponentModel;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace isp.platformb2b.data.DatabaseModels
{
    public class documento
    { 
        public documento()
        {
            monto_isc = 0;
            id_tipo_documento_estado = 1;
            ultima_modificacion = DateTime.Now;
            fecha_verificacion = DateTime.Now;
            usuario_verificacion = "";
            factura_negociable = null;
        }

        #region relativo a la identificación del documento :V

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_interno { get; set; }

        [Key]
        [Column(Order = 0, TypeName = "char(11)")]
        [ForeignKey("proveedor")]
        [Display(Name = "RUC Empresa Cliente")]
        public string ruc_empresa_proveedor { get; set; }

        [Key]
        [Required]
        [Column(TypeName = "char(2)")]
        [ForeignKey("tipo_documento")]
        [Display(Name = "Identificador tipo documento")]
        public string id_tipo_documento { get; set; }

        [Key]
        [Required]
        [Column(TypeName = "varchar(60)")]
        [Display(Name = "Número de la factura")]
        public string id_documento { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        [Display(Name = "Número de serie la factura")]
        public string num_serie { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        [Display(Name = "Número de serie la factura")]
        public string num_correlativo { get; set; }

        [Required]
        [Column(TypeName = "boolean")]
        [Display(Name = "La factura es negociable?")]
        [DefaultValue(true)]
        public Boolean fis_elec { get; set; }

        [Required]
        [Column(TypeName = "smallint")]
        [Display(Name = "Identificador del estado del documento")]
        [ForeignKey("tipo_documento_estado")]
        public int id_tipo_documento_estado { get; set; }

        [Required]
        [Column(TypeName = "timestamp")]
        [Display(Name = "Fecha de emisión del documento")]
        public DateTime fecha_emision { get; set; }


        #endregion

        #region orden de compra :V

        [Required]
        [Column(TypeName = "char(11)")]
        [Display(Name = "RUC Empresa Cliente")]
        [ForeignKey("OrdenesCompra")]
        public string ruc_empresa_cliente { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Orden de compra Propia del cliente")]
        [ForeignKey("OrdenesCompra")]
        public string id_orden_compra { get; set; }


        #endregion

        #region referido al monto :V

        [Required]
        [Column(TypeName = "char(3)")]
        [Display(Name = "Tipo Moneda")]
        [ForeignKey("tipo_moneda")]
        public string id_tipo_moneda { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "Monto del documento afecto")]
        public decimal monto_subtotal_afecto { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "Monto del documento inafecto")]
        public decimal monto_subtotal_inafecto { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "Monto del igv")]
        public decimal monto_igv { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "Monto isc")]
        public decimal monto_isc { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "Monto total")]
        public decimal monto_total { get; set; }



        #endregion

        #region Solo para las facturas :V

        [Column(TypeName = "char(2)")]
        [Display(Name = "el documento posee detracción?")]
        [ForeignKey("tipo_detracciones")]
        public string id_tipo_detracciones { get; set; }
        
        [Column(TypeName = "boolean")]
        [Display(Name = "La factura es negociable?")]
        [DefaultValue(false)]
        public Boolean? factura_negociable { get; set; }

        #endregion

        #region Solo para notas de crédito y débito :V

        /*
        [Column(TypeName = "varchar(30)")]
        [Display(Name = "Poner la factura origen :")]
        public string factura_origen { get; set; }*/
        
        [Column(TypeName = "varchar(30)")]
        [Display(Name = "Poner la factura serie origen :V")]
        public string factura_origen_serie { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Display(Name = "Poner la factura correlativo origen :V")]
        public string factura_origen_correlativo { get; set; }
        #endregion

        #region Si y Solo sí no se exige la orden de compra :V

        [Column(TypeName = "varchar (80)")]
        [Display(Name = "No es la orden de compra OJO")]
        public string orden { get; set; }

        [Column(TypeName = "varchar (80)")]
        [Display(Name = "el área de la empresa en cuestion")]
        public string ceco { get; set; }

        #endregion

        #region Auditorias :V


        [Required]
        [Column(TypeName = "timestamp")]
        [Display(Name = "Fecha de emisión del documento")]
        public DateTime ultima_modificacion { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Fecha de emisión del documento")]
        public string  usuario_modificacion { get; set; }


        [Column(TypeName = "varchar(50)")]
        [Display(Name = "nro registro contable")]
        public string nro_registro_contable { get; set; }


        [Column(TypeName = "varchar(50)")]
        [Display(Name = "nro conformidad oc")]
        public string nro_conformidad_oc { get; set; }

        [Required]
        [Column(TypeName = "timestamp")]
        [Display(Name = "Fecha verificacion")]
        public DateTime fecha_verificacion { get; set; }

        [Column(TypeName = "timestamp")]
        [Display(Name = "fecha transferencia")]
        public DateTime? fecha_transferencia { get; set; }

        [Column(TypeName = "timestamp")]
        [Display(Name = "fecha contabilizacion")]
        public DateTime? fecha_contabilizacion { get; set; }


        

        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "usuario verificacion")]
        public string usuario_verificacion { get; set; }

        #endregion

        #region archivos asociados

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Nombre del archivo excel que se subió de forma masiva")]
        public string nombre_documento_excel { get; set; }

        [Column(TypeName = "varchar(100)[]")]
        [Display(Name = "nombre del archivo :V")]
        public string[] url_imagen { get; set; }

        #endregion








        [Column(TypeName = "smallint")]
        [Display(Name = "tipo documento devolucion :V")]
        public int id_tipo_documento_devolucion { get; set; }


       





















        public virtual Empresas proveedor { get; set; }        
        public virtual OrdenesCompra ordenCompra { get; set; }
        public virtual tipo_moneda tipoMoneda { get; set; }
        public virtual tipo_documento tipoDocumento { get; set; }
        public virtual tipo_documento_estado tipoDocumentoEstado { get; set; }
        public virtual tipo_detracciones TipoDetracciones { get; set; }

        



    }
}


//[Range(typeof(bool), "false", "true", ErrorMessage = "Debe indicar si es el documento cuenta con una orden de compra.")]
//public Boolean afecto { get; set; }