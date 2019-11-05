using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace isp.platformb2b.data.DatabaseModels
{
    public class documento_errores
    {
        public documento_errores()
        {
            ultima_modificacion = DateTime.Now;
            usuario_modificacion = "by Email";
        }

        [Key]        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_documento_errores { get; set; }

        
        [Column(TypeName = "varchar(20)")]
        [Display(Name = "Identificador tipo documento")]
        public string id_tipo_documento { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Display(Name = "Número de serie la factura")]
        public string num_serie { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Display(Name = "Número de serie la factura")]
        public string num_correlativo { get; set; }

        #region Proveedor

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "RUC Empresa proveedor")]
        public string ruc_empresa_proveedor { get; set; }

        [Column(TypeName = "varchar(400)")]
        [Display(Name = "RUC Empresa proveedor")]
        public string razon_social_proveedor { get; set; }

        //[Column(TypeName = "varchar(1000)")]
        //[Display(Name = "RUC Empresa proveedor")]
        //public string correos { get; set; }

        #endregion

        #region cliente

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "RUC Empresa cliente")]
        public string ruc_empresa_cliente { get; set; }

        [Column(TypeName = "varchar(400)")]
        [Display(Name = "RUC Empresa cliente")]
        public string razon_social_cliente { get; set; }

        #endregion 

        [Column(TypeName = "timestamp")]
        [Display(Name = "Fecha de emisión del documento")]
        public DateTime fecha_emision { get; set; }


        [Column(TypeName = "varchar(1000)")]
        [Display(Name = "dto")]
        public string documento { get; set; }

        [Column(TypeName = "varchar(10000)")]
        [Display(Name = "errores tipo diccionario")]
        public string errores { get; set; }

        [Required]
        [Column(TypeName = "timestamp")]
        [Display(Name = "Fecha de emisión del documento")]
        public DateTime ultima_modificacion { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Fecha de emisión del documento")]
        public string usuario_modificacion { get; set; }
    }
}