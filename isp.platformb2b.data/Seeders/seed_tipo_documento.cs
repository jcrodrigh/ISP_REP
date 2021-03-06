﻿using isp.platformb2b.data.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace isp.platformb2b.data.Seeders
{
    public class seedTipoDocumento
    {
        public readonly static List<tipo_documento> listaDocumentos =
            new List<tipo_documento>
            {
                new tipo_documento() {
                    id_tipo_documento ="01",
                    nombre_documento ="Factura.",
                    formato_ruc_proveedor = "^(1|2)0[0-9]{9}$",
                    formato_serie_fisica ="^[0-9]{4}$",
                    formato_serie_electronica ="^(E001|F[A-Z0-9]{3})$",
                    formato_correlativo ="(?!00000000)^[0-9]{8}$",
                    iva =(decimal)0.18,
                    mascara_correlativo = 8,
                    mascara_serie_fisica = 4,
                    orden_compra_requerido = true,
                    monto_isc = true,
                    factura_negociable = true,
                    detraccion = true,
                    nombre_carpeta = "factura"
                },
                new tipo_documento() {
                    id_tipo_documento ="02",
                    nombre_documento ="Recibo por Honorarios.",
                    formato_serie_fisica ="^[0-9]{4}$",
                    formato_serie_electronica ="^E001$",
                    formato_correlativo ="(?!0000000)^[0-9]{7}$",
                    formato_ruc_proveedor ="^10[0-9]{9}$",
                    iva = (decimal)0.08,
                    nombre_iva = "Retención",
                   
                    nombre_afecto = "Total Honorarios",
                    mascara_correlativo = 7,
                    mascara_serie_fisica = 4,
                    orden_compra_requerido = true,
                    valor_venta_requerido = true,
                },
                new tipo_documento() {id_tipo_documento="03",
                    nombre_documento ="Boleta de Venta.",
                    formato_serie_fisica ="^[0-9]{4}$",
                    formato_serie_electronica ="^(EB01|B[A-Z0-9]{3})$",
                    formato_correlativo ="(?!00000000)^[0-9]{8}$",
                    
                    mascara_correlativo = 8,
                    mascara_serie_fisica = 4,
                    orden_compra_requerido = true,
                    valor_venta_requerido = true,
                },
                new tipo_documento() {id_tipo_documento="05",nombre_documento="Boletos de Transporte Aéreo.",
                    formato_serie_fisica ="^[1-4]$",
                    formato_serie_electronica ="^[1-4]$",
                    formato_correlativo ="(?!00000000000)^[0-9]{11}$",
                    mascara_correlativo = 11,
                    orden_compra_requerido = true,
                    lista_serie = true,
                },
                new tipo_documento() {id_tipo_documento="07",
                    nombre_documento ="Nota de crédito.",
                    formato_serie_fisica ="^[0-9]{4}$",
                    formato_serie_electronica ="^(E001|EB01|B[A-Z0-9]{3}|F[A-Z0-9]{3})$",
                    formato_correlativo ="(?!00000000)^[0-9]{8}$",
                    iva =(decimal)0.18,
                    mascara_serie_fisica = 4,
                    mascara_correlativo = 8,
                    formato_factura_origen_serie = "^(E001|F[A-Z0-9]{3}|[0-9]{4})$",
                    factura_origen = true,
                    factura_origen_requerido = true,
                    monto_isc = true,
                },
                new tipo_documento() {id_tipo_documento="08",
                    nombre_documento ="Nota de débito.",
                    formato_serie_fisica ="^[0-9]{4}$",
                    formato_serie_electronica ="^(E001|EB01|B[A-Z0-9]{3}|F[A-Z0-9]{3})$",
                    formato_correlativo ="(?!00000000)^[0-9]{8}$",
                    iva =(decimal)0.18,
                    mascara_serie_fisica = 4,
                    mascara_correlativo = 8,
                    formato_factura_origen_serie = "^(E001|F[A-Z0-9]{3}|[0-9]{4})$",
                    factura_origen = true,
                    monto_isc = true,
                },
                new tipo_documento() {id_tipo_documento="10",
                    nombre_documento ="Recibo por Arrendamiento.",
                   
                    orden_compra_requerido = true,
                    lista_serie = true,
                    valor_venta_requerido = true,
                },
                new tipo_documento() {id_tipo_documento="12",
                    nombre_documento ="Ticket o cinta emitido por máquina registradora.",
                    formato_serie_electronica = "^[A-Za-z0-9]{0,4}$",
                    formato_serie_fisica = "^[A-Za-z0-9]{0,4}$",
                    formato_correlativo = "^[A-Za-z0-9]{0,20}$",
                    orden_compra_requerido = true,
                },
                new tipo_documento() {id_tipo_documento="13",
                    nombre_documento ="Documentos emitidos por las empresas del sistema financiero y de seguros, y por las cooperativas de ahorro y crédito no autorizadas a captar recursos del público, que se encuentren bajo el control de la Superintendencia de Banca, Seguros y AFP.",
                    nombre_afecto = "Monto Afecto",
                    formato_serie_electronica = "^[A-Za-z0-9]{0,4}$",
                    formato_serie_fisica = "^[A-Za-z0-9]{0,4}$",
                    formato_correlativo = "^[A-Za-z0-9]{0,20}$",
                    serie_requerido = false,
                },
                new tipo_documento() {
                    id_tipo_documento ="14",
                    nombre_documento ="Recibo por servicios públicos de suministro de energía eléctrica, agua, teléfono, télex y telegráficos y otros servicios complementarios que se incluyan en el recibo de servicio público",
                    formato_serie_electronica = "^[A-Za-z0-9]{0,4}$",
                    formato_serie_fisica = "^[A-Za-z0-9]{0,4}$",
                    formato_correlativo = "^[A-Za-z0-9]{0,20}$",

                    orden_compra_requerido = true,
                    serie_requerido = false

                },
                new tipo_documento() {id_tipo_documento="50",nombre_documento="Declaración Única de Aduanas - DUA/ Declaración Aduanera de Mercancías - DAM.",
                    //formato_serie_fisica ="^([0-9]{0,3})$",
                    //formato_serie_electronica ="^(EB01|EB01|B[A-Z0-9]{3}|F[A-Z0-9]{3})$",
                    formato_correlativo ="(?!000000)^[0-9]{6}$",
                    mascara_serie_fisica = 3,
                    mascara_correlativo = 6,
                    //mascara_serie_fisica = 4,
                    lista_serie = true,
                    monto_isc = true,
                    igv_calculado = false,
                },
                new tipo_documento() {id_tipo_documento="91",
                    nombre_documento ="Comprobante de No Domiciliado.",
                    orden_compra_requerido = true,
                    serie_requerido = true,
                    formato_serie_electronica = "^[A-Za-z0-9]{0,4}$",
                    formato_serie_fisica = "^[A-Za-z0-9]{0,4}$",
                    formato_correlativo = "^[A-Za-z0-9]{0,20}$",
                    valor_venta_requerido = true,

                },
                new tipo_documento() {id_tipo_documento="97",
                    nombre_documento ="Nota de Crédito - No Domiciliado",
                    orden_compra_requerido = true,
                    formato_serie_electronica = "^[A-Za-z0-9]{0,4}$",
                    formato_serie_fisica = "^[A-Za-z0-9]{0,4}$",
                    formato_correlativo = "^[A-Za-z0-9]{0,20}$",
                    serie_requerido = true,
                    factura_origen = true,
                    factura_origen_requerido = true,
                    valor_venta_requerido = true,

                },
                //new tipo_documento() {id_tipo_documento="00",nombre_documento="Otros."},
                //new tipo_documento() {id_tipo_documento="AS",nombre_documento="Apunte contable cuenta mayor."},
                new tipo_documento() {id_tipo_documento="ER",
                    nombre_documento ="Entregas a rendir.",
                    valor_venta_requerido = true,
                    nombre_afecto = "Anticipo"
                },

                

            };
    }
}
