using isp.platformb2b.data.DatabaseModels;
using System.Collections.Generic;
using System.Reflection;

namespace isp.platformb2b.models.Helpers
{
    public static class AuditoriaHelper
    {
        
        public static List<Variance> DetailedCompare<T>(this T val1, T val2)
        {
            List<Variance> variances = new List<Variance>();
            FieldInfo[] fi = val1.GetType().GetFields();
            foreach (FieldInfo f in fi)
            {
                Variance v = new Variance();
                v.Prop = f.Name;
                v.valA = f.GetValue(val1);
                v.valB = f.GetValue(val2);
                if (!v.valA.Equals(v.valB))
                    variances.Add(v);

            }
            return variances;
        }

        public static auditorias OrdenDeCompraAuditorias (OrdenesCompra oldx, OrdenesCompra newx)
        {
            List<Variance> rt = oldx.DetailedCompare(newx);
            auditorias audit = new auditorias();

            return audit;
        }
        
    }
}
