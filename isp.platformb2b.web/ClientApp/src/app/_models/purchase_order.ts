export interface PurchaseOrder
{
    ruc_empresa_cliente:string,
    id_orden_compra: string,
    id_tipo_moneda:string,
    monto_orden_compra: number,
    ruc_empresa_proveedor: string,
    competado: boolean,
    monto_acumulado: number

    
}