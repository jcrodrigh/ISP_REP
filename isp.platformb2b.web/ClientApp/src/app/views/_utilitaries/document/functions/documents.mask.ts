import {Document_mask} from 'src/app/_models';

export function getMaskbyIdDocument(id_document: string): Document_mask {
  var dmsk = document_mask_empty;
  dmsk.num_serie = true;
  dmsk.num_correlativo = true;
  dmsk.fecha_emision = true;
  dmsk.id_tipo_moneda = true;
  dmsk.id_orden_compra = true;
  dmsk.id_tipo_documento_estado = true;
  dmsk.ceco = true;
  dmsk.orden = true;
  dmsk.ruc_empresa_cliente = true;
  dmsk.monto_total = true;
  switch (id_document) {
    case '01':
      dmsk.monto_subtotal_afecto = true;
      dmsk.monto_subtotal_inafecto = true;
      dmsk.monto_igv = true;
      dmsk.monto_isc = true;
      dmsk.id_tipo_detracciones = true;
      dmsk.factura_negociable = true;
      break;
    case '02':
      dmsk.monto_subtotal_afecto = true;
      break;
    case '03':
      dmsk.monto_subtotal_afecto = true;
      break;
    case '05':
      dmsk.monto_subtotal_afecto = true;
      dmsk.monto_subtotal_inafecto = true;
      dmsk.monto_igv = true;
      break;
    case '07'://nota de debito
      dmsk.factura_origen_serie = true;
      dmsk.factura_origen_correlativo = true;
      dmsk.monto_subtotal_afecto = true;
      dmsk.monto_subtotal_inafecto = true;
      dmsk.monto_igv = true;
      dmsk.monto_isc = true;
      break;
    case '08'://nota de debito
      dmsk.factura_origen_serie = true;
      dmsk.factura_origen_correlativo = true;
      dmsk.monto_subtotal_afecto = true;
      dmsk.monto_subtotal_inafecto = true;
      dmsk.monto_igv = true;
      dmsk.monto_isc = true;
      break;
    case '10'://10 – Recibo de Arrendamiento
      dmsk.monto_subtotal_afecto = true;
    case '12':

      dmsk.monto_subtotal_afecto = true;
      dmsk.monto_subtotal_inafecto = true;
      dmsk.monto_igv = true;
    case '13':

      dmsk.monto_subtotal_afecto = true;
      dmsk.monto_igv = true;
    case '14':
      dmsk.monto_subtotal_afecto = true;
      dmsk.monto_igv = true;
    case '50':
      dmsk.monto_subtotal_afecto = true;
      dmsk.monto_igv = true;
      dmsk.monto_isc = true;
    case '91':
      dmsk.factura_origen_serie = true;
      dmsk.factura_origen_correlativo = true;
      dmsk.monto_subtotal_afecto = true;
    case '97':
      dmsk.factura_origen_serie = true;
      dmsk.factura_origen_correlativo = true;
      dmsk.monto_subtotal_afecto = true;
    default:
      break;
  }
  return dmsk;
}

export const document_mask_empty: Document_mask = {
  
  ceco: false,
  factura_negociable: false,
  factura_origen_correlativo: false,
  factura_origen_serie: false,
  fecha_emision: false,
  fis_elec: false,
  id_orden_compra: false,
  id_tipo_detracciones: false,
  id_tipo_documento: false,
  id_tipo_moneda: false,
  monto_igv: false,
  monto_isc: false,
  monto_subtotal_afecto: false,
  monto_subtotal_inafecto: false,
  monto_total: false,
  num_correlativo: false,
  num_serie: false,
  orden: false,
  ruc_empresa_cliente: false,
  ruc_empresa_proveedor: false, 
  id_tipo_documento_estado: false

};
