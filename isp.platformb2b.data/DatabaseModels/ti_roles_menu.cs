using System;
using System.Collections.Generic;
using System.Text;

namespace isp.platformb2b.data.DatabaseModels
{
    public class ti_roles_menu
    {
        public int id_tipo_roles { get; set; }
        public virtual tipo_roles Tipo_Rol { get; set; }

        public int id_tipo_menu { get; set; }
        public virtual tipo_menu Tipo_Menu { get; set; }
    }
}
