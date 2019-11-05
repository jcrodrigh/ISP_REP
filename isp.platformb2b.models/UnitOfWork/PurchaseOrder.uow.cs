using AutoMapper;
using isp.platformb2b.data;
using isp.platformb2b.data.DatabaseModels;
using isp.platformb2b.models.entities;
using isp.platformb2b.models.Helpers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace isp.platformb2b.models.UnitOfWork
{
    public interface IServicePurcharseOrder
    {
        List<PurcharseOrder> getAllPurcharseOrderBySupplier(string ruc_provedor, string ruc_cliente);
        PurcharseOrder getPurcharseOrderByID(string ruc_client, string purcharse_order_code);
        PurcharseOrder GetPurcharseOrderNull(string ruc_client);
        PurcharseOrder GetPurcharseOrderNullIfClientAllowsIt(string ruc_client);
        PurcharseOrder GetPurcharseOrderIfNotExistReturnNull(string ruc_client, string purcharse_order_code);
        PurcharseOrder UpdateAmountForClient(PurcharseOrder po_ord);
    }
    public class ServicePurcharseOrder: IServicePurcharseOrder
    {
        private readonly EFDataContext _dbContext;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        public ServicePurcharseOrder(EFDataContext dbContext,
            IOptions<AppSettings> appSettings,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        public List<PurcharseOrder> getAllPurcharseOrderBySupplier(string ruc_proveedor, string ruc_cliente)
        { 
            IQueryable<OrdenesCompra> query = from ord in _dbContext.ordenes_compra
                                         where (ord.ruc_empresa_cliente == ruc_cliente &&
                                                ord.ruc_empresa_proveedor == ruc_proveedor)
                                         select ord;
            List<PurcharseOrder> purcharseOrders = new 
                List<PurcharseOrder>();

            var temp = query.ToList();
            if (temp == null) return null;

            _mapper.Map(query.ToList(), purcharseOrders) ;

            return purcharseOrders;

        }
        
        public PurcharseOrder getPurcharseOrderByID(string ruc_client, string purcharse_order_code)
        {
            purcharse_order_code = (string.IsNullOrEmpty(purcharse_order_code)) ? "--" : purcharse_order_code;
            IQueryable<OrdenesCompra> query = from ord in _dbContext.ordenes_compra
                                              where (ord.ruc_empresa_cliente == ruc_client &&
                                                     ord.id_orden_compra == purcharse_order_code)
                                              select ord;
            var temp = query.ToList();
            if (temp == null || temp.Count() == 0)
            {
                
                return null;
                
            }

            return _mapper.Map<PurcharseOrder>(temp[0]);
        }

        public PurcharseOrder GetPurcharseOrderIfNotExistReturnNull(string ruc_client, string purcharse_order_code)
        {
            purcharse_order_code = (string.IsNullOrEmpty(purcharse_order_code)) ? "--" : purcharse_order_code;
            IQueryable<OrdenesCompra> query = from ord in _dbContext.ordenes_compra
                                              where (ord.ruc_empresa_cliente == ruc_client &&
                                                     ord.id_orden_compra == purcharse_order_code)
                                              select ord;
            var temp = query.ToList();
            if (temp == null || temp.Count() == 0)
            {
                if (purcharse_order_code.Equals("--"))
                {
                    return GetPurcharseOrderNull(ruc_client);
                }

                return null;

            }

            return _mapper.Map<PurcharseOrder>(temp[0]);
        }



        public PurcharseOrder GetPurcharseOrderNullIfClientAllowsIt (string ruc_client)
        {
            var pur_ord = _dbContext.ordenes_compra
                .Where(po => po.ruc_empresa_cliente == ruc_client &&
                po.id_orden_compra == "--")
                .FirstOrDefault();

            if (pur_ord == null)
            {
                var enterprice = _dbContext.empresas
                    .Where(ent => ent.ruc_empresa == ruc_client && ent.sin_pedido)
                            .FirstOrDefault();

                if (enterprice == null) return null;
                if (enterprice.ruc_empresa == null) return null;

                OrdenesCompra null_purcharse_order = new OrdenesCompra
                {
                    id_orden_compra = "--",
                    id_tipo_moneda = "XXX",
                    monto_orden_compra = 0,
                    ruc_empresa_cliente = ruc_client,
                    ruc_empresa_proveedor = null
                };

                var temp = _dbContext.ordenes_compra
                    .Add(null_purcharse_order);

                _dbContext.SaveChanges();

                return _mapper.Map<PurcharseOrder>(null_purcharse_order);
               

            }

            return _mapper.Map<PurcharseOrder>(pur_ord);
        }

        public PurcharseOrder GetPurcharseOrderNull(string ruc_client)
        {
            var pur_ord = _dbContext.ordenes_compra
               .Where(po => po.ruc_empresa_cliente == ruc_client &&
               po.id_orden_compra == "--")
               .FirstOrDefault();

            if (pur_ord == null)
            {
                var enterprice = _dbContext.empresas
                   .Where(ent => ent.ruc_empresa == ruc_client && ent.sin_pedido)
                           .FirstOrDefault();

                if (enterprice == null) return null;
                if (enterprice.ruc_empresa == null) return null;

                OrdenesCompra null_purcharse_order = new OrdenesCompra
                {
                    id_orden_compra = "--",
                    id_tipo_moneda = "XXX",
                    monto_orden_compra = 0,
                    ruc_empresa_cliente = ruc_client,
                    ruc_empresa_proveedor = null
                };

                var temp = _dbContext.ordenes_compra
                   .Add(null_purcharse_order);

                try
                {
                    _dbContext.SaveChanges();

                    return _mapper.Map<PurcharseOrder>(null_purcharse_order);
                }
                catch (Exception err)
                {
                    return null;
                }
                
            }
            return _mapper.Map<PurcharseOrder>(pur_ord);
        }

        public PurcharseOrder UpdateAmountForClient(PurcharseOrder po_ord)
        {
            var pox = _dbContext.ordenes_compra.
                FirstOrDefault(po => 
                    po.ruc_empresa_cliente.Equals(po_ord.ruc_empresa_cliente) &&
                    po.id_orden_compra.Equals(po_ord.id_orden_compra));

            
            if (pox != null)
            {

                pox.monto_cliente = po_ord.monto_cliente;
                _dbContext.ordenes_compra.Update(pox);

                
                _dbContext.SaveChanges();

                return _mapper.Map<PurcharseOrder>(pox);
            }

            else
            {
                return null;
            }

        }
    }
}
