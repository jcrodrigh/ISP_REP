using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isp.platformb2b.models.DTOs.documents;
using isp.platformb2b.models.entities;
using isp.platformb2b.models.UnitOfWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace isp.platformb2b.web.Controllers
{
    [Route("[controller]")]
    
    public class ElectronicController : ControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;
        private readonly IServiceMasterTables _iServiceMasterTables;
        private readonly IServiceDocument _iserviceDocument;
        private readonly IServicePurcharseOrder _iservicePurcharseOrder;
        private readonly IServiceEnterprise _iServiceEnterprise;
        private readonly IServiceElectronic _iServiceElectronic;



        public ElectronicController(IHostingEnvironment hostingEnvironment,
            IServiceDocument iserviceDocument,
            IServicePurcharseOrder iservicePurcharseOrder,
            IServiceMasterTables iServiceMasterTables,
            IServiceEnterprise iServiceEnterprise,
            IServiceElectronic iServiceElectronic)
        {
            _iServiceMasterTables = iServiceMasterTables;
            _hostingEnvironment = hostingEnvironment;
            _iserviceDocument = iserviceDocument;
            _iservicePurcharseOrder = iservicePurcharseOrder;
            _iServiceMasterTables = iServiceMasterTables;
            _iServiceEnterprise = iServiceEnterprise;
            _iServiceElectronic = iServiceElectronic;
           
        }

        [HttpPut("document/status/totransferred/{id_interno}")]        
        public ActionResult changeToTransferred  (int id_interno)
        {
           
            Document doc =_iServiceElectronic.ToTransferred(id_interno).Result;
            if (doc!= null)
            {
                return Ok(doc);
            }
            else
            {
                return BadRequest("No se encuentra ese id");
            }
        }

        [HttpPut("document/status/ToAccountedFor/{id_interno}")]
        public ActionResult changeToAccountedFor(int id_interno)
        {

            Document doc = _iServiceElectronic.ToAccountedFor(id_interno).Result;
            if (doc != null)
            {
                return Ok(doc);
            }
            else
            {
                return BadRequest("No se encuentra ese id");
            }
        }

        [HttpPut("document/status/ToRejected/{id_interno}")]
        public ActionResult changeToRejected(int id_interno)
        {

            Document doc = _iServiceElectronic.ToRejected(id_interno).Result;
            if (doc != null)
            {
                return Ok(doc);
            }
            else
            {
                return BadRequest("No se encuentra ese id");
            }
        }

        [HttpPut("purcharseOrder/clientamount")]
        public ActionResult UpdateAmountForClient (PurcharseOrder po)
        {
            var pox = _iservicePurcharseOrder.UpdateAmountForClient(po);
            if (pox != null)
            {
                return Ok(pox);
            }
            return BadRequest( "No se encuentra la orden de compra.");
        }

    }
}