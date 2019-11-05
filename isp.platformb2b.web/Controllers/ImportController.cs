using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using Microsoft.AspNetCore.Hosting;
using isp.platformb2b.models.UnitOfWork;

using isp.platformb2b.models.entities;
using Microsoft.AspNetCore.Authorization;
using isp.platformb2b.web.Helpers;


using isp.platformb2b.models.DTOs.documents;
using isp.platformb2b.web.Helpers.Services;
using isp.platformb2b.web.Helpers.documents_validation;
using AutoMapper;
using System.Threading;
using System.Security.Claims;

namespace isp.platformb2b.web.Controllers
{
    [Route("[controller]")]
    [Authorize]
    //[ApiController]
    public class ImportController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;

        private readonly IServiceMasterTables _iServiceMasterTables;

        private readonly IServiceDocument _iserviceDocument;
        private readonly IServicePurcharseOrder _iservicePurcharseOrder;

        private readonly IDocumentValidatorService _iDocumentValidatorService;
        private readonly IMapper _mapper;


        private readonly IServiceEnterprise _iServiceEnterprise;
        private readonly Verify _verify;

        int ok=0;
        int error=0;
        int danger=0;
        List<Document> DocumentsOK = new List<Document>();

       
        string extention = ".xlsx";

        string nameFile; 
        private enum ExcelPosition
        {
            id_tipo_documento = 1, num_serie, num_correlativo, ruc_empresa_cliente, id_orden_compra,
            factura_origen_serie, factura_origen_correlativo, id_tipo_moneda,
            fecha_emision, monto_subtotal_afecto, monto_subtotal_inafecto, monto_isc, monto_igv, monto_total,
            id_tipo_detracciones, factura_negociable, ceco,orden, anticipo
        };


        public ImportController(IHostingEnvironment hostingEnvironment,
            IServiceDocument iserviceDocument,
            IServicePurcharseOrder iservicePurcharseOrder,
            IServiceMasterTables iServiceMasterTables,
            IServiceEnterprise iServiceEnterprise,
            IDocumentValidatorService iDocumentValidatorService)
        {
            _iServiceMasterTables = iServiceMasterTables;
            _hostingEnvironment = hostingEnvironment;
            _iserviceDocument = iserviceDocument;
            _iservicePurcharseOrder = iservicePurcharseOrder;
            _iServiceMasterTables = iServiceMasterTables;
            _iServiceEnterprise = iServiceEnterprise;

            _iDocumentValidatorService = iDocumentValidatorService;

            _verify = new Verify(_iserviceDocument, _iservicePurcharseOrder, _iServiceMasterTables, _iServiceEnterprise);
        }
        // GET: Import
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Post method for importing users 
        /// </summary>
        /// <param name="postedFile"></param>
        /// <returns></returns>
        [HttpPost("import")]
        [DisableRequestSizeLimit]

        public ActionResult OnPostImport(IFormFile file)
        {
           if (file != null)
            {

                string sFileExtension = Path.GetExtension(file.FileName).ToLower();

                if (!sFileExtension.Equals(".xlsx"))
                {
                    return BadRequest(new { errors = "La extensión de la plantilla es XLSX." });
                }


                string fullPath = CreatePath();              

                this.CreateFile(fullPath, file);
                var temp = this.readFileAndGetData(fullPath);
               

                WriteComentariesExcel(temp, fullPath);


            }
            else
            {
                return BadRequest("Debe Adjuntar un archivo");
            }
            return Ok(new
            {
                OkRows = ok,
                ErrorsByRow =error,
                DangerRows = danger,
                filepath = nameFile,
                documents = DocumentsOK
            });
        }

        private int getExcelPostByString(string key)
        {
            try
            {
                return (int)System.Enum.Parse(typeof(ExcelPosition), key);
            }
            catch (Exception err)
            {
                return -1;
            }

        }

        //ObtenerMapperDocument   --nuevo
        private Document ObtenerMapperDocument(documentDTO new_document)
        {
            return _iserviceDocument.ObtenerMapperDocument(new_document);
        }

        //


        private Document InsertDocument(documentDTO new_document)
        {


            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var sid = identity.Claims.Where(c => c.Type == ClaimTypes.Sid)
                   .Select(c => c.Value).SingleOrDefault();

            return _iserviceDocument.InsertNewDocument(new_document,User.Identity.Name ,sid);
           
        }

