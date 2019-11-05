using isp.platformb2b.data.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace isp.platformb2b.data.Seeders
{
    public class SeedTipoEmpresaErp
    {

        public readonly static List<tipo_empresa_erp> listaTipoEmpresaERP = new List<tipo_empresa_erp>()
        {
            //new tipo_empresa_erp(){id_tipo_empresa_erp=1,nombre_tipo_empresa_erp="No aplica".ToUpper()},
            new tipo_empresa_erp(){id_tipo_empresa_erp=1,nombre_tipo_empresa_erp="SAP"},
            new tipo_empresa_erp(){id_tipo_empresa_erp=2,nombre_tipo_empresa_erp="Oracle"},
            new tipo_empresa_erp(){id_tipo_empresa_erp=3,nombre_tipo_empresa_erp="JDA"},
            new tipo_empresa_erp(){id_tipo_empresa_erp=4,nombre_tipo_empresa_erp="Inhouse"}  

        };
     }
}
