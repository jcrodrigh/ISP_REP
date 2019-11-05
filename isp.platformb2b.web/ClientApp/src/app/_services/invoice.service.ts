import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  constructor(private http:HttpClient) { }

  getInvoice ():Observable<any[]>{
    return this.http.get<any[]>(`Invoice/entrada`);
  }
}
