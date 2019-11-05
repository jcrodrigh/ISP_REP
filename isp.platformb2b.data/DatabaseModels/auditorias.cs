using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace isp.platformb2b.data.DatabaseModels
{
    public class auditorias
    {
        public auditorias(){
            fecha = DateTime.Now;
            usuario = "nulo";
        }

        [Key]
        [Column(TypeName = "bigserial")]
        [Display(Name = "id de las auditorías.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id_auditorias { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "nombre tabla :V")]
        public string nombre_tabla {get; set;}

        [Required]
        [Column(TypeName = "timestamp")]
        [Display(Name = "Fecha de auditoria :V")]
        public DateTime fecha { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "llave de la fila :V")]
        public string llave_fila { get; set; }

        [Column(TypeName = "varchar(10000)")]
        [Display(Name = "valor anterior :V")]
        public string valor_anterior { get; set; }

        [Column(TypeName = "varchar(10000)")]
        [Display(Name = "valor nuevo :V")]
        public string valor_nuevo { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "nombre tabla :V")]
        public string usuario { get; set; }


    }
}
