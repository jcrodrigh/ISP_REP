import {Component, OnInit, ViewChild} from '@angular/core';
import {HttpRequest, HttpEventType, HttpClient} from '@angular/common/http';
import * as FileSaver from 'file-saver';
import {Enterprise, Documentx, ErrorsByDocument} from 'src/app/_models';
import {PaymentDocumentsService} from 'src/app/_services';
import {DocumentCardComponent} from '../../_utilitaries/document/document.component';
import { DocumentsTableComponent } from 'src/app/views/_utilitaries/document/document-table/document-table.component';
import { DocumentsErrorsTableComponent } from '../../_utilitaries/document/document-errors-table/document-errors-table.component';



const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';



@Component({
  selector: 'documents-errors-resume',
  templateUrl: './documents-errors-resume.component.html',
  //styleUrls:["./documents-form.component.css"]
})
export class DocumentsErrorsResumeComponent implements OnInit {
  
  //@ViewChild('DocumentErrorTable', {static: false}) public DocumentErrorTable: DocumentsErrorsTableComponent;
  _documentsWithErrors: ErrorsByDocument[];
  

  constructor(private _paymentDocumentsService: PaymentDocumentsService,
    private http: HttpClient) {
  }

  ngOnInit() {
    /*this._paymentDocumentsService.GetDocumentWithError().subscribe(
      docs=> {
        //this._documentsToApprove = docs;
        this.DocumentErrorTable._documentsWithErrors = docs;
        
      }
    )*/

  }

  Importar()
  {
    return this.http.get<Blob>(`Document/errors/export`,
    {responseType: 'blob' as 'json'})
    .subscribe(
      blob => {
        this.saveAsBlob(blob);
      },
      error => {
        console.log('Something went wrong');
      });
  }

  private saveAsBlob(data: any) {
    const blob = new Blob([data],
      {type: EXCEL_TYPE});
    const file = new File([blob], 'DocumentErrors.xlsx',
      {type: EXCEL_TYPE});

    FileSaver.saveAs(file);
  }

  

}

