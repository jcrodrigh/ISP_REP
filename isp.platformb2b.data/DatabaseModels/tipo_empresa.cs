using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace isp.platformb2b.data.DatabaseModels
{
    public class tipo_empresa
    {
        [Key]
        [Column(TypeName = "smallint")]
        [Display(Name = "Identificador tipo documento")]
        public int id_tipo_empresa { get; set; }

        [Column(TypeName = "varchar(80)")]
        [Display(Name = "nombre")]
        public string nombre_tipo_empresa { get; set; }
    }
}
