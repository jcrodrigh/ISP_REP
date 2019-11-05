using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace isp.platformb2b.data.DatabaseModels
{
    public class tipo_moneda
    {
        public tipo_moneda()
        {
            usual = false;
        }

        [Key]
        [Required]
        [Column(TypeName = "char(3)")]
        [Display(Name = "Tipo Moneda")]
        public string id_tipo_moneda { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Tipo Moneda")]
        public string divisa { get; set; }

        [Column(TypeName = "boolean")]
        [Display(Name = "Tipo Moneda")]
        public Boolean usual { get; set; }



    }
}
