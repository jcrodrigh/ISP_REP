using isp.platformb2b.data.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace isp.platformb2b.data.Seeders
{
    public class seed_ti_usuario_roles
    {
        public static readonly List<ti_usuario_roles> listaRolesUsuario = new List<ti_usuario_roles>
        {
            new ti_usuario_roles () {username="cesar",id_tipo_roles=11},
            new ti_usuario_roles () {username="cesar",id_tipo_roles=21},
            
            new ti_usuario_roles () {username="rsanchez",id_tipo_roles=21},
            new ti_usuario_roles() {username="cromani",id_tipo_roles=31},
            new ti_usuario_roles() {username="rcaceres",id_tipo_roles=31},

            new ti_usuario_roles() {username = "jc_temporal",id_tipo_roles = 21}
            
            //new ti_usuario_roles () {username="rsanchez",id_tipo_roles=21}
        };
    }
}
