using System;
using System.Collections.Generic;
using System.Text;

namespace isp.platformb2b.models.entities
{
    public class KeyValue
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class detracciones
    {
        public string id_tipo_detracciones  { get; set; }
        public string descripcion_detracciones { get; set; }
        public decimal valor_detracciones { get; set; }
    }

    public class SerialDocuments
    {
        public string id_tipo_documento { get; set; }
        public string id_tipo_documento_serie { get; set; }
        public string descripcion { get; set; }
    }
}
