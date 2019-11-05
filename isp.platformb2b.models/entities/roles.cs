using System;
using System.Collections.Generic;
using System.Text;

namespace isp.platformb2b.models.entities
{
    public class roles
    {
        public int id_tipo_roles { get; set; }

        public string nombre_rol { get; set; }
    }

    public class NavBarByRoles
    {
      
        public int id_tipo_menu { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string icon { get; set; }
        public int? id_tipo_menu_padre { get; set; }
    }
}
