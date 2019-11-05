using isp.platformb2b.data.DatabaseModels;
using isp.platformb2b.models.DTOs;
using isp.platformb2b.models.entities;
using isp.platformb2b.models.UnitOfWork;
using isp.platformb2b.web.entities;
using isp.platformb2b.web.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace isp.platformb2b.web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class MasterTablesController : ControllerBase
    {
        private readonly IServiceMasterTables _iserviceMasterTables;

        public MasterTablesController (IServiceMasterTables iserviceMasterTables)
        {
            _iserviceMasterTables = iserviceMasterTables;
        }

        //[Authorize(Roles = "cli-adm,prov-adm")]
        [HttpGet("currency")]
        public ActionResult currency()
        {
            return Ok(_iserviceMasterTables.getAllTypesCurrency());

        }

        //[Authorize(Roles = "cli-adm,prov-adm")]
        [HttpGet("document")]
        public ActionResult document()
        {
            return Ok(_iserviceMasterTables.getAllTypesDocuments());

        }

        //[Authorize(Roles = "cli-adm,prov-adm")]
        [HttpGet("document/all")]
        public ActionResult documentComplete()
        {
            return Ok(_iserviceMasterTables.getAllTypesDocumentsComplete());

        }

        //[Authorize(Roles = "cli-adm,prov-adm")]
        [HttpGet("detraction/all")]
        public ActionResult DetransactionsComplete()
        {
            return Ok(_iserviceMasterTables.GetAllDetractions());

        }

        //[Authorize(Roles = "cli-adm,prov-adm")]
        [HttpGet("document/serial")]
        public ActionResult GetAllDocumentSerialByTypeDocument()
        {
            return Ok(_iserviceMasterTables.GetAllDocumentSerialByTypeDocument());

        }

        [HttpGet("Rejection")]
        public ActionResult TypesOfReasonsForRejection()
        {
            return Ok(_iserviceMasterTables.getAllReject());
        }

        [HttpGet("document/{id_tipo_documento}")]
        public ActionResult GetTypeOfDocumentByID(string id_tipo_documento)
        {
            return Ok(_iserviceMasterTables.GetTypeOfDocumentByID(id_tipo_documento));
        }

        [HttpGet("enterprise/erp/all")]
        public ActionResult GetTypeEnterpriseERP()
        {
            return Ok(_iserviceMasterTables.GetTypesEnterprisesERP());
        }
    }
}