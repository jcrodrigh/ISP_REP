using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isp.platformb2b.models.entities;
using isp.platformb2b.models.Helpers;
using isp.platformb2b.models.UnitOfWork;
using isp.platformb2b.web.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace isp.platformb2b.web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DocumentStatusController : ControllerBase
    {
        IServiceDocument _iserviceDocument;
        IServicePurcharseOrder _iservicePurcharseOrder;
        public DocumentStatusController(IServiceDocument iserviceDocument,
            IServicePurcharseOrder iservicePurcharseOrder)
        {
            _iserviceDocument = iserviceDocument;
            _iservicePurcharseOrder = iservicePurcharseOrder;
        }
            
        public IActionResult ApproveDocument(string ruc_empresa_proveeedor, string id_tipo_documento, string id_documento)
        {
            Document doc = _iserviceDocument.getDocumentByID(ruc_empresa_proveeedor, id_tipo_documento, id_documento);
            if (doc == null)
            {
                return BadRequest(new { error = new { id_documento ="No se encuentra el documento el la base de datos." } });
            }
            return Ok();

            
        }
        

    }
}