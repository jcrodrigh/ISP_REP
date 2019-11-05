import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {HttpRequest, HttpEventType, HttpClient} from '@angular/common/http';
import * as FileSaver from 'file-saver';
import {Enterprise, Documentx, ErrorsByDocument} from 'src/app/_models';
import {PaymentDocumentsService} from 'src/app/_services';



@Component({
  selector: 'documents-errors-table',
  templateUrl: './document-errors-table.component.html',
  //styleUrls:["./documents-form.component.css"]
})
export class DocumentsErrorsTableComponent implements OnInit {

  
  public _documentsWithErrors: ErrorsByDocument[];
  

  

  ngOnInit() {
    
  }


}

