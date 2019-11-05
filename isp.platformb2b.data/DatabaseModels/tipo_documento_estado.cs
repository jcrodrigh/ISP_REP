using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace isp.platformb2b.data.DatabaseModels
{
    public class tipo_documento_estado
    {
        [Key]
        [Required]
        [Column(TypeName = "smallint")]
        [Display(Name = "Identificador del estado del documento")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_tipo_documento_estado {get; set;}

        [Required]
        [Column(TypeName = "varchar(80)")]
        [Display(Name = "Descripción del estado.")]
        public string estado { get; set; }
    }
}
