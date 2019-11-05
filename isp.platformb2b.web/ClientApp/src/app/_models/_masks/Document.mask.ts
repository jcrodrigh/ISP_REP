export interface Document_mask 
{
  ruc_empresa_proveedor:Boolean;
  id_tipo_documento:Boolean;
  num_serie:Boolean;
  num_correlativo:Boolean;
  fis_elec:Boolean;
  factura_origen_serie:boolean,
  factura_origen_correlativo: boolean, 

  ruc_empresa_cliente:Boolean;
  id_orden_compra:Boolean;
  
  id_tipo_moneda:Boolean;
  monto_subtotal_afecto:Boolean;
  monto_subtotal_inafecto:Boolean;
  monto_igv:Boolean;
  monto_isc:Boolean;
  monto_total:Boolean;
  
  fecha_emision:Boolean;
  
 
  
  id_tipo_detracciones:Boolean;
  factura_negociable:Boolean;
  ceco:Boolean;
  orden:boolean,
  id_tipo_documento_estado:boolean,
}