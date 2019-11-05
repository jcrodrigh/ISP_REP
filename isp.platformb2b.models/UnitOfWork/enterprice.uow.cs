using AutoMapper;
using isp.platformb2b.data;
using isp.platformb2b.data.DatabaseModels;
using isp.platformb2b.models.DTOs;
using isp.platformb2b.models.entities;
using isp.platformb2b.models.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace isp.platformb2b.models.UnitOfWork
{
    public interface IServiceEnterprise
    {

        List<Empresas> GetAllEnteprises();
        EnterpriseRegister Authenticate(string ruc, string password);
        List<Enterprise> getAllClientsBySupplier(string ruc);
        Enterprise getEnterpriseById(string ruc_enterprice);
        Enterprise getIfTheEnterpriseIsClient(string ruc_client);
        Boolean getIfExistRelationBetweenClientAndProvider(string ruc_client, string ruc_provider);
        List<DataBasicEnterprise> GetDataBasicEnterprise();
        List<DataBasicEnterprise> GetDataBasicProviderByClient(string ruc_empresa_cliente);

        List<Enterprise> GetAllActivesClients();

        //Nuevo
        List<Enterprise> GetAllActivesProviders();

        Enterprise CreateEnterpricesClient(enterpriceDTO new_enterprise);
        Enterprise UpdateEnterprise(enterpriceDTO new_enterprise);
        void ActiveClient(string ruc_enterprise_client);
        void RejectClient(string ruc_enterprise_client);

        List<Enterprise_Enterprise> getallRelationBetweenEnterprise();
        List<int> getRolesByRucEnterprice(string ruc_enterprise);

    }
    public class ServiceEnterprise:IServiceEnterprise
    {
        private readonly EFDataContext _dbContext;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        public ServiceEnterprise(EFDataContext dbContext,
            IOptions<AppSettings> appSettings,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        public List<Empresas> GetAllEnteprises()
        {
            IQueryable<Empresas> rtn = from temp in _dbContext.empresas
                                       //.Include("ti_roles_empresa")
                                       .Include("ti_roles_empresa.tipo_Rol")
                                       select temp;

            var list = rtn.ToList();

            //var cont= list[0].ti_roles_empresa.ToList();
            return list;
        }

        public List<DataBasicEnterprise> GetDataBasicEnterprise ()
        {
            return _dbContext.empresas
                  .Where(ent => ent.habido && ent.activo)
                  .Select(ent =>
                  new DataBasicEnterprise
                  {
                      ruc_empresa = ent.ruc_empresa,
                      razon_social = ent.razon_social
                  })
                  .ToList();
        }

        public List<DataBasicEnterprise> GetDataBasicProviderByClient(string ruc_empresa_cliente)
        {
            return _dbContext.ti_empresa_empresa
                  .Where(ent=> ent.ruc_empresa_cliente.Equals(ruc_empresa_cliente) &&
                                ent.activo &&
                                ent.empresa_cli.activo &&
                                ent.empresa_cli.habido)
                  .Select (ent=>new DataBasicEnterprise
                  { razon_social = ent.empresa_pro.razon_social,
                  ruc_empresa= ent.empresa_pro.ruc_empresa})
                  .ToList();
        }



        public Enterprise getEnterpriseById (string ruc_enterprice)
        {
            var enterprice = _dbContext.empresas
                .Where(ent => ent.ruc_empresa == ruc_enterprice)                
                .SingleOrDefault();

            if (enterprice == null) return null;
            if (string.IsNullOrEmpty(enterprice.ruc_empresa)) return null;

            Enterprise entx = new Enterprise();

            _mapper.Map(enterprice, entx);

            return entx;

        }

        public Enterprise getIfTheEnterpriseIsClient(string ruc_client)
        {
            var enterprice = (from ent in _dbContext.empresas
                        join rol in _dbContext.ti_tipo_empresa
                        on ent.ruc_empresa equals rol.ruc_empresa
                        where (rol.ruc_empresa == ruc_client && rol.id_tipo_empresa == 1)
                        select ent).FirstOrDefault();

            if (enterprice == null) return null;
            if(string.IsNullOrEmpty(enterprice.ruc_empresa)) return null;

            Enterprise entx = new Enterprise();

            _mapper.Map(enterprice, entx);

            return entx;

        }

        public EnterpriseRegister Authenticate (string ruc, string password)
        {
            var enterprice = _dbContext.empresas
                .Where(ent => ent.ruc_empresa == ruc) // && ent.password == password)
                .Select(ent => new EnterpriseRegister 
                {
                    ruc_empresa = ent.ruc_empresa,
                    direccion = ent.domicilio_fiscal,
                    razon_social = ent.razon_social,
                    roles = ent.Ti_Tipo_Empresas
                        .Select(rol => rol.tipoEmpresa.nombre_tipo_empresa)                                                
                        .ToList()
                }).SingleOrDefault<EnterpriseRegister>();

            if (enterprice == null) return null;

            List< Claim> claims = new List<Claim>  {
                    new Claim(ClaimTypes.Name, enterprice.ruc_empresa.ToString())
            };


            foreach (var role in enterprice.roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    claims
                ),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            enterprice.token = tokenHandler.WriteToken(token);

            // remove password before returning
            enterprice.password = null;




            //var enterpricex = _dbContext.empresas
            //           .Where(ent => ent.ruc_empresa == ruc && ent.password == password)
            //           .Include("ti_roles_empresa.tipo_Rol")
            //           .FirstOrDefault<Empresas>();
            return enterprice;

            
        }

        public List<Enterprise> getAllClientsBySupplier(string ruc)
        {
            IQueryable<Empresas> query = from ent in _dbContext.empresas
                                         join rel in _dbContext.ti_empresa_empresa
                                         on ent.ruc_empresa equals rel.ruc_empresa_cliente
                                         where rel.ruc_empresa_proveedor == ruc
                                         select ent;

            List<Enterprise> entx = new List<Enterprise>();

                _mapper.Map(query.ToList (),entx);

            return entx;

        }

        public Boolean getIfExistRelationBetweenClientAndProvider (string ruc_client, string ruc_provider)
        {
            var cont = _dbContext.ti_empresa_empresa
                .Where(ee => ee.ruc_empresa_cliente == ruc_client
                       && ee.ruc_empresa_proveedor == ruc_provider
                       && ee.activo)
                .Count();

            return (cont > 0) ? true : false;
        }

        public List<Enterprise> GetAllActivesClients()
        {
           IQueryable<Empresas> query = from ent in _dbContext.empresas
                                         join rel in _dbContext.ti_tipo_empresa
                                         on ent.ruc_empresa equals rel.ruc_empresa
                                         where (rel.id_tipo_empresa == 1 && ent.activo && ent.habido)
                                         select ent;

            List<Enterprise> entx = new List<Enterprise>();

            _mapper.Map(query.ToList (),entx);

            return entx;
        }

        public List<Enterprise> GetAllActivesProviders()
        {
            IQueryable<Empresas> query = from ent in _dbContext.empresas
                                         join rel in _dbContext.ti_tipo_empresa
                                         on ent.ruc_empresa equals rel.ruc_empresa
                                         where (rel.id_tipo_empresa == 2 && ent.activo && ent.habido)
                                         select ent;

            List<Enterprise> entx = new List<Enterprise>();

            _mapper.Map(query.ToList(), entx);

            return entx;
        }

        public void ActiveClient(string ruc_enterprise_client)
        {
            using (var context = _dbContext)
            {
                using (var transaction = context.Database.BeginTransaction())

                {
                    try
                    {
                        var temp_tee = context.ti_empresa_empresa.
                        Where(tee => tee.ruc_empresa_cliente.Equals(ruc_enterprise_client) &&
                             tee.empresa_pro.activo).ToList();
                        temp_tee.ForEach(ltee => ltee.activo = true);
                        context.SaveChanges();

                        var temp_users = context.usuarios.
                             Where(us => us.ruc_empresa.Equals(ruc_enterprise_client)).ToList();
                        temp_users.ForEach(lus => lus.activo = true);
                        context.SaveChanges();

                        var tyemp = context.ti_tipo_empresa.
                            FirstOrDefault(te => te.ruc_empresa.Equals(ruc_enterprise_client));
                        if (tyemp == null)
                        {
                            var new_te = new ti_tipo_empresa() { ruc_empresa = ruc_enterprise_client, id_tipo_empresa = 1, fecha = DateTime.Now };
                            context.Add(new_te);
                            context.SaveChanges();
                        }
                        transaction.Commit();


                    }
                    catch (Exception err)
                    {
                        transaction.Rollback();
                        throw err;
                    }
                    finally
                    {
                        transaction.Dispose();
                    }


                }
            }
        }

        public void RejectClient(string ruc_enterprise_client)
        {
            using (var context = _dbContext)
            {
                using (var transaction = context.Database.BeginTransaction())

                {
                    try
                    {
                        var temp_tee = context.ti_empresa_empresa.
                        Where(tee => tee.ruc_empresa_cliente.Equals(ruc_enterprise_client)).ToList();
                        temp_tee.ForEach(ltee => ltee.activo = false);
                        context.SaveChanges();

                        var temp_users = context.usuarios.
                             Where(us => us.ruc_empresa.Equals(ruc_enterprise_client)).ToList();
                        temp_users.ForEach(lus => lus.activo = false);
                        context.SaveChanges();
                        transaction.Commit();


                    }
                    catch (Exception err)
                    {
                        transaction.Rollback();
                        throw err;
                    }
                    finally
                    {
                        transaction.Dispose();
                    }


                }
            }
        }

        public Enterprise UpdateEnterprise (enterpriceDTO new_enterprise)
        {
            var tempe =_dbContext.empresas.FirstOrDefault(ent => ent.ruc_empresa.Equals(new_enterprise.ruc_empresa));
            if ((tempe!=null)?!string.IsNullOrEmpty(tempe.ruc_empresa):false)
            {
                tempe.razon_social = new_enterprise.razon_social;
                tempe.domicilio_fiscal = new_enterprise.domicilio_fiscal;
                tempe.id_tipo_empresa_erp = new_enterprise.id_tipo_empresa_erp;
                _dbContext.SaveChanges();

                var temp = _mapper.Map<Enterprise>(tempe);
                return temp;


            }
            return null;
        }

        public Enterprise CreateEnterpricesClient(enterpriceDTO new_enterprise)
        {
            Empresas ent = _mapper.Map<Empresas>(new_enterprise);
           var tte = _dbContext.ti_tipo_empresa.FirstOrDefault(entx =>
                        entx.ruc_empresa.Equals(new_enterprise.ruc_empresa) &&
                        entx.id_tipo_empresa.Equals(1));

            using (var context = _dbContext)
            {
                using (var transaction = context.Database.BeginTransaction())

                {
                    try
                    {
                        context.empresas.Add(ent);
                        context.SaveChanges();
                        if ((tte != null) ? !string.IsNullOrEmpty(tte.ruc_empresa) : false)
                        {
                            tte = new ti_tipo_empresa()
                            {
                                ruc_empresa = new_enterprise.ruc_empresa,
                                id_tipo_empresa = 1,
                            };
                            context.Add(tte);
                            context.SaveChanges();
                        }

                        transaction.Commit();
                        var temp = _mapper.Map<Enterprise>(ent);
                        return temp;
                    }
                    catch (Exception err)
                    {
                        transaction.Rollback();
                        throw err;
                    }
                    finally
                    {
                        transaction.Dispose();
                    }



                }
            }
        }

        public List<Enterprise_Enterprise> getallRelationBetweenEnterprise ()
        {
            var temp = _dbContext.ti_empresa_empresa.Where(ent => ent.activo).ToList();
            var res = new List<Enterprise_Enterprise>();


            
            _mapper.Map(temp, res);

            return res;

        }

        public List<int> getRolesByRucEnterprice (string ruc_enterprise)
        {
            var tte = _dbContext.ti_tipo_empresa.Where(ent => ent.ruc_empresa.Equals(ruc_enterprise)).ToList();
            
            if (tte.Count>0)
            {
                var ruc = tte[0].ruc_empresa;
                var lista = new List<int>();
               
                        tte.ForEach(temp => lista.Add(temp.id_tipo_empresa));
                return lista;
            }
            return null;
            
        }
    }
}
