using System;
using System.Collections.Generic;
using System.Text;

namespace isp.platformb2b.models.entities
{
    public class PurcharseOrder
    {
        public string ruc_empresa_cliente { get; set; }
        public string id_orden_compra { get; set; }
        public string id_tipo_moneda { get; set; }
        public decimal monto_orden_compra { get; set; }
        public string ruc_empresa_proveedor { get; set; }
        public Boolean competado { get; set; }
        public decimal monto_acumulado { get; set; }
        public Boolean cerrado { get; set; }
        public decimal monto_cliente { get; set; }
        public DateTime fecha_creacion { get; set; }
        public Boolean activa { get; set; }

       
    }
}
