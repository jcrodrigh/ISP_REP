using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace isp.platformb2b.data.DatabaseModels
{
    public class ti_empresa_erp
    {
        [Key]
        [Required]
        [Display(Name = "RUC")]
        [Column(TypeName = "char(11)")]
        public int ruc_empresa { get; set; }

        [Key]
        [Required]
        [Column(TypeName = "char(3)")]
        [Display(Name = "Nombre ERP")]
        public string nombre_erp { get; set; }
    }
}
