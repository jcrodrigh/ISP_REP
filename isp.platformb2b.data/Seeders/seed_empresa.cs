using isp.platformb2b.data.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace isp.platformb2b.data.Seeders
{
    public class seedEmpresa
    {
        public static readonly List<Empresas> ListaEmpresas = new List<Empresas>
        {
            new Empresas() {
                ruc_empresa ="10467765219",
                razon_social ="cesar Nicolini Rivero",
                domicilio_fiscal ="calle hipolito bernandette 129 barranco",
                id_tipo_empresa_erp =1,
                tipo_tolerancia = 1,
                //roles = {new tipo_rol() { id_tipo_roles=1} }}
            },
             new Empresas() {
                ruc_empresa ="20111111119",
                //password="123456",
                razon_social ="Las Bellezas",
                domicilio_fiscal ="Calle Olenka Kocchiu 369 - Surco",
                id_tipo_empresa_erp =2,
                tipo_tolerancia = 2,
                con_pedido=false,
                sin_pedido=false,
                logo = "20111111119.png"
            },
             new Empresas()
             {
                 ruc_empresa ="20222222229",
                 //password="123456",
                 razon_social ="Empresa feliz 2",
                 domicilio_fiscal ="Dirección bonita 147 - Bellavista",
                 id_tipo_empresa_erp =3,
                 tipo_tolerancia = 1,
                 con_pedido=true,
                 sin_pedido=false,
                 logo = "20222222229.png"
             },
             new Empresas() {
                ruc_empresa ="20333333339",
                //password="123456",
                razon_social ="Empresa fuerte 3",
                domicilio_fiscal ="Calle los poderosos 8080 - Callao",
                 id_tipo_empresa_erp =2,
                 tipo_tolerancia = 1,
                 con_pedido=false,
                 sin_pedido=false,
                 logo = "20333333339.jpg",
                //roles = {new tipo_rol() { id_tipo_roles=1} }}
            },
             new Empresas()
             {
                 ruc_empresa ="20444444449",
                 //password="123456",
                 razon_social ="Los creativos SAC",
                 domicilio_fiscal ="los pintores 456 - Villa Creatividad",
                 con_pedido=false,
                 sin_pedido=true,
                 id_tipo_empresa_erp =1,
                 tipo_tolerancia = 1,
                 logo = "20444444449.jpg"
             },
             new Empresas()
             {
                 ruc_empresa ="20555555559",
                 //password="123456",
                 razon_social ="Los negociantes del Perú",
                 domicilio_fiscal ="Los negocios del Sur 147 - San Isidro",
                 id_tipo_empresa_erp =1,
                 con_pedido=true,
                 sin_pedido=false,
                 tipo_tolerancia = 2,
                 logo = "20555555559.jpg"
             },
             new Empresas() {
                ruc_empresa ="20666666669",
                //password="123456",
                razon_social ="Los vendedores",
                domicilio_fiscal ="Calle Venta Casual 345 - San Miguel",
                con_pedido=false,
                 sin_pedido=true,
                 id_tipo_empresa_erp =2,
                 logo = "20666666669.jpg"
             },
             new Empresas()
             {
                 ruc_empresa ="20777777779",
                 //password="123456",
                 razon_social ="La Fuerza Agraria",
                 domicilio_fiscal ="La Agraria 234 - La Molina",
                 id_tipo_empresa_erp =1,
                 tolerancia = (decimal) 0.05,
                 con_pedido=true,
                 sin_pedido=true,
                  logo = "20777777779.png"
             },
             new Empresas()
             {
                 ruc_empresa ="20888888889",
                 //password="123456",
                 razon_social ="Rompe Casas SRL",
                 domicilio_fiscal ="Los Destructores 147 - SMP",
                 id_tipo_empresa_erp =2,
                 con_pedido=true,
                 sin_pedido=true,
                 logo = "20888888889.jpg"
             },
             new Empresas() {
                ruc_empresa ="20999999999",
                //password="123456",
                razon_social ="Las Monjitas caritativas",
                domicilio_fiscal ="Calle Villa de Jesús 345 - Jesús Maria",
                id_tipo_empresa_erp =1,
                con_pedido=false,
                sin_pedido=true,
                logo = "20999999999.png"
            },
             new Empresas()
             {
                 ruc_empresa ="20000000009",
                 //password="123456",
                 razon_social ="Los Seguidores de Jobs",
                 domicilio_fiscal ="Steve Jobs 763 - Barranco",
                 id_tipo_empresa_erp =1,
                 con_pedido=true,
                 sin_pedido=false,
                 logo = "20000000009.jpg"
             },
            
             new Empresas()
             {
                 ruc_empresa = "20546183107",
                 razon_social = "CONSORCIO ALTA MODA S.R.L",
                 domicilio_fiscal = "C L. MAR ISC AL AGUSTIN GAMAR R A NR O . 326 LIMA - LIMA - SAN LUIS",
                 con_pedido = true,
                 sin_pedido = true,
                 id_tipo_empresa_erp =1,

             },
             new Empresas()
             {
                 ruc_empresa = "20100070970",
                 razon_social = "SUPERMERCADOS PERUANOS S.A. 'O' S.P.S.A.",
                 domicilio_fiscal = "DIRECCIÓN DEL CLIENTE: CAL.MORELLI 181 INT. P-2 LIMA- LIMA- SAN BORJA",
                 con_pedido = true,
                 sin_pedido = true,
                 id_tipo_empresa_erp =1,

             },
              new Empresas()
             {
                 ruc_empresa ="20605411003",
                 //password="123456",
                 razon_social ="Romani & Caceres Business Solutions SAC",
                 domicilio_fiscal ="--",
                 id_tipo_empresa_erp = 3,

                 
                 
             },


        };
    }
}
