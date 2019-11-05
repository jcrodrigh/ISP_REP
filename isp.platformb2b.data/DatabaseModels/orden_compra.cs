using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace isp.platformb2b.data.DatabaseModels
{
    [Table("ordenes_compra")]
    public class OrdenesCompra
    {
      
        public OrdenesCompra()
        {
            this.fecha_creacion = DateTime.Now;
            this.monto_acumulado = 0;
            this.monto_cliente = 0;
            this.competado = false;
            this.activa = true;
            this.cerrado = false;
        }

        #region explicación llave primaria doble :V
        /*
         * Se ha creado Una primary key a partir de dos columnas
         * (ruc_empresa_cliente, id_orden_compra)
         * ¿Por qué?
         * no existe un único código para la orden de compra
         * es muy relativo al cliente
         * ejemplo:
         *      ruc: 20105555555 maneja las ordenes de compra A01 B01 C01
         *      ruc: 20107777777 maneja las ordenes de compra A01 A02 A03
         *      
         *      --> coincide A01 en ambas empresas <--
         *      por ende se crea una dependencia entre empresa y su orden de compra
         *      
         */
        #endregion

        [Key]
        [Column(Order = 0, TypeName = "char(11)")]
        [ForeignKey("cliente")]
        [Display(Name = "RUC Empresa Cliente")]
        public string ruc_empresa_cliente { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "varchar(100)")]
        [Display(Name = "Orden de compra Propia del cliente")]
        public string id_orden_compra { get; set; }

        
        [Column(TypeName = "char(11)")]
        [Display(Name = "Ruc de la empresa provedor")]
        [ForeignKey("proveedor")]
        public string ruc_empresa_proveedor { get; set; }

        [Required]
        [Column(TypeName = "char(3)")]
        [Display(Name = "Tipo Moneda")]
        [ForeignKey("tipo_moneda")]
        public string id_tipo_moneda { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "Monto de la orden de compra")]
        public decimal monto_orden_compra { get; set; }

        [Required]
        [Column(TypeName = "timestamp")]
        [Display(Name = "Fecha creación de la orden de compra")]
        public DateTime fecha_creacion { get;  }

        [Required]
        [Column(TypeName = "boolean")]
        [Display(Name = "complado")]
        [DefaultValue(false)]
        public Boolean competado { get; set; }

        [Required]
        [Column(TypeName = "boolean")]
        [Display(Name = "cerrado")]
        [DefaultValue(false)]
        public Boolean cerrado { get; set; }

        [Required]
        [Column(TypeName = "boolean")]
        [Display(Name = "activa")]
        [DefaultValue(true)]
        public Boolean activa { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "Monto de la orden de compra")]
        public decimal monto_acumulado { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "Monto que posee el cliente en la base de datos")]
        public decimal monto_cliente { get; set; }


        public virtual Empresas cliente { get; set; }
        public virtual tipo_moneda tipoMoneda { get; set; }
        public virtual Empresas proveedor { get; set; }


    }
}
