    using isp.platformb2b.data.DatabaseModels;
using isp.platformb2b.data.Seeders;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace isp.platformb2b.data
{
    public class EFDataContext : DbContext
    {
        
        public DbSet<Empresas> empresas { get; set; }
        public DbSet<OrdenesCompra> ordenes_compra { get; set; }
        public DbSet<tipo_documento> tipo_documento { get; set; }
        public DbSet<tipo_moneda> tipo_moneda { get; set; }
        public DbSet<documento> documento { get; set; }
        public DbSet<tipo_roles> tipo_roles { get; set; }
        public DbSet<ti_empresa_empresa> ti_empresa_empresa { get; set; }
        public DbSet<tipo_documento_estado> tipo_documento_estado { get; set; }
        public DbSet<tipo_detracciones> tipo_detracciones { get; set; }
        public DbSet<usuarios> usuarios { get; set; }   

        public DbSet<tipo_empresa_erp> tipo_empresa_erp { get; set; } 

        public DbSet<auditorias> auditorias { get; set; }

        

        public DbSet<tipo_documento_serie> tipo_documento_serie { get; set; }


        public DbSet<tipo_documento_devolucion> tipo_documento_devolucion { get; set; }

        public DbSet<documento_errores> documento_errores { get; set; }
        public DbSet<Audit> Audits { get; set; }




        public DbSet<Persona> persona { get; set; }
        public DbSet<ti_empresa_persona> ti_empresa_persona { get; set; }

        public DbSet<tipo_empresa> tipo_empresa { get; set; }
        public DbSet<ti_usuario_roles> ti_usuario_roles { get; set; }

        public DbSet<ti_roles_menu> ti_roles_menu { get; set; }

        public DbSet<tipo_menu> tipo_menu { get; set; }

        public DbSet<ti_tipo_empresa> ti_tipo_empresa { get; set; }





        public EFDataContext(DbContextOptions<EFDataContext> option)
            : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrdenesCompra>()
                .HasKey(o => new { o.ruc_empresa_cliente, o.id_orden_compra });
            modelBuilder.Entity<documento>()
                .HasKey(o => new { o.ruc_empresa_proveedor, o.id_tipo_documento, o.id_documento });
            modelBuilder.Entity<ti_empresa_empresa>()
                .HasKey(sc => new { sc.ruc_empresa_cliente, sc.ruc_empresa_proveedor });
            modelBuilder.Entity<tipo_documento_serie>()
                .HasKey(dser => new { dser.id_tipo_documento, dser.id_tipo_documento_serie });
            modelBuilder.Entity<ti_usuario_roles>()
                .HasKey(ur => new { ur.username, ur.id_tipo_roles });
            modelBuilder.Entity<ti_empresa_persona>()
                .HasKey(ep => new { ep.ruc_empresa,ep.dni_persona });
            modelBuilder.Entity<ti_roles_menu>()
                .HasKey(rm => new { rm.id_tipo_menu, rm.id_tipo_roles });
            modelBuilder.Entity<ti_tipo_empresa>()
                .HasKey(te => new { te.id_tipo_empresa, te.ruc_empresa});
            modelBuilder.Entity<ti_empresa_empresa>()
                .HasOne(pt => pt.empresa_cli)
                .WithMany(p => p.Empresas_Clientes)                
                .HasForeignKey(pt => pt.ruc_empresa_cliente);
            modelBuilder.Entity<ti_empresa_empresa>()
                .HasOne(pt => pt.empresa_pro)
                .WithMany(p => p.Empresas_Proveedoras)
                .HasForeignKey(pt => pt.ruc_empresa_proveedor);

            modelBuilder.Entity<Empresas>().Property(b => b.habido).HasDefaultValue(true);
            modelBuilder.Entity<Empresas>().Property(b => b.activo).HasDefaultValue(true);


            //modelBuilder.Entity<tipo_menu>().
            //    HasMany(tmx=> tmx.menus_hijos)
                
            //    .WithOne(tmy=> tmy.menu_padre)
            //    .HasForeignKey(tmz => tmz.id_tipo_menu_padre);











            modelBuilder.Entity<tipo_moneda>().HasData(seedTipoMoneda.ListaMonedas);
            modelBuilder.Entity<tipo_documento>().HasData(seedTipoDocumento.listaDocumentos);
            //modelBuilder.Entity<tipo_documento>().HasData(sedTipoDocumento.listaDocumentos);
            modelBuilder.Entity<tipo_roles>().HasData(seedTipoRol.ListaRoles);
            modelBuilder.Entity<Empresas>().HasData(seedEmpresa.ListaEmpresas);

            
            modelBuilder.Entity<ti_empresa_empresa>().HasData(seed_ti_empresa_empresa.listaEmpresaEmpresa);
            modelBuilder.Entity<tipo_documento_devolucion>().HasData(seed_tipo_documento_devolucion.listaTipoDocumentomotivo);
            modelBuilder.Entity<OrdenesCompra>().HasData(seed_orden_compra.ListaOrdenesCompra);
           //modelBuilder.Entity<ti_usuario_roles>().HasData(seed_ti_usuario_roles.listaRolesUsuario);

            modelBuilder.Entity<usuarios>().HasData(seed_usuario.ListaUsuarios);

            

            modelBuilder.Entity<tipo_documento_estado>().HasData(SeedTipoDocumentoEstado.listaTipoDocumentoEstado);

            modelBuilder.Entity<tipo_empresa_erp>().HasData(SeedTipoEmpresaErp.listaTipoEmpresaERP);

            modelBuilder.Entity<tipo_detracciones>().HasData(seed_tipo_detraccion.ListaTipoDetracciones);

            modelBuilder.Entity<tipo_documento_serie>().HasData(seed_tipo_documento_serie.ListaTipoDocumentoSerie);

            modelBuilder.Entity<Persona>().HasData(seed_persona.ListaPersonas);
            modelBuilder.Entity<tipo_empresa>().HasData(seed_tipo_empresa.ListaTipoEmpresa);
            
            modelBuilder.Entity<tipo_menu>().HasData(seed_tipo_menu.ListaTipoMenu);
            modelBuilder.Entity<ti_usuario_roles>().HasData(seed_ti_usuario_roles.listaRolesUsuario);

            modelBuilder.Entity<ti_tipo_empresa>().HasData(seed_ti_tipo_empresa.ListaTiTipoEmpresa);

            modelBuilder.Entity<ti_roles_menu>().HasData(seed_ti_roles_menu.ListaRolesMenu);

        }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if(string.IsNullOrEmpty(this.option))
        }*/

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var auditEntries = OnBeforeSaveChanges();
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            await OnAfterSaveChanges(auditEntries);
            return result;
        }

        public async Task<int> SaveChangesWithAudit(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var auditEntries = OnBeforeSaveChanges();
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            await OnAfterSaveChanges(auditEntries);
            return result;
        }

        private List<AuditEntry> OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is AuditEntry || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                var auditEntry = new AuditEntry(entry);
                auditEntry.TableName = entry.Metadata.Relational().TableName;
                auditEntries.Add(auditEntry);

                foreach (var property in entry.Properties)
                {
                    if (property.IsTemporary)
                    {
                        // value will be generated by the database, get the value after saving
                        auditEntry.TemporaryProperties.Add(property);
                        continue;
                    }

                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;

                        case EntityState.Deleted:
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                        case EntityState.Detached:
                            break;
                        case EntityState.Unchanged:
                            break;
                        
                    }
                }
            }

            // Save audit entities that have all the modifications
            foreach (var auditEntry in auditEntries.Where(_ => !_.HasTemporaryProperties))
            {
                Audits.Add(auditEntry.ToAudit());
            }

            // keep a list of entries where the value of some properties are unknown at this step
            return auditEntries.Where(_ => _.HasTemporaryProperties).ToList();
        }

        private Task OnAfterSaveChanges(List<AuditEntry> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count == 0)
                return Task.CompletedTask;
    
        foreach (var auditEntry in auditEntries)
            {
                // Get the final value of the temporary properties
                foreach (var prop in auditEntry.TemporaryProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                    else
                    {
                        auditEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                }

                // Save the Audit entry
                Audits.Add(auditEntry.ToAudit());
            }

            return SaveChangesAsync();
        }
    }
        
}
