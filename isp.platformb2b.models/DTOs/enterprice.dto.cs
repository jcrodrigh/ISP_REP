using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace isp.platformb2b.models.DTOs
{
    public class enterpriceDTO
    {
        [DisplayName("Ruc de la empresa")]
        [Required (ErrorMessage = "{0} es requerido.")]        
        [StringLength(11,MinimumLength =11,ErrorMessage ="{0} tiene una longitud exacta de 11 dígitos.")]
        [RegularExpression(@"^(1|2)0[0-9]{9}$",ErrorMessage ="{0} no cumple con el formato.")]
        public string ruc_empresa { get; set; }

        [DisplayName("Razón Social")]
        [Required (ErrorMessage = "Se requiere la {0}" )]
        public string razon_social { get; set; }

        [DisplayName("El Domicilio Fiscal")]
        [Required(ErrorMessage = "{0} es requerido.")]
        public string domicilio_fiscal { get; set; }

        [DisplayName("El tipo de ERP de la empresa")]
        [Required(ErrorMessage = "{0} es requerido.")]
        public int id_tipo_empresa_erp { get; set; }

        public Boolean con_pedido { get; set; }

        public Boolean sin_pedido { get; set; }

        //[Column(TypeName = "numeric(5,2)")]
        //[Display(Name = "La tolerancia de la empresa")]
        public decimal tolerancia { get; set; }

        //[Column(TypeName = "smallint")]
        //[Display(Name = "1 (porcentaje) -- 2 (monto)")]
        //[Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        //[]
        public int tipo_tolerancia { get; set; }


    }
}
