using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace isp.platformb2b.data.DatabaseModels
{
    [Table("ti_empresa_empresa")]
    public class ti_empresa_empresa
    {
        
        public string ruc_empresa_cliente { get; set; }
        public virtual Empresas empresa_cli { get; set; }
        
        public string ruc_empresa_proveedor { get; set; }
        public virtual Empresas empresa_pro { get; set; }

        
        [Column(TypeName = "BOOLEAN")]
        [Display(Name = "El usuario está activo?")]
        public Boolean activo { get; set; } = true;
    }
}
