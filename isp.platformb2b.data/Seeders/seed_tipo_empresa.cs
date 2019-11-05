using isp.platformb2b.data.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace isp.platformb2b.data.Seeders
{

    public class seed_tipo_empresa
    {
        public static readonly List<tipo_empresa> ListaTipoEmpresa = new List<tipo_empresa>()
        {
            new tipo_empresa () {id_tipo_empresa = 1, nombre_tipo_empresa = "Cliente" },
            new tipo_empresa () {id_tipo_empresa = 2, nombre_tipo_empresa = "Proveedor" },
            new tipo_empresa () {id_tipo_empresa = 3, nombre_tipo_empresa = "IVM"},
            new tipo_empresa () {id_tipo_empresa = 4, nombre_tipo_empresa = "Admin"}
        };
    }
}
