import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';


import { Observable } from 'rxjs';
import { KeysValues, TypesOfDocument,  Documentx, ErrorsByDocument, DocumentFilter, DocumentGestion, ResultMessage2, DocumentFile } from '../_models';
import {ResultMessage} from '../_models/resultMessage';

@Injectable({
  providedIn: 'root'
})
export class PaymentDocumentsService {


  constructor(private http:HttpClient) { }

  public uploadImage(image: File): Observable<any> {
    const formData = new FormData();

    formData.append('file', image);

    return this.http.post('document/imagenx', formData);


    //return this.http.get<KeysValues[]>("MasterTables/document");
  }

  public uploadDto (documentDTO: any):Observable<Documentx>
  {
    return this.http.post<Documentx>('document/webiando',documentDTO);
  }

  public uploadDtoMasivo (document: any):Observable<ResultMessage2>
  {
    return this.http.post<ResultMessage2>('document/cargamasiva',document);
  }
 


  public UploadImagesWithoutDocument(frmData:any):Observable<string[]>
  {
    return this.http.post<string[]>('Document/imagenx/',frmData);
  }

  

  public GetDocumentsByRucProvider(): Observable<Documentx[]>
  {
    return this.http.get<Documentx[]>('document/GetDocumentsByRucProvider');
  }

  public DeleteImageWithouDocument(namefile:string):Observable<any>
  {
    return this.http.delete<any>('imagen/delete/'+namefile);
  }

  

  public GetDocumentByInternalId ( id_interno:number):Observable<Documentx>
  {
    return this.http.get<Documentx>('document/GetDocumentByID/'+String(id_interno));
  }

  public GetDocumentsWithoutImage ():Observable<Documentx[]>
  {
    return this.http.get<Documentx[]>('Document/WithoutImage');
  }

  public ApproveDocument (id_interno: number):Observable<any>
  {
    return this.http.put('DocumentStatus/approve/'+String(id_interno),[]);
  }

  public RejectDocument (id_interno: number,id_tipo_documento_devolucion:string):Observable<any>
  {
    return this.http.put('DocumentStatus/reject/'+String(id_interno)+'/'+id_tipo_documento_devolucion,[]);
  }

  public UploadImages (id_file:string,frmData:any):Observable<string[]>
  {
    return this.http.post<string[]>('Document/imagen/insert/'+id_file,frmData);
  }

  public DeleteImage (id_document:string, namefile):Observable<string[]>
  {
    return this.http.delete<string[]>('Document/imagen/delete/'+id_document+'/'+namefile);
  }


  
  public GetAllDocumentsByClient (ruc_client:string ):Observable<Documentx[]>
  {
    return this.http.get<Documentx[]>('Document/Client/'+ruc_client);
  }

  public GetDocumentWithError ():Observable<ErrorsByDocument[]>
  {
    return this.http.get<ErrorsByDocument[]>('Document/errors/all');
  }

  public GetDocumentWithQuery (ruc_client:string[]=[],id_tipo_documento_estado:number[]=[])
  :Observable<Documentx[]>
  {

    console.log('ruc_cliente',ruc_client);
    console.log('id_tipo_documento_estado',id_tipo_documento_estado)
    let params = new HttpParams();
    for (var i = 0; i<ruc_client.length;i++)
    {
      
        params= params.append('ruc_empresa_cliente',ruc_client[i]);
         
      
    }
      
    for (var i = 0; i<id_tipo_documento_estado.length;i++)
    {
      
        
        params= params.append('id_tipo_documento_estado',String(id_tipo_documento_estado[i]));
         
      
    }
    /*let params = new HttpParams().append('ruc_empresa_cliente',ruc_client.join(', ') )
      .append('id_tipo_documento_estado','2')
      .append('id_tipo_documento_estado','3')
      .append('id_tipo_documento_estado','4')*/
      return this.http.get<Documentx[]> ('Document/query',{params})
  }

  public GetDocumentwithFilterByProvider (filter:DocumentFilter)
  :Observable<Documentx[]>
  {
    return this.http.post<Documentx[]>("Document/filter/provider",filter);
  }

  public GetDocumentwithFilterByClient (filter:DocumentFilter)
  :Observable<Documentx[]>
  {
    return this.http.post<Documentx[]>("Document/filter/client",filter);
  }

  public GetDocumentwithFilter (filter:DocumentFilter)
  :Observable<Documentx[]>
  {
    return this.http.post<Documentx[]>("Document/filter/ivm",filter);
  }

  public GetDocumentwithFilterGestion (filter:DocumentFilter)
  :Observable<DocumentGestion[]>
  {
    return this.http.post<DocumentGestion[]>("Document/filter/ivmgestion",filter);
  }

  public ExportDataIVM (filter:DocumentFilter)
  :Observable<ResultMessage<DocumentFile>>
  {
    return this.http.post<ResultMessage<DocumentFile>>("Document/Export/ivm",filter);
  }

  public ExportDataByProvider (filter:DocumentFilter)
  :Observable<Documentx[]>
  {
    return this.http.post<Documentx[]>("Export/provider",filter);
  }

  public GetUrlDocumentSftp(nombre_imagen:string,id_tipo_documento:string):Observable<ResultMessage<DocumentFile>>
  {
    return this.http.get<ResultMessage<DocumentFile>>("Document/file/createftp/"+nombre_imagen+"/"+id_tipo_documento);
  }

}
