using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace isp.platformb2b.data.DatabaseModels
{
    public class ti_empresa_persona
    {
        public ti_empresa_persona ()
        {
            fecha_inscripcion = DateTime.Now;
        }
        public string dni_persona { get; set; }
        public virtual Persona persona { get; set; }

        public string ruc_empresa { get; set; }
        public virtual Empresas empresa { get; set; }

        [Required]
        [Column(TypeName = "timestamp")]
        [Display(Name = "Fecha de inserción")]
        public DateTime fecha_inscripcion { get; set; }

        [Column(TypeName = "timestamp")]
        [Display(Name = "Fecha  de cese del ese sujeto :V")]
        public DateTime? fecha_cese { get; set; }


        [Column(TypeName = "BOOLEAN")]
        [Display(Name = "la relación está activa?")]
        public Boolean activo { get; set; } = true;
    }
}
