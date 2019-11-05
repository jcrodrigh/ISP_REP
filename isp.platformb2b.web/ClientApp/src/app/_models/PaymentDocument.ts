export interface PaymentDocumentDTO {
  ruc_empresa_proveedor: string;
  id_tipo_documento: string;
  num_serie: string;
  num_correlativo: string;
  fis_elec: Boolean;
  factura_origen_serie: string;
  factura_origen_correlativo: string;

  ruc_empresa_cliente: string;
  id_orden_compra: string;

  id_tipo_moneda: string;
  monto_subtotal_afecto: Number;
  monto_subtotal_inafecto: Number;
  monto_igv: Number;
  monto_isc: Number;
  monto_total: Number;

  orden: string;
  fecha_emision: Date;

  nombre_documento_excel: string;
  
  id_tipo_detracciones: string;
  factura_negociable: Boolean;
  ceco: string;
  url_imagen?: string[];
}

export interface TypesOfDocument {
  id_tipo_documento: string;
  nombre_documento: string;
  formato_serie_fisica: string;
  formato_serie_electronica: string;
  formato_correlativo: string;
  formato_ruc_proveedor: string;
  iva: number;
  nombre_iva: string;
  nombre_afecto: string;
  nombre_inafecto: string;
  mascara_serie_fisica: number,
  mascara_correlativo: number,
  orden_compra_requerido: boolean,
  serie_requerido:boolean,
  lista_serie:boolean,
  valor_venta_requerido:boolean,
  factura_origen:boolean,
  factura_origen_requerido:boolean,
  monto_isc:boolean,  
  detraccion:boolean,
  factura_negociable:boolean,
  igv_calculado:boolean
}

export interface DocumentFile{
   nombre_file:string,
   content_type:string,
   data : string
}

export interface Documentx {
  id_interno: number;
  ruc_empresa_proveedor: string;
  id_documento: string;
  id_tipo_documento: string;
  id_tipo_documento_estado: number;
  id_tipo_moneda: string;
  fecha_emision: Date;
  fis_elec: boolean;
  monto_subtotal_afecto: number;
  monto_subtotal_inafecto: number;
  monto_isc: number;
  monto_igv: number;
  monto_total: number;
  ruc_empresa_cliente: string;
  id_orden_compra: string;
  id_tipo_detracciones: string;
  factura_negociable: boolean;
  ceco: string;
  ultima_modificacion: Date;
  usuario_modificacion: string;
  url_imagen: string[];
  nombre_documento_excel: string;
  id_tipo_documento_devolucion: number;
  num_serie: string;
  num_correlativo: string;
  factura_origen: string;
  factura_origen_serie: string;
  factura_origen_correlativo:string;
  
  orden: string;
  razon_social_proveedor:string,
  razon_social_cliente:string,

}

/*Nuevo modelo para reporte gestion*/
export interface DocumentGestion {
  id_interno: number;
  ruc_empresa_proveedor: string;
  id_documento: string;
  id_tipo_documento: string;
  id_tipo_documento_estado: number;
  id_tipo_moneda: string;
  fecha_emision: Date;
  fis_elec: boolean;
  monto_subtotal_afecto: number;
  monto_subtotal_inafecto: number;
  monto_isc: number;
  monto_igv: number;
  monto_total: number;
  ruc_empresa_cliente: string;
  id_orden_compra: string;
  id_tipo_detracciones: string;
  factura_negociable: boolean;
  ceco: string;
  ultima_modificacion: Date;
  usuario_modificacion: string;
  url_imagen: string[];
  nombre_documento_excel: string;
  id_tipo_documento_devolucion: number;
  num_serie: string;
  num_correlativo: string;

  factura_origen_correlativo: string;
  factura_origen_serie: string;
  
  orden: string;
  razon_social_proveedor:string,
  razon_social_cliente:string,
  nombre_documento :string,
  iva : number,
  fecha_verificacion: Date,
  usuario_verificacion: string,
  hora_verificacion:string,
  fecha_transferencia?: Date,
  nro_conformidad_oc:StaticRange,
  
}


export interface ErrorsByDocument
{
  id_documento_errores:number,
  documento:PaymentDocumentDTO,
  errores:[],
  ultima_modificacion:Date,
  usuario_modificacion:string,
}

export interface DocumentFilter 
{
  ruc_empresa_cliente: string[],
  id_tipo_documento_estado: number[],
  ruc_empresa_proveedor: string[],
  fecha_emision_inferior?: Date,
  fecha_emision_superior?: Date,
  fecha_recepcion?:Date,
  fis_elec : boolean[]
}


export interface ResultMessage2 {
  message : string,
  code : number
}
