import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EnterpriseRegister, Enterprise, EnterpriseDTO, enterprise_enterprise } from '../_models/enterprice';

import { BehaviorSubject, Observable, observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class EnterpriceService {
  constructor(private http:HttpClient) { }

  getAllClientBySupplier ():Observable<Enterprise[]> 
  {
    return this.http.get<Enterprise[]>(`enterprice/client`);
  }
  
  getEnterpriceBySesion (): Observable<Enterprise>
  {
    return this.http.get<Enterprise>(`enterprice/provider`);
  }

  
  GetActivesClients ():Observable<Enterprise[]> 
  {
    return this.http.get<Enterprise[]>(`enterprice/ActivesClients`);
  }

  GetActivesProviders ():Observable<Enterprise[]> 
  {
    return this.http.get<Enterprise[]>(`enterprice/ActivesProviders`);
  }

  getEnterpriseByRuC(ruc_enterprise:string):Observable<Enterprise>
  {
    return this.http.get<Enterprise>("enterprice/ruc/"+ruc_enterprise)
  }

  CreateNewClient(new_enterprise:any):Observable<Enterprise>
  {
   return this.http.post<Enterprise>("enterprice/create/client",new_enterprise) 
  }

  updateEnterprice (enterprise:EnterpriseDTO):Observable<Enterprise>
  {
    return this.http.put<Enterprise>("enterprice",enterprise)
  }

  ActiveClient(ruc_empresa:string):Observable<any>
  {
    return this.http.put<any>("enterprice/client/active/"+ruc_empresa,null);
  }
  rejectClient(ruc_empresa:string):Observable<any>
  {
    return this.http.put<any>("enterprice/client/reject/"+ruc_empresa,null);
  }

  getrelationbetweenenterprise():Observable<enterprise_enterprise>
  {
    return this.http.get<enterprise_enterprise>("enterprice/relationbetweenenterprise");
  }


  getAllRolesByEnterprice(ruc_empresa:string):Observable<number[]>
  {
    return this.http.get<number[]>("enterprice/roles/"+ruc_empresa);
  }


}
