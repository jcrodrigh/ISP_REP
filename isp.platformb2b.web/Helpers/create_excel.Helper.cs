using isp.platformb2b.models.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using OfficeOpenXml;
using Microsoft.AspNetCore.Hosting;
using isp.platformb2b.web.entities;
using isp.platformb2b.web.Helpers.Enumerator;

namespace isp.platformb2b.web.Helpers
{
    public class create_excel
    {
        private IHostingEnvironment _hostingEnvironment;
        public create_excel(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public string crearExcel(List<Document> listdoc)
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;
            object misvalue = System.Reflection.Missing.Value;

            string nombre_file = DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            string localFullPath;

            using (ExcelPackage excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("Worksheet1");

                var headerRow = new List<string[]>()
                {
                  new string[] { "Estado","Usuario", "ID","Tipo Doc.", "N° Serie", "N° Comprob. Pago",
                    "RUC Cliente", "Nombre Cliente", "Mon","Monto Total"
                 }

                };

                #region estilos
                // Determine the header range (e.g. A1:D1)
                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";
                // Target a worksheet
                var worksheet = excel.Workbook.Worksheets["Worksheet1"];
                // Popular header row data
                worksheet.Cells[headerRange].LoadFromArrays(headerRow);
                worksheet.Cells[headerRange].Style.Font.Bold = true;
                worksheet.Cells[headerRange].Style.Font.Size = 11;
                worksheet.Cells[headerRange].Style.Font.Name = "Calibri";
                worksheet.Cells[headerRange].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[headerRange].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                worksheet.Cells[headerRange].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.DarkBlue);
                #endregion

                int i = 2;
                foreach (var doc in listdoc)
                {

                    worksheet.Cells[i, 1].Value = document_enumerator.tipo_documento_estado(doc.id_tipo_documento_estado);
                    worksheet.Cells[i, 2].Value = "--";
                    worksheet.Cells[i, 3].Value = doc.id_interno;
                    worksheet.Cells[i, 4].Value = doc.id_tipo_documento;
                    worksheet.Cells[i, 5].Value = doc.num_serie;
                    worksheet.Cells[i, 6].Value = doc.id_tipo_documento;
                    worksheet.Cells[i, 7].Value = doc.ruc_empresa_cliente;
                    worksheet.Cells[i, 8].Value = doc.razon_social_cliente;
                    worksheet.Cells[i, 9].Value = doc.id_tipo_moneda;
                    worksheet.Cells[i, 10].Value = doc.monto_total;
                    worksheet.Cells[i, 10].Style.Numberformat.Format = "#,##0.00";
                    i++;
                }

                localFullPath = CreatePath(nombre_file);
                FileInfo excelFile = new FileInfo(localFullPath);
                excel.SaveAs(excelFile);
            }

            return localFullPath;
        }

