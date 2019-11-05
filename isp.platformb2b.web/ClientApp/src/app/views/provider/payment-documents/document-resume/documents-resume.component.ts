import {Component, OnInit, ViewChild, AfterViewInit} from '@angular/core';
import {HttpRequest, HttpEventType, HttpClient} from '@angular/common/http';
import * as FileSaver from 'file-saver';
import {Enterprise, Documentx, DocumentFilter} from 'src/app/_models';
import {PaymentDocumentsService, EnterpriceService, ExportFileService} from 'src/app/_services';
import {DocumentCardComponent} from '../../../_utilitaries/document/document.component';
import { DocumentsTableComponent } from 'src/app/views/_utilitaries/document/document-table/document-table.component';
import { DocumentFilterComponent } from 'src/app/views/_utilitaries/document/document-filter/document-filter.component';



const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';

@Component({
  selector: 'documents-resume',
  templateUrl: './documents-resume.component.html',
  //styleUrls:["./documents-form.component.css"]
})
export class DocumentsResumeComponent implements OnInit,AfterViewInit {
  ngAfterViewInit(): void {
    this.DocumentTable.ivm_flag = true;
  }
  

  @ViewChild('DocumentTable', {static: false}) public DocumentTable: DocumentsTableComponent;
  @ViewChild('Filter', {static: false}) public Filter: DocumentFilterComponent;
  _documentsToApprove: Documentx[];
  

  constructor(private _paymentDocumentsService: PaymentDocumentsService,
      private _enterpriceService: EnterpriceService,
      private _exportFileService:ExportFileService,
    ) {
  }

  ngOnInit() {
    
    this._paymentDocumentsService.GetDocumentsByRucProvider().subscribe(
      docs=> {
        //this._documentsToApprove = docs;
        this.DocumentTable._documentsToApprove = docs;
        
      }
    )

    this._enterpriceService.getAllClientBySupplier().subscribe(
      ent => {
        console.log(ent);
        this.Filter._ActiveClients = ent;
      }
    );

  }

  passFilter(filters:DocumentFilter)
  {
    console.log('filters : '+filters); 
  
    if (filters.fecha_emision_inferior || filters.fecha_emision_superior)
    {
      filters.id_tipo_documento_estado = [1,2,3,4,5];     
    }
    else
    {
      filters.id_tipo_documento_estado = [1,5];
    }
    //solo los verificados :V
    
    this._paymentDocumentsService.GetDocumentwithFilterByProvider(filters)
      .subscribe(docs => {
        console.log('entró',docs)
        this.DocumentTable.passDocumentx (docs)});
  }

  ExportData(filter:DocumentFilter)
    {
      //solo los verificados :V
      filter.id_tipo_documento_estado = [1,2,3,4,5];
        this._exportFileService.ExportDataByProvider(filter);
    }
  

}

