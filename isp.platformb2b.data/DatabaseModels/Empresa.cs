using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace isp.platformb2b.data.DatabaseModels
{ 
    [Table("empresas")]
    public class Empresas
    {
        public Empresas ()
        {
            con_pedido = true;
            sin_pedido = false;
            tipo_tolerancia = 1;
            activo = true;
            habido = true;
            telefono = new string[] { "96875999", "87548965" };
            correo = new string[] {
                "algun_correo1@gmail.com",
                "algun_correo2@gmail.com",
                "algun_correo3@gmail.com",
                "algun_correo4@gmail.com" };
        }
        [Key]
        [Display(Name ="RUC")]
        [Column(TypeName ="char(11)")]
        public string ruc_empresa { get; set; }

        [Required]
        [Column(TypeName = "varchar(130)")]
        [Display(Name = "Nomnbre de la empresa")]
        public string razon_social { get; set; }

        [Column(TypeName = "varchar(200)")]
        [Display(Name = "Ubicación de la empresa")]
        public string domicilio_fiscal { get; set; }

        [Column(TypeName = "smallint")]
        [Display(Name = "Identificador tipo de ERP de las empresas")]
        [ForeignKey("tipo_erp")]
        public int? id_tipo_empresa_erp { get; set; }

        
        [Column(TypeName = "boolean")]
        [Display(Name = "La empresa requiere que tenga pedido.")]
        [DefaultValue(true)]
        public Boolean con_pedido { get; set; }

        [Required]
        [Column(TypeName = "boolean")]
        [Display(Name = "La empresa requiere que tenga pedido.")]
        [DefaultValue(false)]
        public Boolean sin_pedido { get; set; } 

        [Column(TypeName = "numeric(5,2)")]
        [Display(Name = "La tolerancia de la empresa")]
        public decimal tolerancia { get; set; }

        [Column(TypeName = "smallint")]
        [Display(Name = "1 (porcentaje) -- 2 (monto)")]
        public int tipo_tolerancia { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "ubicación del logo")]
        public string logo { get; set; }

        
        [Column(TypeName = "boolean")]
        [Display(Name = "Está activo en el sistema IVM ?")]
        [DefaultValue(true)]
        public Boolean activo { get; set; } = true;



        
        [Column(TypeName = "boolean")]
        [Display(Name = "La sunat lo ha bloqueado?")]
        [DefaultValue(true)]
        public Boolean habido { get; set; } = true;


        [Column(TypeName = "varchar(100)[]")]
        [Display(Name = "correo de la empresa")]
        public string[] correo { get; set; } 

        
        [Column(TypeName = "varchar(12)[]")]
        [Display(Name = "EL telefono de la empresa")]
        public string[] telefono { get; set; }

        
        [Column(TypeName = "varchar(130)")]
        [Display(Name = "<Codigo de Proveedor/Acreedor")]
        public string acreedor { get; set; }

        
        [Column(TypeName = "smallint")]
        [Display(Name = "Condicion de Pago")]
        public int condicion_pago { get; set; }

        
        [Column(TypeName = "timestamp")]
        [Display(Name = "Fecha de Registro en el sistema del cliente")]
        public DateTime? fecha_registro_proveedor { get; set; }



        public virtual tipo_empresa_erp tipo_erp { get; set; }



        
        public IList<ti_empresa_empresa> Empresas_Clientes { get; set; }
        public IList<ti_empresa_empresa> Empresas_Proveedoras { get; set; }

        public IList<ti_tipo_empresa> Ti_Tipo_Empresas { get; set; }

        //public IList<ti_empresa_empresa> empresa_pro { get; set; }

        //[Required]
        //public ICollection<tipo_rol> roles { get; set; }

        //public ICollection<OrdenesCompra> ordenesCompra { get; set; }


    }
}
