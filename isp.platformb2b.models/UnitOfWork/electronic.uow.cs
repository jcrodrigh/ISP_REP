using AutoMapper;
using isp.platformb2b.data;
using isp.platformb2b.data.DatabaseModels;
using isp.platformb2b.models.entities;
using isp.platformb2b.models.Helpers;
using Microsoft.Extensions.Options;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace isp.platformb2b.models.UnitOfWork
{

    public interface IServiceElectronic
    {
        //Document ToTransferred(int id_interno);
        Task<Document> ToTransferred(int id_interno);
        Task<Document> ToRejected(int id_interno);
        Task<Document> ToAccountedFor(int id_interno);
    }
    public class ServiceElectronic : IServiceElectronic
    {
        private readonly EFDataContext _dbContext;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        public ServiceElectronic(EFDataContext dbContext,
            IOptions<AppSettings> appSettings,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<Document> ToTransferred(int id_interno)
        {
            using (var transaction = _dbContext.Database.CurrentTransaction ?? _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var doc = await _dbContext.documento.FirstOrDefaultAsync(doci => doci.id_interno.Equals(id_interno));
                    
                    doc.usuario_modificacion = "ByEmail";
                    doc.fecha_transferencia = DateTime.Now;
                    doc.ultima_modificacion = DateTime.Now;

                    if (doc == null || doc?.id_interno == 0) return null;
                    doc.id_tipo_documento_estado = 2;
                    doc.ultima_modificacion = DateTime.Now;
                    await _dbContext.SaveChangesAsync();
                    transaction.Commit();
                    return _mapper.Map<Document>(doc);
                }
                catch ( Exception err)
                {
                    transaction.Rollback();
                    throw err;
                }

            }
        }



        public async Task<Document> ToAccountedFor(int id_interno)
        {
            using (var transaction = _dbContext.Database.CurrentTransaction ?? _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var doc = await _dbContext.documento.FirstOrDefaultAsync(doci => doci.id_interno.Equals(id_interno));

                    doc.usuario_modificacion = "ByEmail";
                    doc.fecha_contabilizacion = DateTime.Now;
                    doc.ultima_modificacion = DateTime.Now;

                    if (doc == null || doc?.id_interno == 0) return null;
                    doc.id_tipo_documento_estado = 3;
                    doc.ultima_modificacion = DateTime.Now;
                    await _dbContext.SaveChangesAsync();
                    transaction.Commit();
                    return _mapper.Map<Document>(doc);
                }
                catch (Exception err)
                {
                    transaction.Rollback();
                    throw err;
                }
            }

        }

        public async Task<Document> ToRejected(int id_interno)
        {
            using (var transaction = _dbContext.Database.CurrentTransaction ?? _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var doc = await _dbContext.documento.FirstOrDefaultAsync(doci => doci.id_interno.Equals(id_interno));

                    doc.usuario_modificacion = "ByEmail";                    
                    doc.ultima_modificacion = DateTime.Now;

                    if (doc == null || doc?.id_interno == 0) return null;
                    doc.id_tipo_documento_estado = 4;
                    doc.ultima_modificacion = DateTime.Now;
                    await _dbContext.SaveChangesAsync();
                    var po = await _dbContext.ordenes_compra.FirstOrDefaultAsync(
                                            pox => pox.ruc_empresa_cliente.Equals(doc.ruc_empresa_cliente) &&
                                                    pox.id_orden_compra.Equals(doc.id_orden_compra) &&
                                                    !pox.id_orden_compra.Equals("--"));
                    if (po!=null && !string.IsNullOrEmpty(po?.id_orden_compra))
                    {
                        po.monto_acumulado = po.monto_acumulado - doc.monto_subtotal_afecto - doc.monto_subtotal_inafecto;
                        po.competado = false;
                        await _dbContext.SaveChangesAsync();
                    }
                    transaction.Commit();
                    return _mapper.Map<Document>(doc);
                }
                catch (Exception err)
                {
                    transaction.Rollback();
                    throw err;
                }

            }
        }

     }
}
