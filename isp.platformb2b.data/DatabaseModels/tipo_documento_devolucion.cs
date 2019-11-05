using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace isp.platformb2b.data.DatabaseModels
{
    public class tipo_documento_devolucion
    {
        [Key]
        [Required]
        [Column(TypeName = "smallint")]
        [Display(Name = "Identificador del motivo de la devolucion")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_tipo_documento_devolucion {get; set;}

        [Required]
        [Column(TypeName = "varchar(80)")]
        [Display(Name = "Descripción del del motivo.")]
        public string motivo { get; set; }
    }
}
