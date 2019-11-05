using System;
using System.Collections.Generic;
using System.Text;

namespace isp.platformb2b.models.DTOs
{
    public class UserLoginDTO
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class UserDTO
    {
        public string username { get; set; }
        public string password { get; set; }
        public string ruc_empresa { get; set; }
        public string nombre_completo { get; set; }
        public string[] correo { get; set; }
        public string[] telefono { get; set; }
    }
}
