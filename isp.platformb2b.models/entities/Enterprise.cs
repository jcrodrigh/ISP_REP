using System;
using System.Collections.Generic;
using System.Text;

namespace isp.platformb2b.models.entities
{
    public class EnterpriseRegister
    {
        public string ruc_empresa { get; set; }
        public string razon_social { get; set; }

        public string password { get; set; }

        public string token { get; set; }

        public string direccion { get; set; }

        public List<string> roles { get; set; }


    }

    public class DataBasicEnterprise
    {
        public string ruc_empresa { get; set; }
        public string razon_social { get; set; }
    }


    public class Enterprise
    {
        public string ruc_empresa { get; set; }
        public string razon_social { get; set; }
        public string domicilio_fiscal { get; set; }


        public Boolean activo { get; set; } = true;


        public int? id_tipo_empresa_erp { get; set; }


        public Boolean habido { get; set; } = true;
        public Boolean con_pedido { get; set; }
        public Boolean sin_pedido { get; set; }
        public decimal tolerancia { get; set; } = 0;
        public int tipo_tolerancia { get; set; }

        public string logo { get; set; }

    }

    public class Enterprise_Enterprise 
    {
        public string ruc_empresa_cliente { get; set; }
        public string ruc_empresa_proveedor { get; set; }
        public Boolean activo { get; set; } = true;
    }

    
}
