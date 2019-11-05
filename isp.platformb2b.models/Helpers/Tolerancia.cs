using isp.platformb2b.data.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace isp.platformb2b.models.Helpers
{
    public static class Tolerance
    {
        public static OrdenesCompra ToleranceCalculate (OrdenesCompra oc, Empresas ent, documento doc)
        {
            OrdenesCompra nueva = oc;
            decimal tope_max = oc.monto_orden_compra;
            decimal tope_min = oc.monto_orden_compra;
            if (ent.tipo_tolerancia == 1)
            {
                tope_max = oc.monto_orden_compra * (1 + ent.tolerancia);
                tope_min = oc.monto_orden_compra * (1 - ent.tolerancia);
            }
            else if(ent.tipo_tolerancia ==2)
            {
                tope_max = oc.monto_orden_compra + ent.tolerancia;
                tope_min = oc.monto_orden_compra - ent.tolerancia;
            }

            decimal suma_doc = (doc.monto_subtotal_afecto + doc.monto_subtotal_inafecto) + oc.monto_acumulado;
            nueva.monto_acumulado = suma_doc;
            if (tope_max>= suma_doc)
            {
                nueva.monto_acumulado = suma_doc;
                if (tope_min<= suma_doc && tope_max >= suma_doc)
                {
                    nueva.competado = true;                    
                }
                return nueva;
            }
            else
            {
                return nueva;
            }
            
        }

        public static Boolean ToleranceOK(OrdenesCompra oc, Empresas ent, documento doc)
        {
            decimal tope_max = oc.monto_orden_compra;
            
            if (ent.tipo_tolerancia == 1)
            {
                tope_max = oc.monto_orden_compra * (1 + ent.tolerancia);                
            }
            else if (ent.tipo_tolerancia == 2)
            {
                tope_max = oc.monto_orden_compra + ent.tolerancia;                
            }

            decimal suma_doc = (doc.monto_subtotal_afecto + doc.monto_subtotal_inafecto) + oc.monto_acumulado;
            if (tope_max >= suma_doc)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
