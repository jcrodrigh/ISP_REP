using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using isp.platformb2b.models.DTOs;
using isp.platformb2b.models.DTOs.documents;

using isp.platformb2b.models.entities;
using isp.platformb2b.models.UnitOfWork;
using isp.platformb2b.web.entities;
using isp.platformb2b.web.Helpers;
using isp.platformb2b.web.Helpers.documents_validation;
using isp.platformb2b.web.Helpers.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;

namespace isp.platformb2b.web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IServiceDocument _iserviceDocument;
        private readonly IServicePurcharseOrder _iservicePurcharseOrder;
        private readonly IServiceMasterTables _iServiceMasterTables;
        private readonly IServiceEnterprise _iServiceEnterprise;
        private readonly Verify _verify;
        private IOptions<CredencialSmtp> _isetting;


        IDocumentValidatorService _iDocumentValidatorService;

        public DocumentController(
            IHostingEnvironment hostingEnvironment,
            IServiceDocument iserviceDocument,
            IServicePurcharseOrder iservicePurcharseOrder,
            IServiceMasterTables iServiceMasterTables,
            IServiceEnterprise iServiceEnterprise,
            IDocumentValidatorService iDocumentValidatorService,
            IOptions<CredencialSmtp> isetting
            )
        {
            _isetting = isetting;
            _iserviceDocument = iserviceDocument;
            _iservicePurcharseOrder = iservicePurcharseOrder;
            _iServiceMasterTables = iServiceMasterTables;
            _iServiceEnterprise = iServiceEnterprise;
            _hostingEnvironment = hostingEnvironment;

            _iDocumentValidatorService = iDocumentValidatorService;

            _verify = new Verify(_iserviceDocument, _iservicePurcharseOrder, _iServiceMasterTables, _iServiceEnterprise);
        }

        /*
                [HttpPost("insert")]
                public ActionResult InsertDocument(models.DTOs. new_document)
                {
                    try
                    {
                        Dictionary<string, List<string>> DictErrores = new Dictionary<string, List<string>>();
                        _verify.verify_document(new_document, ref DictErrores);

                        if (DictErrores.Count() == 0)
                        {
                            return Ok(new_document);
                        }
                        else
                        {
                            return BadRequest(DictErrores);
                        }



                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

        */
        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(IFormFile file)
        {


            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            if (file.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }


            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { filePath });
        }

        [AllowAnonymous]
        [HttpGet("getTemplate")]
        public IActionResult DownloadFile()
        {
            //var filePath = "C:\\Users\\Ingrid\\Desktop\\plantalla ivm.xlsx";

            string folderName = "Utilitarios";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string ExcelsPath = Path.Combine(webRootPath, folderName);

            string filePath = Path.Combine(ExcelsPath, "plantilla ivm.xlsx");

            if (filePath == null) return NotFound();

            return PhysicalFile(filePath, MimeTypes.GetMimeType(filePath), Path.GetFileName(filePath));
        }


        [AllowAnonymous]
        [HttpGet("getTemplate/{id_file}")]
        public IActionResult DownloadFile(string id_file)
        {
            string folderName = "Excel";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string ExcelsPath = Path.Combine(webRootPath, folderName);

            string filePath = Path.Combine(ExcelsPath, id_file);

            if (filePath == null) return NotFound();

            return PhysicalFile(filePath, MimeTypes.GetMimeType(filePath), Path.GetFileName(filePath));
        }

        #region Export

        [HttpPost("Export/provider")]
        public IActionResult ExportDataByProvider(DocumentFilter filter)
        {
            string filePath;
            filter.ruc_empresa_proveedor = new string[] { User.Identity.Name };
            List<Document> doc = _iserviceDocument.filtrable(filter);

            string folderName = "Utilitarios";

            create_excel _xls = new create_excel(_hostingEnvironment);

            filePath = _xls.crearExcel(doc);
            return PhysicalFile(filePath, MimeTypes.GetMimeType(filePath), Path.GetFileName(filePath));
        }


        [HttpPost("Export/ivm")]
        public ActionResult ExportDataIVM(DocumentFilter filter)
        {
            ResultMessage<FileDocument> resultMessage = new ResultMessage<FileDocument>();

            try
            {
                FileDocument resultado = new FileDocument();
                List<DocumentGestion> listdoc = _iserviceDocument.filtrableGestion(filter);
                create_excel _xls = new create_excel(_hostingEnvironment);

                resultMessage = _xls.crearExcelDocumentoGestion(listdoc);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                resultMessage.Code = 1;
                resultMessage.Message = string.Concat(exception.Message, " ", exception.StackTrace);
            }

            return Ok(resultMessage);
        }


        #endregion
        /*
        [HttpGet("GetDocumentBetweenClientAndProviders/{ruc_empresa_cliente}/{ruc_empresa_proveedor}")]
        public ActionResult GetDocumentBetweenClientAndProviders (string ruc_empresa_cliente, string ruc_empresa_proveedor)
        {
            return Ok(_iserviceDocument.
                GetDocumentBetweenClientAndProviders
                    (ruc_empresa_cliente, 
                    ruc_empresa_proveedor));
        }*/


        [HttpPost("cargamasiva")]
        public ActionResult cargamasiva([FromBody] Document[] newDocument) 
        {
            var resultado = _iserviceDocument.InsertNewDocumentMasivo(newDocument, User.Identity.Name);
            return Ok(resultado);
        } 


        [HttpPost("webiando")]
        public ActionResult insertDocument([FromBody] documentDTO newDocument)
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            /*var sid = identity.Claims.Where(c => c.Type == ClaimTypes.Sid)
                   .Select(c => c.Value).SingleOrDefault();*/

            var sid = User.Claims.Where(c => c.Type == ClaimTypes.Sid)
                   .Select(c => c.Value).SingleOrDefault();

            newDocument.ruc_empresa_proveedor = User.Identity.Name;
            _iDocumentValidatorService.setDocument(newDocument);
            ValDocuments valDoc = new ValDocuments(_iDocumentValidatorService);
            var errores = valDoc.verificador();

            if (errores.Count() > 0)
            {
                return BadRequest( new { errors = errores  });
                //return new HttpStatusCodeResult(400,);
            }
            else
            {
                newDocument = _iDocumentValidatorService.getMaskedDocument();
                var doc = _iserviceDocument.InsertNewDocument(newDocument, User.Identity.Name,sid);
                /*
                var errores = valDocumentsx.verificador();
                if (errores.Count()==0)
                {
                    _iserviceDocument.InsertNewDocument(newDocument,User.Identity.Name);
                    return Ok(newDocument);
                }
                return BadRequest(new { errors = errores });
                */

                return Ok(doc);
            }
            //pasamos los servicios 
            


            
        }

        [AllowAnonymous]
        [HttpPost("InsertByXML")]
        public ActionResult insertDTObyXML ([FromBody] documentDTO newDocument)
        {
            _iDocumentValidatorService.setDocument(newDocument);
            ValDocuments valDoc = new ValDocuments(_iDocumentValidatorService);

            var errores = valDoc.verificador(); 
            if (errores.Count() == 0)
            {
                
                newDocument = _iDocumentValidatorService.getMaskedDocument();
                _iserviceDocument.InsertNewDocument(newDocument,"", "By Email");
                return Ok(newDocument);
            }
            else
            {
                _iserviceDocument.InsertErrorDocument(newDocument, errores);
                return BadRequest(new { errors = errores });
            }
            
        }

        /*
        [AllowAnonymous]
        [HttpPost("ProbandoAuditoria")]
        public ActionResult insertDTObyXML([FromBody] documentDTO newDocument)
        {
            _iserviceDocument.InsertNewDocument(newDocument, "By Email");
        }*/

        [HttpGet("GetDocumentByID/{id_interno}")]
        public ActionResult GetDocumentByInternalId(int id_interno)
        {
            var temp = _iserviceDocument.GetDocumentByInternalId(id_interno);
            return Ok(temp);
        }


        [HttpPost("imagenx")]
        [DisableRequestSizeLimit]

        public ActionResult UploadImagesWithoutDocument (IList<IFormFile> files)
        {

            files = HttpContext.Request.Form.Files.ToList();

            List<string> url_imagen = new List<string>();
            foreach (var file in files)
            {
                string namefile = this.NewFileImageName(file);
                string fullname = this.FullPathImagen(namefile);
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(fullname, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        url_imagen.Add(namefile);

                    }
                }
            }
           
            return Ok(url_imagen);


        }

        

        [HttpPost("imagen/insert/{id_file}")]
        [DisableRequestSizeLimit]
        public ActionResult UpdateImage(IList<IFormFile> files,int id_file)
        {
            var doc = _iserviceDocument.GetDocumentByInternalId(id_file);
            if (doc == null) return BadRequest(new { errors = "No se encuentra ese documento." });

            foreach (var file in files)
            {
                string namefile = this.NewFileImageName(file);
                string fullname = this.FullPathImagen(namefile);
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(fullname, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        var temp = doc.url_imagen.ToList();
                        temp.Add(namefile);
                        doc.url_imagen = temp.ToArray(); 

                    }
                }
            }
            _iserviceDocument.UpdateDcoument(doc);
            return Ok(doc.url_imagen);
        }
        
        [HttpDelete("imagen/delete/{id_file}/{namefile}")]
        public ActionResult DeleteImage (int id_file, string namefile)
        {
            var doc = _iserviceDocument.GetDocumentByInternalId(id_file);
            if (doc == null) return BadRequest(new { errors = "No se encontró el documento." });

            var temp = doc.url_imagen.ToList();
            temp.Remove(namefile);
            doc.url_imagen = temp.ToArray();
            _iserviceDocument.UpdateDcoument(doc);
            if (System.IO.File.Exists(FullPathImagen(namefile)))
            {
                System.IO.File.Delete(FullPathImagen(namefile));
                
            }

            return Ok(doc.url_imagen);

        }

        [HttpDelete("imagen/delete/{namefile}")]
        public ActionResult DeleteImageWithouDocument( string namefile)
        {
           
            if (System.IO.File.Exists(FullPathImagen(namefile)))
            {
                System.IO.File.Delete(FullPathImagen(namefile));
            }

            return Ok();

        }

        [HttpGet("WithoutImage")]
        public ActionResult GetDocumentWithoutImage()
        {
            var docx = _iserviceDocument.DocumentsWithoutImage(User.Identity.Name);
            return Ok(docx);
        }

        [AllowAnonymous]
        [HttpGet("imagen/{id_file}")]
        public IActionResult dowmloadImage(string id_file)
        {
            //var filePath = @"C:\Users\Ingrid\Desktop\isp.platformb2b\isp.platformb2b\isp.platformb2b.web\wwwroot\Imagenes\"+ id_file;
            string folderName = "Imagenes";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string ExcelsPath = Path.Combine(webRootPath, folderName);

            string filePath = Path.Combine(ExcelsPath, id_file);

            if (filePath == null) return NotFound();

            return PhysicalFile(filePath, MimeTypes.GetMimeType(filePath), Path.GetFileName(filePath));
        }


        

       

        [HttpGet("Client/{ruc_client}")]
        public List<Document> GetAllDocumentsByClient (string ruc_client)
        {
            return _iserviceDocument.GetDocumentByRucClient(ruc_client);
        }

        [HttpGet("GetDocumentsByRucProvider")]
        public List<Document> GetDocumentByRucProvider()
        {
            return _iserviceDocument.DocumentWithQuery(new int[] { }, new string[] { }, new string[] { User.Identity.Name });
            //return _iserviceDocument.GetDocumentByRucProvider(User.Identity.Name);
        }

        [HttpGet("errors/all")]
        public List<ErrorsByDocument> GetDocumentWithError()
        {
           return  _iserviceDocument.GetDocumentWithError();
        }

        [HttpGet ("errors/export")]
        public ActionResult export_error ()
        {
            var temp = _iserviceDocument.GetDocumentWithError();
            
            export_errors error = new export_errors(_hostingEnvironment);
            string filePath = error.mecmec(temp);

            

            if (filePath == null) return NotFound();

            return PhysicalFile(filePath, MimeTypes.GetMimeType(filePath), Path.GetFileName(filePath));
            
        }


        [HttpGet("query")]
        public ActionResult Queriable([FromQuery] int [] id_tipo_documento_estado, 
                                        [FromQuery] string[] ruc_empresa_cliente)
        {
            var temp = _iserviceDocument.DocumentWithQuery(id_tipo_documento_estado,
                ruc_empresa_cliente,new string[] { });
            return Ok(temp);
        }

        [HttpPost("filter/provider")]
        public ActionResult<Document> FiltrableProvider ([FromBody] DocumentFilter filter)
        {
            
            filter.ruc_empresa_proveedor = new string[] { User.Identity.Name };
            var temp = _iserviceDocument.filtrable(filter);
            return Ok(temp);

        }

        [HttpPost("filter/cliente")]
        public ActionResult<Document> FiltrableClient([FromBody] DocumentFilter filter)
        {

            filter.ruc_empresa_proveedor = new string[] { User.Identity.Name };
            var temp = _iserviceDocument.filtrable(filter);
            return Ok(temp);

        }

        [HttpPost("filter/ivm")]
        public ActionResult<Document> FiltrableIVM([FromBody] DocumentFilter filter)
        {
            var temp = _iserviceDocument.filtrable(filter);
            return Ok(temp);
        }


        [HttpPost("filter/ivmgestion")]
        public ActionResult<DocumentGestion> FiltrableIVMGestion([FromBody] DocumentFilter filter)
        {
            var temp = _iserviceDocument.filtrableGestion(filter);
            return Ok(temp);
        }


        private string PathImagen ()
        {
            string imagenes = "Imagenes";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, imagenes);

            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }

            return newPath;
        }

        private string NewFileImageName (IFormFile file)
        {
            Random rnd = new Random();
            string nameFile = this.User.Identity.Name + DateTime.Now.ToString("yyyyMMddHHmmss") + rnd.Next(10000, 99999).ToString();

            string sFileExtension = Path.GetExtension(file.FileName).ToLower();

            return  nameFile + sFileExtension;
        }

        private string FullPathImagen (string namefile)
        {
            return Path.Combine(PathImagen(), namefile);
        }


        [HttpGet("file/createftp/{namefile}/{tipodocumento}")]
        public ActionResult<string> createftp(string namefile,string tipodocumento) 
        {
            ResultMessage<FileDocument> resultMessage = new ResultMessage<FileDocument>();

            try
            {
                FileDocument resultado = new FileDocument();
                documento_sftp sftp = new documento_sftp(_hostingEnvironment,_isetting);
                resultMessage = sftp.LecturaArchivoSfp(namefile, tipodocumento);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                resultMessage.Code = 1;
                resultMessage.Message = string.Concat(exception.Message, " ", exception.StackTrace);
            }
            return Ok(resultMessage);
        }

    }
}