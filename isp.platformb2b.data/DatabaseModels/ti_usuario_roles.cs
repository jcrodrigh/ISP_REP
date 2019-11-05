using System;
using System.Collections.Generic;
using System.Text;

namespace isp.platformb2b.data.DatabaseModels
{
    public class ti_usuario_roles
    {
        public string username { get; set; }
        public usuarios usuario { get; set; }


        public int id_tipo_roles { get; set;  }
        public tipo_roles tipo_Rol { get; set; }
    }
}



