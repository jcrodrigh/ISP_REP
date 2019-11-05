import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


import { Observable } from 'rxjs';
import { KeysValues, TypesOfDocument, detraction, SerialDocuments, KV_StringNumber } from '../_models';
import { KeyValue } from '@angular/common';


@Injectable({
  providedIn: 'root'
})
export class MasterTablesService {


  constructor(private http:HttpClient) { }

  getAllTypeDocument ():Observable<KeysValues[]>{
    return this.http.get<KeysValues[]>("MasterTables/document");
  }

  getAllTypeCurrency ():Observable<KeysValues[]>{
    return this.http.get<KeysValues[]>("MasterTables/currency");
  }

  getAllTypeDocumentComplete ():Observable<TypesOfDocument[]>{
    return this.http.get<TypesOfDocument[]>("MasterTables/document/all");
  }

  getAllDetractions () : Observable <detraction[]>
  {
    return this.http.get<detraction[]>("MasterTables/detraction/all");
  }

  getAllRejection () : Observable <KeysValues[]>
  {
    return this.http.get<KeysValues[]>("MasterTables/Rejection");
  }
  
  GetListDocumentSerialByTypeDocument(): Observable< SerialDocuments[]>
  {
    return this.http.get<SerialDocuments[]>("MasterTables/document/serial");
  }

  GetTypeOfDocumentByID(id_tipo_documento:string):Observable<TypesOfDocument>
  {
    return this.http.get<TypesOfDocument>("MasterTables/document/"+id_tipo_documento);
  }

  GetTypesEnterprisesERP():Observable<KV_StringNumber[]>
  {
    return this.http.get<KV_StringNumber[]>("MasterTables/enterprise/erp/all")
  }

}
