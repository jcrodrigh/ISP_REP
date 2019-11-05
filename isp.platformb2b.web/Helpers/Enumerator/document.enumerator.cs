using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace isp.platformb2b.web.Helpers.Enumerator
{
    public static class document_enumerator
    {
        public static string tipo_documento_estado (int id_tipo_documento_estado)
        {
            switch (id_tipo_documento_estado)
            {
                case 1:
                case 5:
                    return "Verificado";
                case 2:
                    return "Transferido";
                case 3:
                    return "Contabilizado";
                case 4:
                    return "Rechazado";
                default:
                    return "";
            }
        }
    }
}
