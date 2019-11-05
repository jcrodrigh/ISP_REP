using System;
using System.ComponentModel;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace isp.platformb2b.data.DatabaseModels
{
    [Table("persona")]
    public class Persona
    {
        public Persona ()
        {
            
        }

        [Key]
        [Column(Order = 0, TypeName = "char(8)")]
        [Display(Name = "DNI de la persona :V")]
        public string dni_persona { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Apellido Paterno")]
        public string ap_paterno { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Apellido Paterno")]
        public string ap_materno { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)[]")]
        [Display(Name = "Apellido Paterno")]
        public string[] nombres { get; set; }


    }
}
