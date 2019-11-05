using System;
using System.Collections.Generic;
using System.Xml.Serialization;
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
using MimeKit;
using System.IO;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace isp.platformb2b.web.Controllers
{
    [Authorize]
    //[ApiController]
    [Route("[controller]")]
    public class EnterpriceController : Controller
    {
        private readonly IServiceEnterprise _iserviceEnterprise;

        private readonly IHostingEnvironment _hostingEnvironment;

        private readonly IServiceMasterTables _iserviceMasterTables;

        public EnterpriceController(IServiceEnterprise iserviceEnterprice,
            IHostingEnvironment hostingEnvironment,
            IServiceMasterTables iserviceMasterTables)
        {
            _iserviceEnterprise = iserviceEnterprice;
            _hostingEnvironment = hostingEnvironment;
            _iserviceMasterTables = iserviceMasterTables;

        }

        [Authorize(Roles = "cliente,proveedor")]
        [HttpGet]
        public ActionResult Index()
        {
            return Ok(this.User.Identity.Name);
            //return Json(_iserviceEnterprice.GetAllEnteprices());
        }


        [HttpGet("client")]
        public List<Enterprise> olenka()
        {
            return _iserviceEnterprise.getAllClientsBySupplier(User.Identity.Name);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public EnterpriseRegister auth([FromBody]Login_enterprise logEnt)
        {
            return this._iserviceEnterprise.Authenticate(logEnt.ruc, logEnt.password);

        }

        [HttpGet("provider")]
        public Enterprise GetEnterpriseBySesion()
        {
            return _iserviceEnterprise.getEnterpriseById(this.User.Identity.Name);
        }

        [HttpGet("ruc/{ruc_empresa}")]
        public Enterprise GetEnterpriseByRuc(string ruc_empresa)
        {
            return _iserviceEnterprise.getEnterpriseById(ruc_empresa);
        }
        [HttpGet("getDataBasic")]
        public ActionResult GetDataBasicEnterprise()
        {
            return Ok(_iserviceEnterprise.GetDataBasicEnterprise());
        }

        [HttpGet("GetDataBasicProviderByClient/{ruc_empresa_cliente}")]
        public List<DataBasicEnterprise> GetDataBasicProviderByClient(string ruc_empresa_cliente)
        {
            return _iserviceEnterprise.GetDataBasicProviderByClient(ruc_empresa_cliente);
        }

        [AllowAnonymous]
        [HttpGet("imagen/{id_file}")]
        public IActionResult dowmloadImage(string id_file)
        {


            string webRootPath = _hostingEnvironment.WebRootPath;
            string folderName = "logos";
            string newPath = Path.Combine(webRootPath, folderName);
            string fullPath = Path.Combine(newPath, id_file);
            if (fullPath == null) return NotFound();
            return PhysicalFile(fullPath, MimeTypes.GetMimeType(fullPath), Path.GetFileName(fullPath));
        }

        [HttpGet("ActivesClients")]
        public ActionResult GetActivesClients()
        {
            return Ok(_iserviceEnterprise.GetAllActivesClients());
        }

        [HttpGet("ActivesProviders")]
        public ActionResult GetActivesProviders()
        {
            return Ok(_iserviceEnterprise.GetAllActivesProviders());
        }

        [HttpPost("create/client")]
        public ActionResult CreateNewClient([FromBody]enterpriceDTO new_enterprise)
        {
            var validationContext = new ValidationContext(new_enterprise);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(new_enterprise, validationContext, validationResults, true);

            if (isValid)
            {
                var ent = _iserviceEnterprise.getEnterpriseById(new_enterprise.ruc_empresa);
                var teERP = _iserviceMasterTables.GetTypeEnterpriseERPByID(new_enterprise.id_tipo_empresa_erp);

                var errores = new Dictionary<string, List<string>>();
                if (ent != null) errores.Add("ruc_empresa", new List<string>() { "El RUC de esa empresa ya está creado." });
                if (teERP.Equals(default(KeyValuePair<int, string>)))
                    errores.Add("id_tipo_empresa_erp", new List<string>() { "Ese ERP no existe en nuestra base de datos." });

                if (errores.Count() > 0)
                {
                    return BadRequest(new { errors = errores });
                }
                var entx = _iserviceEnterprise.CreateEnterpricesClient(new_enterprise);
                return Ok(entx);
            }
            else
            {

                var errorList = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

                /*var errores = new Dictionary<string, List<string>>();
                foreach (var temp in ModelState)
                {
                    var lista = new List<string>();
                    foreach (var list in temp.Value.Errors)
                    {
                        lista.Add(list.ErrorMessage);
                    }
                    errores.Add(temp.Key, lista);
                }*/
                //var errores = new { errors = temp };
                return BadRequest(new { errors = errorList });
            }
        }

        [HttpPut("")]
        public ActionResult UpdateEnterprise([FromBody]enterpriceDTO new_enterprise)
        {

            var validationContext = new ValidationContext(new_enterprise);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(new_enterprise, validationContext, validationResults, true);
            if (isValid)
            {
                var ent = _iserviceEnterprise.getEnterpriseById(new_enterprise.ruc_empresa);
                if (ent == null) return Ok(null);
                var temp = _iserviceEnterprise.UpdateEnterprise(new_enterprise);
                return Ok(temp);
            }
            else
            {
                var errorList = ModelState
              .Where(x => x.Value.Errors.Count > 0)
              .ToDictionary(
                  kvp => kvp.Key,
                  kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
              );


                return BadRequest(new { errors = errorList });
            }
        }

        [HttpPut("client/active/{ruc_empresa}")]
        public ActionResult ActiveClient(string ruc_empresa)
        {
            _iserviceEnterprise.ActiveClient(ruc_empresa);
            return Ok();
        }

        [HttpPut("client/reject/{ruc_empresa}")]
        public ActionResult RejectClient(string ruc_empresa)
        {
            _iserviceEnterprise.RejectClient(ruc_empresa);
            return Ok();
        }

        [HttpGet("relationbetweenenterprise")]
        public ActionResult getrelationbetweenenterprise()
        {
            var temp = _iserviceEnterprise.getallRelationBetweenEnterprise();
            return Ok();
        }

        [HttpGet("roles/{ruc_enterprise}")]
        public ActionResult getAllRolesByEnterprice(string ruc_enterprise)
        {
            var temp = _iserviceEnterprise.getRolesByRucEnterprice(ruc_enterprise);
            return Ok(temp);
        }

    }
}