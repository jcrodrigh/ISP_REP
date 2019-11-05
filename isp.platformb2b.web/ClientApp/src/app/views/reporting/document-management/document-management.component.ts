import { Component, OnInit, ViewChildren, QueryList, ViewChild } from '@angular/core';
import { DocumentFilter, Enterprise,  DocumentGestion, Documentx, DocumentFile } from 'src/app/_models';

import { Observable } from 'rxjs';
import { PaymentDocumentsService, EnterpriceService, ExportFileService } from 'src/app/_services';
import { ActivatedRoute } from '@angular/router';
import { DecimalPipe, DatePipe } from '@angular/common';
import { DocumentManagementService } from './document-management.service';
import { getDate } from 'ngx-bootstrap/chronos/utils/date-getters';
import { FormGroup } from '@angular/forms';
import { DocumentCardComponent } from '../../_utilitaries/document/document.component';
import { NgbdSortableHeader2, SortEvent2 } from './sortable.directive';

@Component({
  selector: 'app-document-management',
  templateUrl: './document-management.component.html',
  // styleUrls: ['./document-management.component.css'],
  providers: [DocumentManagementService, DecimalPipe],
})
export class DocumentManagementComponent {

  @ViewChild('UploadImage', {static: false}) public UploadImage: DocumentCardComponent;
  
  txtruc_empresa_cliente:string;
  txtruc_empresa_proveedor:string;

  ruc_empresa_cliente:string[]=[];
  ruc_empresa_proveedor:string[]=[];

  id_documento_estado:number[]=[];

  ruta_excel : DocumentFile;

