using isp.platformb2b.data.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace isp.platformb2b.data.Seeders
{
    public class seed_usuario
    {
        public static readonly List<usuarios> ListaUsuarios = new List<usuarios>()
        {
            new usuarios(){username="cesar",
                correo = new string[]{ "cesar.nicolini@pucp.pe"},
                password="123456",
                //per_emp = true,
                //dni_persona = "46776521",
                ruc_empresa ="20111111119",
                
                telefono = new string[]{"4774267","959863830"}
            },
            
             new usuarios(){username="rsanchez",
                 //dni_persona = "41912505",
                correo = new string[]{ "administracion@ispconsulting.pe"},
                password="123456",
                //per_emp = true,
                ruc_empresa ="20600044495",
                telefono = new string[]{"6969696","96969696969"}
            },
             new usuarios(){username="cromani",
                 //dni_persona = "09580232",
                correo = new string[]{ ""},
                password="123456",
                //per_emp = true,
                ruc_empresa ="20605411003",
                telefono = new string[]{"6969696","96969696969"}
            },
             new usuarios(){username="rcaceres",
                 //dni_persona = "09302752",
                correo = new string[]{ ""},
                password="123456",
                //per_emp = true,
                ruc_empresa ="20605411003",
                telefono = new string[]{"6969696","96969696969"}
            },
             new usuarios()
             {
                 username ="jc_temporal",
                 password ="123456",
                 //dni_persona ="10735744",
                 correo = new string[]{""},
                    //per_emp = true,
                    ruc_empresa ="20500123797",
                    telefono = new string[]{"6969696","96969696969"}
             }
        };
    }
}
