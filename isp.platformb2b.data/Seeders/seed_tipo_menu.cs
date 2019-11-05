using isp.platformb2b.data.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace isp.platformb2b.data.Seeders
{
    public class seed_tipo_menu
    {
        public static readonly List<tipo_menu> ListaTipoMenu = new List<tipo_menu>
        {
            new tipo_menu() {
                id_tipo_menu = 1,
                name = "BlackBoard",
                url = "/dashboard",
            },
            new tipo_menu()
            {
                id_tipo_menu = 2,
                name = "Capture",
                url = "/DocumentosPago",
                icon ="fa fa-angle-double-right"
            },
            new tipo_menu()
            {
                id_tipo_menu = 3,
                name = "Verify",
                url = "/AdminIVM",
                icon = "fa fa-angle-double-right"
            },
            new tipo_menu()
            {
                id_tipo_menu = 4,
                name = "Transfer",
                url = "/Transfer",
                icon = "fa fa-angle-double-right"
            },
            new tipo_menu()
            {
                id_tipo_menu = 5,
                name = "Reportes",
                url = "/reporting",
                icon = "fa fa-angle-double-right"
            },
            new tipo_menu()
            {
                id_tipo_menu = 6,
                name = "Salir",
                url = "/user",
                icon = "fa fa-angle-double-right"
            },
            //parte del capture :V
             new tipo_menu()
            {
                id_tipo_menu = 21,
                name = "Ingreso Individual",
                url = "/DocumentosPago/formulario",
                icon = "fa fa-keyboard-o",
                id_tipo_menu_padre = 2,
            },
             new tipo_menu ()
             {
                id_tipo_menu = 22,
                name = "Ingreso Masivo (Excel)",
                url = "/DocumentosPago/excel",
                icon = "fa fa-file-excel-o",
                id_tipo_menu_padre = 2,
             },
             new tipo_menu ()
             {
                id_tipo_menu = 23,
                name = "Resumen de Documentos",
                url = "/DocumentosPago/tabla",
                icon = "fa fa-table",
                id_tipo_menu_padre = 2,
             },

             //parte del verify
              new tipo_menu()
               {
                id_tipo_menu = 31,
                name = "Documentos por Validar",
                url = "/AdminIVM/resumen",
                icon = "fa fa-check",
                id_tipo_menu_padre = 3,
              },
              new tipo_menu ()
              {
                id_tipo_menu = 32,
                name = "Documentos Rechazados",
                url = "/AdminIVM/TablaErrores",
                icon = "fa fa-close",
                id_tipo_menu_padre = 3,
              },
             
              //parte del transfer
              new tipo_menu()
              {
                  id_tipo_menu = 41,
                  name="Documentos transferidos",
                  url="/transfer/tabla",
                  icon = "fa fa-check",
                  id_tipo_menu_padre = 4,
              },
        
              //parte del reporting

           new tipo_menu(){
               id_tipo_menu = 51,
                name= "Ranking de Doc. / Costo",
                url= "/reporting/ranking",
                icon= "fa fa-check",
                id_tipo_menu_padre = 5,

            },
            new tipo_menu(){
                id_tipo_menu =52,
                name= "Ciclo Documentario",
                url= "/reporting/DocumentaryCycle",
                icon= "fa fa-check",
                id_tipo_menu_padre = 5,
            },
            new tipo_menu(){
                id_tipo_menu = 53,
                name= "Gestión de Documentos",
                url= "/reporting/DocumentManagement",
                icon= "fa fa-check",
                id_tipo_menu_padre = 5,

            },
        };
    }
}
