import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


import { Observable } from 'rxjs';
import { PurchaseOrder } from '../_models';

@Injectable({
  providedIn: 'root'
})
export class PurchaseOrderService {


  constructor(private http:HttpClient) { }

  getPurchaseOrderByClient (ruc_client:string):Observable<Array<PurchaseOrder>>{
    return this.http.get<PurchaseOrder[]>("PurcharseOrder/client/" +ruc_client);
  }
}