  fis_elec : boolean[]=[];
  tipo_emision : string[];
  fecha_emision_inferior : string;
  fecha_emision_superior : string;



estatusDocument = [
  {id: 2, nombre: 'Transferido'},
  {id: 3, nombre: 'Contabilizado'},
  {id: 4, nombre: 'Rechazado'},
]

tipoEmision = [
  {id: false, nombre: 'Electronico'},
  {id: true, nombre: 'Fisico'},
]

public document_filter: DocumentFilter =
{
ruc_empresa_cliente : [],
id_tipo_documento_estado : [],
ruc_empresa_proveedor :[],
fis_elec : []
};

public _documentsToApprove: DocumentGestion[];

@ViewChildren(NgbdSortableHeader2) headers: QueryList<NgbdSortableHeader2>;





_ActiveClients:Enterprise[];
_ActiveProviders: Enterprise[];

_DocActiveObservations:any[]=[];
_DocActiveApprove:any[]=[];
_DocActivePending:any[]=[];

_DocumentsClientProvider:any[]=[];




_ruc_empresa_cliente:string;
_ruc_empresa_proveedor:string;

documents$: Observable<DocumentGestion[]>;
total$: Observable<number>;

documentos : DocumentGestion[];
filters:DocumentFilter;


//**************** Disabled Controles ******************/

disabledSelectCliente : boolean;
disabledTextCliente : boolean;

disabledSelectProveedor : boolean;
disabledTextProveedor : boolean;

//*****************************************************/


form: FormGroup;

constructor (private _paymentDocumentsService:PaymentDocumentsService,
  private _enterpriceService: EnterpriceService,
  private _route: ActivatedRoute,public service: DocumentManagementService,
  private _exportFileService:ExportFileService,
  private datePipe: DatePipe) 
{
  this.documents$ = service.documents$;
  this.total$ = service.total$;

  //activamos los controles
  this.disabledSelectCliente = false;
  this.disabledTextCliente = false;

  //llenamos los filtros de fechas
  let yesterday = new Date();
  yesterday.setDate(yesterday.getDate()-1);

  let today = new Date();
  today.setDate(today.getDate());

  this.fecha_emision_inferior = this.datePipe.transform(yesterday, 'yyyy-MM-dd');
  this.fecha_emision_superior = this.datePipe.transform(today, 'yyyy-MM-dd');

  this.txtruc_empresa_cliente="";
  this.txtruc_empresa_proveedor="";

  this.documentos = [];

  //Obtenemos clientes
  _enterpriceService.GetActivesClients().subscribe(ent=>
      {
          this._ActiveClients= ent;
      })

  //Obtenemos Proveedores
  _enterpriceService.GetActivesProviders().subscribe(ent=>
      {
          this._ActiveProviders= ent;
      })
}


buscar ()
{

  if(this.txtruc_empresa_cliente!="")
  {
    this.document_filter.ruc_empresa_cliente = [this.txtruc_empresa_cliente]
  }else
  {
    this.document_filter.ruc_empresa_cliente = this.ruc_empresa_cliente;
  }

  if(this.txtruc_empresa_proveedor!="")
  {
    this.document_filter.ruc_empresa_proveedor = [this.txtruc_empresa_proveedor]
  }else
  {
    this.document_filter.ruc_empresa_proveedor = this.ruc_empresa_proveedor;
  }
  
  this.document_filter.id_tipo_documento_estado = this.id_documento_estado;
  this.document_filter.fis_elec = this.fis_elec;
  this.document_filter.fecha_emision_inferior = new Date(this.fecha_emision_inferior);
  this.document_filter.fecha_emision_superior = new Date(this.fecha_emision_superior);

  this._paymentDocumentsService.GetDocumentwithFilterGestion(this.document_filter)
  .subscribe(docs => {
    console.log('entró',docs)
    this.passDocumentx(docs);
  });

}

onKeyupCliente(event:any) {
  
  if(event.length>0)
  {
    this.disabledSelectCliente = true;
    this.ruc_empresa_cliente = [];
  }else{
    this.disabledSelectCliente = false;
  }
}

onKeyupProveedor(event:any) {

  if(event.length>0)
  {
    this.disabledSelectProveedor = true;
    this.ruc_empresa_proveedor = [];
  }else{
    this.disabledSelectProveedor = false;
  }
}

onSelectClienteChange(event:any){

  this.txtruc_empresa_cliente="";

  if(this.ruc_empresa_cliente.length>0){
    this.disabledTextCliente = true;
  }
  else{
    this.disabledTextCliente = false;
  }  
}

onSelectProveedorChange(event:any){

  this.txtruc_empresa_proveedor="";

  if(this.ruc_empresa_proveedor.length>0){
    this.disabledTextProveedor = true;
  }
  else{
    this.disabledTextProveedor = false;
  }  
}

passDocument(doc:Documentx)
{
  this.UploadImage.passDocument(doc);
}

public passDocumentx ( documentsToApprove: DocumentGestion[])
{
 this.documentos = documentsToApprove;
 this.service.documentsX = documentsToApprove;
 console.log('mecmec recibió',this.service.documentsX);
 this.service.mecmec();
}

onSort({column, direction}: SortEvent2) {
  // resetting other headers
  this.headers.forEach(header => {
    if (header.sortable !== column) {
      header.direction = '';
    }
  });

  this.service.sortColumn = column;
  this.service.sortDirection = direction;
  
}






showDocuments(ruc_empresa_cliente:string)
{
  this._paymentDocumentsService.GetDocumentWithQuery([ruc_empresa_cliente],[2,3,4])
  .subscribe(docs=> 
      {console.log(docs);
          //this.DocumentTable.passDocumentx(docs);

      });
}





exportar(){

  this._paymentDocumentsService.ExportDataIVM(this.document_filter).subscribe(ruta=>
    {
      if(ruta.code==0)
      {
        this.ruta_excel = ruta.content;
        console.log('ruta excel: '+this.ruta_excel);
       
        const linkSource = `data:${this.ruta_excel.content_type};base64,${this.ruta_excel.data}`;
        const downloadLink1 = document.createElement("a");
        downloadLink1.href = linkSource;
        downloadLink1.download = this.ruta_excel.nombre_file;
        downloadLink1.click();
      }else{
        alert(ruta.message);
      };
    });

}


}