        private NPOI.SS.UserModel.IComment GetComment(ISheet sheet, string result)
        {
            
            XSSFDrawing drawing = sheet.CreateDrawingPatriarch() as XSSFDrawing;
            NPOI.SS.UserModel.IComment comment1 = drawing.CreateCellComment(new XSSFClientAnchor(0, 0, 0, 0, 10, 3, 12, 6));
            // set text in the comment
            comment1.String = (new XSSFRichTextString(result));

            //set comment author.
            //you can see it in the status bar when moving mouse over the commented cell
            comment1.Author = ("IVM");
            return comment1;
            

        }

        private string CreatePath()
        {
            

            string folderName = "Excel";
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
            
            
            nameFile = User.Identity.Name + DateTime.Now.ToString("yyyyMMddHHmmss") + this.extention;
            string fullPath = Path.Combine(ExcelsPath, nameFile);
            return fullPath;
        }


        public void CreateFile(string fullPath, IFormFile file)
        {
            using (var streamx = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(streamx);
                streamx.Close();
            }
        }

        public Dictionary<int, documentDTO> readFileAndGetData(string fullPath)
        {
            IWorkbook templateWorkbook;
            ISheet sheet;

            using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
            {
                //file.CopyTo(stream);
                stream.Position = 0;
                templateWorkbook = new XSSFWorkbook(stream); 
                XSSFFormulaEvaluator.EvaluateAllFormulaCells(templateWorkbook);
                sheet = templateWorkbook.GetSheetAt(0);
                return ConvertRowExceltoDTO(sheet);
                stream.Close();
            }
        }

        

        private void WriteComentariesExcel(Dictionary<int, documentDTO> dict,string url)
        {
            XSSFWorkbook xssfwb;
            using (FileStream file = new FileStream(url, FileMode.Open, FileAccess.ReadWrite))
            {
                xssfwb = new XSSFWorkbook(file);
                file.Close();
            }

            ISheet sheet = xssfwb.GetSheetAt(0);
            IRow row = sheet.GetRow(0);
            ICellStyle OkStyle;
            ICellStyle ErrorStyle;
            ICellStyle DangerStyle;

            ErrorStyle = xssfwb.CreateCellStyle();
            ErrorStyle.FillForegroundColor = IndexedColors.Gold.Index;
            ErrorStyle.FillPattern = FillPattern.SolidForeground;

            OkStyle = xssfwb.CreateCellStyle();
            OkStyle.FillForegroundColor = IndexedColors.SeaGreen.Index;
            OkStyle.FillPattern = FillPattern.SolidForeground;

            DangerStyle = xssfwb.CreateCellStyle();
            DangerStyle.FillForegroundColor = IndexedColors.Red.Index;
            DangerStyle.FillPattern = FillPattern.SolidForeground;

            documentDTO doc;
            foreach (KeyValuePair<int, documentDTO> kv in dict)
            {
                row = sheet.GetRow(kv.Key);
                try
                {                   
                    doc = kv.Value;

                    //validator
                    _iDocumentValidatorService.setDocument(doc);
                    ValDocuments valDoc = new ValDocuments(_iDocumentValidatorService);
                    var errores = valDoc.verificador();

                    if (errores.Count() > 0)
                    {
                        //banderita :V
                        ICell cellIndex = row.GetCell(0) ?? row.CreateCell(0);
                        cellIndex.CellStyle = ErrorStyle;

                        foreach (KeyValuePair<string, List<string>> errorsByCells in errores)
                        {
                            int pos_cells = getExcelPostByString(errorsByCells.Key);

                            if (pos_cells >= 0)
                            {
                                var result = String.Join(". ", errorsByCells.Value.ToArray());
                                ICell cell = row.GetCell(pos_cells) ?? row.CreateCell(pos_cells);

                                ICellStyle tempStyle = ErrorStyle;
                                IComment tempComment = GetComment(sheet, result);
                                cell.CellComment = tempComment;
                                cell.CellStyle = tempStyle;
                                error += 1;
                            }
                        }
                    }
                    else
                    {
                        doc = _iDocumentValidatorService.getMaskedDocument();


                        //var docOK = InsertDocument(doc);
                        var docOK = ObtenerMapperDocument(doc);

                        ICell cell = row.GetCell(0) ?? row.CreateCell(0);
                        cell.CellStyle = OkStyle;
                        DocumentsOK.Add(docOK);
                        ok += 1;
                        
                    }

                }
                catch (Exception error)
                {
                    ICell cell = row.GetCell(0) ?? row.CreateCell(0);
                    cell.CellStyle = DangerStyle;
                    danger += 1;
                }
               
            }

            using (FileStream file = new FileStream(url, FileMode.Create, FileAccess.Write))
            {
                xssfwb.Write(file);
                file.Close();
            }


        }

