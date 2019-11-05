using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;

using OfficeOpenXml;
using System.IO;
using isp.platformb2b.models.entities;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using isp.platformb2b.web.Helpers.Enumerator;

namespace isp.platformb2b.web.Helpers

{

    class export_errors
    {
        private IHostingEnvironment _hostingEnvironment;
        public export_errors(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public string mecmec(List<ErrorsByDocument> errors)
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;
            object misvalue = System.Reflection.Missing.Value;

            string nameFile;

            using (ExcelPackage excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("Worksheet1");
                //excel.Workbook.Worksheets.Add("Worksheet2");
                //excel.Workbook.Worksheets.Add("Worksheet3");

                var headerRow = new List<string[]>()
                {
                new string[] { "ID", "Ruc Cliente", "Razón Social Cliente", "Ruc Proveedor",
                    "Razón Social Proveedor", "Número Serie", "Número Correlativo",
                    "Moneda","Valor Total","tipo Documento",
                    "Motivo Rechazo", "fecha Correo", "Correo Destino"
                }
                };

                // Determine the header range (e.g. A1:D1)
                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";
                // Target a worksheet
                var worksheet = excel.Workbook.Worksheets["Worksheet1"];
                // Popular header row data
                worksheet.Cells[headerRange].LoadFromArrays(headerRow);


                int i = 2;
                foreach (ErrorsByDocument err in errors)
                {
                    //worksheet.Cells[1, 2].Value = "This is cell B1!";
                    worksheet.Cells[i, 1].Value = err.id_documento_errores;
                    worksheet.Cells[i, 2].Value = err.ruc_empresa_cliente;
                    worksheet.Cells[i, 3].Value = err.razon_social_cliente;
                    worksheet.Cells[i, 4].Value = err.ruc_empresa_proveedor;
                    worksheet.Cells[i, 5].Value = err.razon_social_proveedor;
                    worksheet.Cells[i, 6].Value = err.num_serie;
                    worksheet.Cells[i, 7].Value = err.num_correlativo;
                    worksheet.Cells[i, 8].Value = err.documento.id_tipo_moneda;
                    worksheet.Cells[i, 9].Value = err.documento.monto_total ;
                    worksheet.Cells[i, 10].Value = err.id_tipo_documento;
                    worksheet.Cells[i, 11].Value = errors2string(err.errores);//JsonConvert.SerializeObject(err.errores);
                    worksheet.Cells[i, 12].Value = err.ultima_modificacion.ToString("dd/MM/yyyy HH:mm:ss");
                    worksheet.Cells[i, 13].Value = string.Join(",",err.correos);
                    i++;
                }

                nameFile = CreatePath();
                FileInfo excelFile = new FileInfo(nameFile);
                excel.SaveAs(excelFile);
            }

            return nameFile;

        }

        private string CreatePath()
        {


            string folderName = "Errores";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string ExcelsPath = Path.Combine(webRootPath, folderName);

            if (!Directory.Exists(ExcelsPath))
            {
                Directory.CreateDirectory(ExcelsPath);
            }

            /*
            string folderUser = Path.Combine(ExcelsPath, User.Identity.Name);
            if (!Directory.Exists(folderUser))
            {
                Directory.CreateDirectory(folderUser);
            }
            */


            string nameFile =  DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            string fullPath = Path.Combine(ExcelsPath, nameFile);
            return fullPath;
        }


        private string errors2string (Dictionary<string,List<string>> errores)
        {
            string lista = "";
            foreach (KeyValuePair<string,List<string>> errorx in errores)
            {
                foreach (string xx in errorx.Value)
                {
                    lista += xx + " ";
                }
            }
            return lista;

            
        }
    }
}