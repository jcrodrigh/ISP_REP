using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace isp.platformb2b.data.DatabaseModels
{
    public class tipo_menu
    {
        /*public int id_tipo_menu { get; set; }
        public */

        public tipo_menu ()
        {
            //menus_hijos = new HashSet<tipo_menu>();
        }

        [Key]
        [Column(TypeName = "smallint")]
        [Display(Name = "Identificador tipo documento")]
        public int id_tipo_menu { get; set; }

        [Column(TypeName = "varchar(80)")]
        [Display(Name = "nombre")]
        public string name { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Display(Name = "url")]
        public string url { get; set; }

        [Column(TypeName = "varchar(80)")]
        [Display(Name = "icono")]
        public string icon { get; set; }
        
        [Column(TypeName = "smallint")]
        [Display(Name = "Identificador tipo documento")]
        //[ForeignKey("menu_padre")]
        public int? id_tipo_menu_padre { get; set; }

        [ForeignKey("id_tipo_menu_padre")]        
        public virtual tipo_menu menu_padre { get; set; }

        //public virtual ICollection<tipo_menu> menus_hijos { get; set; }
        




    }
}
