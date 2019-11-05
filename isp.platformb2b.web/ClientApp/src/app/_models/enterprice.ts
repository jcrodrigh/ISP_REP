export interface EnterpriseRegister
{
    ruc_empresa : string,
    razon_social : string,
    password : string,
    token : string,
    domicilio_fiscal : string,
    roles: string[],
}

export interface EnterpriseLogin
{
    ruc: string,
    password: string,
}

export interface Enterprise
{
    ruc_empresa: string,
    razon_social: string,
    domicilio_fiscal: string,
    id_tipo_empresa_erp?:number,
    sin_pedido:boolean,
    con_pedido:boolean,
    tolerancia:Number,
    tipo_tolerancia:Number
    logo: string,
    activo:boolean,
    habido:boolean,
}

export interface EnterpriseDTO
{
    ruc_empresa: string,
    razon_social: string,
    domicilio_fiscal: string,
    id_tipo_empresa_erp?:number,
}



export interface enterprise_enterprise
{
    ruc_empresa_cliente: string,
    ruc_empresa_proveedor: string,
    activo: boolean,
}