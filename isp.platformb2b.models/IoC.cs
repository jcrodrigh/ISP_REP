using isp.platformb2b.models.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace isp.platformb2b.models
{
    public static class IoC
    {
        public static void IoCCommonDataLibraryRegister(this IServiceCollection service)
        {
            //service.AddTransient<IntInvoice, Invoice_UoW>();
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<IServiceEnterprise, ServiceEnterprise>();
            service.AddTransient<IServicePurcharseOrder, ServicePurcharseOrder>();
            service.AddTransient<IServiceDocument, ServiceDocument>();
            service.AddTransient<IServiceMasterTables, ServiceMasterTables>();
            service.AddTransient<IServiceElectronic, ServiceElectronic>();
       


        }
    }
}
