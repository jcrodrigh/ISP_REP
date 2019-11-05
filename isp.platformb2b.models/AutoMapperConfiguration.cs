using System;
using AutoMapper;
using isp.platformb2b.data.DatabaseModels;
using isp.platformb2b.models.DTOs;
using isp.platformb2b.models.entities;
using isp.platformb2b.models.DTOs.documents;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace isp.platformb2b.models
{
    public class AutoMapperConfiguration : Profile
    {
        [Obsolete]
        public AutoMapperConfiguration()
        {
            /*CreateMap<Invoice_DTO, Facturas>()
                    .ForMember(dest => dest.fechaFactura, m => m.MapFrom(src => Convert.ToDateTime(src.FechaEmision + " " + src.HoraEmision)))
                    .ForMember(dest => dest.NumeroFactura, m => m.MapFrom(src => src.FacturaId))
                    .ForMember(dest => dest.FacturaId, opt => opt.Ignore());*/

            
            CreateMap<Empresas, Enterprise>();
            CreateMap<enterpriceDTO,Empresas>()
                .ForMember(des => des.id_tipo_empresa_erp,m=> m.MapFrom(src => src.id_tipo_empresa_erp));
            CreateMap<OrdenesCompra, PurcharseOrder>();
            CreateMap<Document, documento>()
                .ReverseMap()
                    .ForMember(des => des.razon_social_proveedor, m=> m.MapFrom(src => src.proveedor.razon_social))
                    .ForMember(des => des.razon_social_cliente, m => m.MapFrom(src => src.ordenCompra.cliente.razon_social))
                    ;

            CreateMap<documentDTO, documento>()
                    .ForMember(des => des.id_documento, m => m.MapFrom(src=> src.num_serie +"-" + src.num_correlativo))
                    //.ForMember(des => des.factura_origen, m =>m.MapFrom(src => src.factura_origen_serie+"-"+src.factura_origen_correlativo))
                .ReverseMap()
                    //.ForMember(des => des.factura_origen_serie,m=> m.MapFrom(src => src.factura_origen.Split('-')[0]))
                    //.ForMember(des => des.factura_origen_correlativo, m => m.MapFrom(src => src.factura_origen.Split('-')[1]))
                    ;

            CreateMap<tipo_documento, TypeDocument>()
                .ReverseMap();

            CreateMap<PurcharseOrder, OrdenesCompra>()
                .ReverseMap();

            CreateMap<tipo_menu, NavBarByRoles>()
                .ReverseMap();

            CreateMap<ErrorsByDocument, documento_errores>()
                    .ForMember(des => des.documento, m => m.MapFrom(src => JsonConvert.SerializeObject(src.documento)))
                    .ForMember(des => des.errores, m => m.MapFrom(src => JsonConvert.SerializeObject(src.errores)))
                    .ForMember(des => des.errores, m => m.MapFrom(src => JsonConvert.SerializeObject(src.correos)))
                    .ForMember(des => des.num_serie, m => m.MapFrom(src => src.documento.num_serie))
                    .ForMember(des => des.num_correlativo, m => m.MapFrom(src => src.documento.num_correlativo))
                    .ForMember(des => des.ruc_empresa_cliente, m => m.MapFrom(src => src.documento.ruc_empresa_cliente))
                    .ForMember(des => des.ruc_empresa_proveedor, m => m.MapFrom(src => src.documento.ruc_empresa_proveedor))
                    .ForMember(des => des.id_tipo_documento, m => m.MapFrom(src => src.documento.id_tipo_documento))
                    .ForMember(des => des.usuario_modificacion, opt => opt.Ignore())
                    .ForMember(des => des.ultima_modificacion, opt => opt.Ignore());

            CreateMap<Enterprise_Enterprise, ti_empresa_empresa>()
                .ReverseMap();


                //.ReverseMap()
                //    .ForMember(des => des.documento, m => m.MapFrom(src => JsonConvert.DeserializeObject<documentDTO>(src.documento)))
                //    .ForMember(des => des.errores, m => m.MapFrom(src => JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(src.errores)))
                //    .ForMember(des => des.correos, m => m.MapFrom(src => JsonConvert.DeserializeObject<string[]>(src.correos)));


            


            /*
            CreateMap<Empresas,Enterprice>()
                    .ForMember(dest=> dest.roles, m => m.MapFrom(src.))
            /*Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Invoice_DTO, Factura>()
                    .ForMember(dest => dest.fechaFactura, m => m.MapFrom(src => Convert.ToDateTime(src.FechaEmision + " " + src.HoraEmision)))
                    .ForMember(dest => dest.NumeroFactura, m => m.MapFrom(src => src.FacturaId));

            });*/

            /*
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<One, Two>()
                 .ForMember(dest => dest.Sum, m => m.MapFrom(src => src.A + src.B + src.C));
            });

            IMapper mapper = config.CreateMapper();*/
        }
    }
}