        public Dictionary<int,documentDTO> ConvertRowExceltoDTO (ISheet sheet)
        {
            documentDTO docx;
            IRow row;
            Dictionary<int, documentDTO> dict = new Dictionary<int, documentDTO>();
            #region Read Excel File
            int n = (sheet.LastRowNum >= 500) ? sheet.LastRowNum : 500;
            for (int i = (sheet.FirstRowNum + 2); i <= n; i++) //Read Excel File
            {
                row = sheet.GetRow(i);
                if (row == null) continue;
                if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;

                
                decimal total_amount_affected = getAmount(row.GetCell((int)ExcelPosition.monto_subtotal_afecto));
                decimal total_amount_unaffected = getAmount(row.GetCell((int)ExcelPosition.monto_subtotal_inafecto));

                docx = new documentDTO()
                {

                    num_serie = getString(row.GetCell((int)ExcelPosition.num_serie)),
                    num_correlativo = getString(row.GetCell((int)ExcelPosition.num_correlativo)),
                   
                    id_tipo_documento = getString(row.GetCell((int)ExcelPosition.id_tipo_documento)).Split('-')[0],
                    id_orden_compra =(getString(row.GetCell((int)ExcelPosition.id_orden_compra)).Equals("") ?
                                        "--" : row.GetCell((int)ExcelPosition.id_orden_compra).ToString()),
                    ruc_empresa_cliente = getString(row.GetCell((int)ExcelPosition.ruc_empresa_cliente)),
                    ceco = (!getString(row.GetCell((int)ExcelPosition.ceco)).Equals("") ? getString(row.GetCell((int)ExcelPosition.ceco)):"--"),
                    orden = (!getString(row.GetCell((int)ExcelPosition.orden)).Equals("") ? getString(row.GetCell((int)ExcelPosition.orden)) : "--"),
                    factura_negociable = (string.IsNullOrEmpty(getString(row.GetCell((int)ExcelPosition.factura_negociable))) ? null : (Boolean?)
                        (getString(row.GetCell((int)ExcelPosition.factura_negociable)).Equals("SI")? true:false)),
                    fecha_emision = getDate(row.GetCell((int)ExcelPosition.fecha_emision)),     //Convert.ToDateTime(row.GetCell((int)ExcelPosition.fecha_emision).ToString()),
                    
                    id_tipo_detracciones = getString(row.GetCell((int)ExcelPosition.id_tipo_detracciones)).Split('-')[0].Trim() ,

                    id_tipo_moneda = getString(row.GetCell((int)ExcelPosition.id_tipo_moneda)),
                    /*monto_subtotal_afecto = total_amount_affected,
                    monto_subtotal_inafecto = total_amount_unaffected,
                    monto_igv = Math.Round(total_amount_affected * (decimal).18, 2),
                    monto_isc = 
                    monto_total = Math.Round(total_amount_affected * (decimal)1.18, 2) + total_amount_unaffected,*/
                    
                    factura_origen_serie = getString(row.GetCell((int)ExcelPosition.factura_origen_serie)),
                    factura_origen_correlativo = getString(row.GetCell((int)ExcelPosition.factura_origen_correlativo)),
                    
                    monto_subtotal_afecto = getAmount(row.GetCell((int)ExcelPosition.monto_subtotal_afecto)),
                    monto_subtotal_inafecto = getAmount(row.GetCell((int)ExcelPosition.monto_subtotal_inafecto)),
                    monto_isc = getAmount(row.GetCell((int)ExcelPosition.monto_isc).NumericCellValue),
                    monto_igv = getAmount(row.GetCell((int)ExcelPosition.monto_igv).NumericCellValue),
                    monto_total = getAmount(row.GetCell((int)ExcelPosition.monto_total).NumericCellValue),

                    nombre_documento_excel = nameFile,
                    url_imagen = new string []{},

                    //id_tipo_documento_estado = 1,
                    ruc_empresa_proveedor = User.Identity.Name,
                    fis_elec = true,
                    
                    



                };

                
                dict.Add(i, docx);
                
            }

            return dict;

            #endregion
        }

        
       

        #region Methods for get many value if it has error

        private decimal getAmount(object amount)
        {
            if (amount != null)
            {
                decimal number;
                if (decimal.TryParse(amount.ToString(), out number))
                {
                    return number;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        private string getString(object str)
        {
            if (str != null)
            {
                if (!string.IsNullOrEmpty(str.ToString()))
                {
                    return str.ToString();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        private DateTime getDate(object date)
        {
            if (date != null)
            {
                DateTime dt;
                if (DateTime.TryParse(date.ToString(), out dt))
                {
                    return dt;
                }
                else
                {
                    return new DateTime();
                }
            }
            else
            {
                return new DateTime();
            }
        }
        #endregion


    }
}