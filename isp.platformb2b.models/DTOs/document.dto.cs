using isp.platformb2b.models.entities;
using isp.platformb2b.models.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text.RegularExpressions;

namespace isp.platformb2b.models.DTOs.documents
{
    public class documentDTO
    {



        #region Identificación del documento :V

        public string ruc_empresa_proveedor { get; set; }
        public string id_tipo_documento { get; set; }
        public string num_serie { get; set; }
        public string num_correlativo { get; set; }
        public Boolean fis_elec { get; set; }
        public DateTime fecha_emision { get; set; }



        #endregion


       

        #region orden de compra :V


        public string ruc_empresa_cliente { get; set; }
        public string id_orden_compra { get; set; }


        #endregion

        #region referido al monto :V

        public string id_tipo_moneda { get; set; }

        public decimal monto_subtotal_afecto { get; set; }

        public decimal monto_subtotal_inafecto { get; set; }

        public decimal monto_igv { get; set; }

        public decimal monto_isc { get; set; }

        public decimal monto_total { get; set; }



        #endregion



        //public int id_tipo_documento_estado { get; set; }

        #region Solo para notas de crédito y débito :S
        public string factura_origen_serie { get; set; }
        public string factura_origen_correlativo { get; set; }

        #endregion

       
        #region Solo para facturas :S

        public string id_tipo_detracciones { get; set; }
        public Boolean? factura_negociable { get; set; }

        #endregion



        #region si y solo si NO existe orden de compra
        public string ceco { get; set; }
        public string orden { get; set; }
        #endregion

        #region archivos asociados
        public string nombre_documento_excel { get; set; }
        public string[] url_imagen { get; set; }

        #endregion 
    }
}
