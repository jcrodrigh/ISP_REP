using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace isp.platformb2b.data.DatabaseModels
{
    public class tipo_documento_serie
    {
        [Key]
        [Required]
        [Column(TypeName = "char(2)")]
        [ForeignKey("tipoDocumento")]
        [Display(Name = "Identificador tipo documento")]
        public string id_tipo_documento { get; set; }

        [Key]
        [Required]
        [Column(TypeName = "varchar(20)")]
        [Display(Name = "Identificador del estado del documento")]
        public string id_tipo_documento_serie { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Descripción del estado.")]
        public string descripcion { get; set; }

        public virtual tipo_documento tipoDocumento { get; set; }
    }
}
