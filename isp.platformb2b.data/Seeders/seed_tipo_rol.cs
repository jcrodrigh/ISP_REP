using isp.platformb2b.data.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace isp.platformb2b.data.Seeders
{
    class seedTipoRol
    {
        public static readonly List<tipo_roles> ListaRoles = new List<tipo_roles>
            {
                new tipo_roles() { id_tipo_roles = 11,id_tipo_empresa= 1, nombre_rol = "cli-adm", },
                new tipo_roles() { id_tipo_roles = 21,id_tipo_empresa = 2, nombre_rol = "prov-adm" },
                new tipo_roles() { id_tipo_roles = 31,id_tipo_empresa = 3, nombre_rol = "ivm-adm" },
                new tipo_roles() { id_tipo_roles = 41, id_tipo_empresa = 4, nombre_rol = "userivm" },

            };
    }
}
