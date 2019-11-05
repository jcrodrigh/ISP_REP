import {Component, ViewChild} from '@angular/core';
import {ModalDirective} from 'ngx-bootstrap/modal';

import {Documentx, DocumentFile, TypesOfDocument} from 'src/app/_models';

import {PaymentDocumentsService, MasterTablesService} from 'src/app/_services';
//import { timingSafeEqual } from 'crypto';
//import { DocumentsExcelComponent } from '../../provider/payment-documents/documents-excel/documents-excel.component';


@Component({
  selector: 'document-card',
  templateUrl: './document.component.html',
  styleUrls:["./document.component.css"]
})
export class DocumentCardComponent {
  documentWithoutImage: Documentx[];
  ruta_imagenftp : DocumentFile;
  

  ruta_file : string;

  public _showButtons = true;
  //public showButtons = true;
  @ViewChild('UploadImageModal', {static: false}) private UploadImageModal: ModalDirective;
  //@ViewChild('UploadExcel', {static: false}) public UploadExcel: DocumentsExcelComponent;

  constructor(private _iServicesDocument: PaymentDocumentsService) { }


  set showButtons(value: boolean) {
    this._showButtons = value;
  }


  get showButtons(): boolean {
    return this._showButtons;
  }

  public show(id: number) {
    this._iServicesDocument.GetDocumentByInternalId(id).subscribe(doc =>
      this.documentWithoutImage = [doc]);
    this.UploadImageModal.show();
  }

  public passDocument (doc:Documentx)
  {
    this.documentWithoutImage = [doc];
    this.UploadImageModal.show();
  }

  public open(): void {
    this._iServicesDocument.GetDocumentsWithoutImage().subscribe(doc =>
      this.documentWithoutImage = doc);
    this.UploadImageModal.show();

  }

  public MostrarDocumentosCorrectos(docs : Documentx[]):void{
    this.documentWithoutImage = docs;
    this.showButtons = true;
    this.UploadImageModal.show();  
  }

  public FinalizarEvento(){
    console.log('imagenes cargadas : '+this.documentWithoutImage);
    this.UploadImageModal.hide();
  }

}
