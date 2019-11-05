using isp.platformb2b.models.DTOs.documents;
using isp.platformb2b.models.entities;
using isp.platformb2b.models.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace isp.platformb2b.web.Helpers
{
    public  class DocumentHelper : ControllerBase
    {
        protected IServiceDocument _iserviceDocument;
        protected IServicePurcharseOrder _iservicePurcharseOrder;
        protected IServiceMasterTables _iServiceMasterTables;
        protected IServiceEnterprise _iServiceEnterprise;
        protected TypeDocument _typeDocument;
        
        public DocumentHelper(IServiceDocument iserviceDocument,
            IServicePurcharseOrder iservicePurcharseOrder,
            IServiceMasterTables iServiceMasterTables,
                IServiceEnterprise iServiceEnterprise)
        {
            _iserviceDocument = iserviceDocument;
            _iservicePurcharseOrder = iservicePurcharseOrder;
            _iServiceMasterTables = iServiceMasterTables;
            _iServiceEnterprise = iServiceEnterprise;

        }

        
    }
}


