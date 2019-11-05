using isp.platformb2b.data.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace isp.platformb2b.data.Seeders
{
    public class seed_persona
    {
        public static List<Persona> ListaPersonas = new List<Persona>()
        {
            new Persona()
            {dni_persona ="41912505",ap_paterno ="Sanchez",ap_materno = "Egusquiza",nombres=new string[]{"Rosalyn" } },
            new Persona()
            {dni_persona = "46776521",ap_paterno = "Nicolini", ap_materno ="Rivero", nombres= new string[]{"Cesar", "Gianfranco"}},
            new Persona()
            {dni_persona = "09302752",ap_paterno ="Caceres",ap_materno="Cardenas",nombres = new string[]{ "Roxana", "Cecilia" } },
            new Persona()
            { dni_persona ="09580232",ap_paterno="Romaní",ap_materno="Huyhua",nombres= new string[]{ "Carmela" } },
            new Persona ()
            { dni_persona ="10735744" ,ap_paterno="Rodriguez",ap_materno ="Hernandez", nombres = new string[] {"José","Carlos"}}
        };
    }
}
