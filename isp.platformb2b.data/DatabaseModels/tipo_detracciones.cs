using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace isp.platformb2b.data.DatabaseModels
{
    public class tipo_detracciones
    {
        [Key]
        [Required]
        [Column(TypeName = "char(2)")]
        [Display(Name = "id de las detracciones")]
        public string id_tipo_detracciones { get; set; }

        [Required]
        [Column(TypeName = "varchar(80)")]
        [Display(Name = "Descripción de las detracciones :V")]
        public string descripcion_detracciones { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "valor de las detracciones")]
        public decimal valor_detracciones { get; set; }



    }
}