        public ResultMessage<FileDocument> crearExcelDocumentoGestion(List<DocumentGestion> listdoc)
        {
            ResultMessage<FileDocument> _resultado = new ResultMessage<FileDocument>();
            FileDocument _filedocument = new FileDocument();

            string nombre_file = DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            string localFullPath=string.Empty;

            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;
            object misvalue = System.Reflection.Missing.Value;

            String AsBase64String = string.Empty;


            try {

                using (ExcelPackage excel = new ExcelPackage())
                {
                    excel.Workbook.Worksheets.Add("Worksheet1");

                           var headerRow = new List<string[]>()
                            {
                              new string[] { "Estado", "ID", "Tipo Doc.", "N° Serie",
                                "N° Comprob. Pago", "Fecha Emisión", "Ref. Serie Fact. Origen",
                                 "Ref. N° Fact. Origen","Mon.","Valor Venta","Valor Inafecto",
                                  "ISC","% IGV","Cuota Impuesto","Monto Total","RUC Proveedor",
                                  "Nombre Proveedor", "N° PO/OC", "N° Conformidad", "RUC Sociedad",
                                  "Nombre Cliente","CECO","ORDEN","Detraccion","FA Negociable",
                                  "Tipo Emision","Usuario Escaneo","Fecha Escaneo","Hora Escaneo",
                                  "Fecha Recepcion","Usuario Verificador","Fecha Verificador","Hora Verificador",
                                  "Fecha Transferencia","Cod. CIIU","Nombre CIIU","Acreedor",
                                  "Fecha contabilización","N° Asiento Contable","Periodo","Mes"
                              }

                            };

                    // Determine the header range (e.g. A1:D1)
                    string headerRange = "A1:AO1";
                    // Target a worksheet
                    var worksheet = excel.Workbook.Worksheets["Worksheet1"];
                    // Popular header row data
                    worksheet.Cells[headerRange].LoadFromArrays(headerRow);
                    worksheet.Cells[headerRange].Style.Font.Bold = true;
                    worksheet.Cells[headerRange].Style.Font.Size = 11;
                    worksheet.Cells[headerRange].Style.Font.Name = "Calibri";
                    worksheet.Cells[headerRange].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    worksheet.Cells[headerRange].Style.Font.Color.SetColor(System.Drawing.Color.White);
                    worksheet.Cells[headerRange].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[headerRange].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.DarkBlue);

                    int i = 2;
                    foreach (var doc in listdoc)
                    {
                        worksheet.Cells[i, 1].Value = doc.tipo_documento_estado;
                        worksheet.Cells[i, 2].Value = doc.id_interno;
                        worksheet.Cells[i, 3].Value = doc.id_tipo_documento;
                        worksheet.Cells[i, 4].Value = doc.num_serie;
                        worksheet.Cells[i, 5].Value = doc.num_correlativo;
                        worksheet.Cells[i, 6].Value = doc.fecha_emision.ToString("dd/MM/yyyy");
                        worksheet.Cells[i, 7].Value = doc.factura_origen_serie;
                        worksheet.Cells[i, 8].Value = doc.factura_origen_correlativo;
                        worksheet.Cells[i, 9].Value = doc.id_tipo_moneda;

                        worksheet.Cells[i, 10].Value = doc.monto_subtotal_afecto;
                        worksheet.Cells[i, 10].Style.Numberformat.Format = "#,##0.00";

                        worksheet.Cells[i, 11].Value = doc.monto_subtotal_inafecto;
                        worksheet.Cells[i, 11].Style.Numberformat.Format = "#,##0.00";

                        worksheet.Cells[i, 12].Value = doc.monto_isc;
                        worksheet.Cells[i, 12].Style.Numberformat.Format = "#,##0.00";

                        worksheet.Cells[i, 13].Value = doc.iva;

                        worksheet.Cells[i, 14].Value = doc.monto_igv;
                        worksheet.Cells[i, 14].Style.Numberformat.Format = "#,##0.00";

                        worksheet.Cells[i, 15].Value = doc.monto_total;
                        worksheet.Cells[i, 15].Style.Numberformat.Format = "#,##0.00";

                        worksheet.Cells[i, 16].Value = doc.ruc_empresa_proveedor;
                        worksheet.Cells[i, 17].Value = doc.razon_social_proveedor;
                        worksheet.Cells[i, 18].Value = doc.id_orden_compra;
                        worksheet.Cells[i, 19].Value = doc.nro_conformidad_oc;//doc.monto_total;
                        worksheet.Cells[i, 20].Value = doc.ruc_empresa_cliente;

                        worksheet.Cells[i, 21].Value = doc.razon_social_cliente;
                        worksheet.Cells[i, 22].Value = !string.IsNullOrEmpty(doc.ceco)? doc.ceco:"--";
                        worksheet.Cells[i, 23].Value = !string.IsNullOrEmpty(doc.orden) ? doc.orden : "--";
                        worksheet.Cells[i, 24].Value = !string.IsNullOrEmpty(doc.id_tipo_detracciones)? doc.id_tipo_detracciones:"N/A";
                        worksheet.Cells[i, 25].Value = doc.factura_negociable.HasValue? (doc.factura_negociable.Value?"SI":"NO"):"N/A";
                        worksheet.Cells[i, 26].Value = (doc.fis_elec) ? "F" : "E";
                        worksheet.Cells[i, 27].Value = "";
                        worksheet.Cells[i, 28].Value = "";
                        worksheet.Cells[i, 29].Value = "";
                        worksheet.Cells[i, 30].Value = doc.fecha_verificacion.ToString("dd/MM/yyyy");

                        worksheet.Cells[i, 31].Value = doc.usuario_verificacion;
                        worksheet.Cells[i, 32].Value = doc.fecha_verificacion.ToString("dd/MM/yyyy");
                        worksheet.Cells[i, 33].Value = doc.hora_verificacion;
                        worksheet.Cells[i, 34].Value = (doc.fecha_transferencia.HasValue)?doc.fecha_transferencia.Value.ToString("dd/MM/yyyy"):""; //HH:mm:ss
                        worksheet.Cells[i, 35].Value = "";
                        worksheet.Cells[i, 36].Value = "";
                        worksheet.Cells[i, 37].Value =  doc.acreedor;
                        worksheet.Cells[i, 38].Value = doc.fecha_contabilizacion!= DateTime.MinValue? doc.fecha_contabilizacion.ToString("dd/MM/yyyy"):"";
                        worksheet.Cells[i, 39].Value = doc.nro_registro_contable;
                        worksheet.Cells[i, 40].Value = doc.fecha_verificacion.ToString("yyyy");

                        worksheet.Cells[i, 41].Value = doc.fecha_verificacion.ToString("MM");

                        i++;
                    }

                    localFullPath = CreatePath(nombre_file);

                    FileInfo excelFile = new FileInfo(localFullPath);
                    excel.SaveAs(excelFile);

                    byte[] AsBytes = File.ReadAllBytes(localFullPath);
                    AsBase64String = Convert.ToBase64String(AsBytes);


                    _filedocument.nombre_file = nombre_file;
                    _filedocument.data = AsBase64String;
                    _filedocument.content_type = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                    _resultado.Content = _filedocument;
                    _resultado.Code = 0;
                    _resultado.Message = "";
                }
            }
            catch (Exception ex)
            {
                _resultado.Code = 1;
                _resultado.Message = ex.ToString();
            }
            finally
            {
                //eliminamos el registro creado en la carpeta temporal
                DeleteFilePath(localFullPath);
            }

            return _resultado;
        }


        private string CreatePath(string nameFile)
        {


            string folderName = "temp";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string pdfPath = Path.Combine(webRootPath, folderName);

            if (!Directory.Exists(pdfPath))
            {
                Directory.CreateDirectory(pdfPath);
            }

            string fullPath = Path.Combine(pdfPath, nameFile);
            return fullPath;
        }

        private void DeleteFilePath(string fullpath)
        {
            //System.IO.FileInfo fi = new System.IO.FileInfo(fullpath);
            System.IO.File.Delete(fullpath);
            //fi.Delete();
        }

    }
}
