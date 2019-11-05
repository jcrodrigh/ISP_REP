using System;
using System.Collections.Generic;
using System.Text;

namespace isp.platformb2b.data.DatabaseModels
{
    public class ti_tipo_empresa
    {
        public ti_tipo_empresa ()
        {
            fecha = DateTime.Now;
        }

        public string ruc_empresa { get; set; }
        public Empresas empresa { get; set; }
        public int id_tipo_empresa { get; set; }
        public tipo_empresa tipoEmpresa { get; set; }

        public DateTime fecha { get; set; }
    }
}
