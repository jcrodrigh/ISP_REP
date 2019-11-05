using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace isp.platformb2b.web.entities
{
    public class CredencialSmtp
    {
        public string host { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string dirServerRecibo { get; set; }
        public string dirServerFactura { get; set; }
        public string dirServerDebito { get; set; }
        public string dirServerCredito { get; set; }
        public string dirServerBoleta { get; set; }
    }
}
