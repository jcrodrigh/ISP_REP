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

namespace isp.platformb2b.web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    
    public class PurcharseOrderController : ControllerBase
    {
        private IServicePurcharseOrder _iservicePurchaseOrder;

        public PurcharseOrderController(IServicePurcharseOrder iservicePurcharseOrder)
        {
            _iservicePurchaseOrder = iservicePurcharseOrder;
        }

        [HttpGet("client/{ruc_cliente}")]
        public List<PurcharseOrder> PurcharseOrderBySupplier ( string ruc_cliente)
        {
            return _iservicePurchaseOrder.getAllPurcharseOrderBySupplier(User.Identity.Name, ruc_cliente);
        }

        
    }
}