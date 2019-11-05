using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace isp.platformb2b.data.DatabaseModels
{
    public class tipo_empresa_erp
    {
        [Key]
        [Column(TypeName = "smallint")]
        [Display(Name = "Identificador tipo documento")]
        public int id_tipo_empresa_erp { get; set; } 

        [Required]
        [Column(TypeName = "varchar(300)")]
        [Display(Name = "Tipo Documento")]
        public string nombre_tipo_empresa_erp { get; set; }
    }
}
