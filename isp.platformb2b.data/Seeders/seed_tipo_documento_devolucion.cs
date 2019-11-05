using isp.platformb2b.data.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace isp.platformb2b.data.Seeders
{
    public class seed_tipo_documento_devolucion
    {
        public readonly static List<tipo_documento_devolucion> listaTipoDocumentomotivo = new List<tipo_documento_devolucion>()
        {
            new tipo_documento_devolucion(){id_tipo_documento_devolucion=1,motivo="Error en datos de la compañía."},
            new tipo_documento_devolucion(){id_tipo_documento_devolucion=2,motivo="Error en el cálculo del impuesto."},
            new tipo_documento_devolucion(){id_tipo_documento_devolucion=3,motivo="No contiene el dato de N° de pedido y Conformidad."},
            new tipo_documento_devolucion(){id_tipo_documento_devolucion=4,motivo="No contiene los datos de detracciones."},
            new tipo_documento_devolucion(){id_tipo_documento_devolucion=5,motivo="Documento referido a un documento equivocado."},
            new tipo_documento_devolucion(){id_tipo_documento_devolucion=6,motivo="Por duplicidad."},
            new tipo_documento_devolucion(){id_tipo_documento_devolucion=7,motivo="Montos no coinciden con los montos de la conformidad."},
            new tipo_documento_devolucion(){id_tipo_documento_devolucion=8,motivo="Emitidos a otra razón social."},
            new tipo_documento_devolucion(){id_tipo_documento_devolucion=9,motivo="Error en la tasa del IGV."},
            new tipo_documento_devolucion(){id_tipo_documento_devolucion=10,motivo="Error en la descripción de los montos en relación a los numéricos."},
            new tipo_documento_devolucion(){id_tipo_documento_devolucion=11,motivo="Fechas superiores al establecido fiscalmente."},
        };
    }
}
