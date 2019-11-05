export function NameOfFieldOfDocuments (nombre:string):string
{
    switch(nombre)
    {
    
        case 'ruc_empresa_proveedor': return 'RUC empresa Provedor';
        case 'id_tipo_documento': return 'Tipo Documento';
        case 'num_serie': return 'Número de serie' ;
        case 'num_correlativo': return 'Número de comprobante de pago';
        case 'fis_elec':  return 'Flag Físico Electrónico';
        case 'factura_origen': return 'Factura origen';
        case 'ord_comp': return 'Flag Orden de compra';
        case 'ruc_empresa_cliente': return 'RUC Empresa Cliente';
        case 'id_orden_compra': return 'Orden de compra';
        case 'afecto': return 'Afecto e Inafecto';
        case 'id_tipo_moneda':  return 'Tipo Moneda';
        case 'monto_subtotal_afecto': return 'Sub-total venta';
        case 'monto_subtotal_inafecto': return 'Sub-total Inafecto';
        case 'monto_igv': return 'IGV';
        case 'monto_isc': return 'ISC';
        case 'monto_total': return 'Total';
        case 'detraccion': return 'Detracción';
        
        case 'fecha_emision':  return 'Fecha Emisión';
        
        case 'num_anticipo': return 'Anticipo';
        case 'id_tipo_detracciones': return 'Detracciones';
        case 'factura_negociable':  return 'factura Negociable';
        case 'ceco': return 'CECO';
        case 'url_imagen':  return 'Imagenes';
    }
}