export enum Role {
    Admin = "cli-adm",
    Supplier = "prov-adm",
    Client = "cli-adm" ,
    UserIvm = "ivm-adm",

}

export interface  NavBarByRoles
{
  
    id_tipo_menu:number,
    name:string,
    url:string,
    icon:string,
    id_tipo_menu_padre?:number,
}