using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace isp.platformb2b.data.DatabaseModels
{
    [Table("usuarios")]
    public class usuarios
    {
        public usuarios()
        {
            activo = true;
            nombre_completo = "--";
        }

        [Key]
        [Display(Name = "nombre de usuario.")]
        [Column(TypeName = "varchar(30)")]
        public string username { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        [Display(Name = "Password del usuario.")]
        public string password { get; set; }

        [Required]
        [Column(TypeName = "char(11)")]
        [ForeignKey("empresa")]
        [Display(Name = "Empresa a la que pertenece el usuario.")]
        public string ruc_empresa { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        [Display(Name = "Nombre completo del usuario")]
        public string nombre_completo { get; set; }


        [Required]
        [Column(TypeName = "BOOLEAN")]
        [Display(Name = "El usuario está activo?")]
        public Boolean activo { get; set; }


        [Required]
        [Column(TypeName = "varchar(100)[]")]
        [Display(Name = "correo de la persona")]
        public string[] correo { get; set; }

        [Required]
        [Column(TypeName = "varchar(12)[]")]
        [Display(Name = "EL telefono de la persona")]
        public string[] telefono { get; set; }

        public virtual Empresas empresa { get; set; }
        public IList<ti_usuario_roles> ti_roles_empresa { get; set; }

        

    }
}


//[Column(TypeName = "integer")]
//[Display(Name = "Aun no definido :V")]
//public int id_persona { get; set; }

//[Required]
//[Column(TypeName = "BOOLEAN")]
//[Display(Name = "El usuario es una empresa o una persona?")]
//public Boolean per_emp { get; set; }


//public virtual Persona persona { get; set; }

//[Column(TypeName = "char(8)")]
//[Display(Name = "El usuario es una empresa o una persona?")]
//[ForeignKey("persona")]
//public string dni_persona { get; set; }
