using isp.platformb2b.data.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace isp.platformb2b.data.Seeders
{
    public class SeedTipoDocumentoEstado
    {
        public readonly static List<tipo_documento_estado> listaTipoDocumentoEstado = new List<tipo_documento_estado>()
        {
            new tipo_documento_estado { id_tipo_documento_estado = 1, estado = "Verificado" },
            new tipo_documento_estado { id_tipo_documento_estado = 2, estado = "Transferido" },
            new tipo_documento_estado { id_tipo_documento_estado = 3, estado = "Contabilizado" },
            new tipo_documento_estado { id_tipo_documento_estado = 4, estado = "Rechazado" }

        };
    }
}
