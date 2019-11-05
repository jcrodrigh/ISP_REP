using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace isp.platformb2b.data.DatabaseModels
{
    public class tipo_roles
    {
        [Key]
        [Column(TypeName = "smallint")]
        [Display(Name = "Identificador tipo documento")]
        public int id_tipo_roles {get; set;}


        [Column(TypeName = "smallint")]
        [Display(Name = "id tipo empresa")]
        [ForeignKey("tipo_empresa")]
        public int id_tipo_empresa { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Nombre del rol")]
        public string nombre_rol { get; set; }

        [Column(TypeName = "smallint")]
        [Display(Name = "Identificador tipo documento")]
        
        public int? id_tipo_roles_superior { get; set; }

        public virtual tipo_empresa Tipo_Empresa { get; set; }

        public IList<ti_roles_menu> ti_Roles_Menus { get; set; }

        public IList<ti_usuario_roles>ti_Usuario_Roles { get; set; }

        [ForeignKey("id_tipo_roles_superior")]
        public tipo_roles rol_superior { get; set; }
        //public IList<ti_roles_empresa> ti_roles_empresa { get; set; }
    }
}
