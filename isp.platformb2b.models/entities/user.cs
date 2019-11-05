using System;
using System.Collections.Generic;
using System.Text;

namespace isp.platformb2b.models.entities
{
    public class UserSignIn
    {
        public string username { get; set; }

        public string ruc_empresa { get; set; }

        public string token { get; set; }

        public List<string> roles { get; set; }
    }
}
