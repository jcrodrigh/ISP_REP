import {AfterViewInit, Component, OnInit, ViewChild, ViewChildren, QueryList, Output, EventEmitter} from '@angular/core';

import { Documentx, Enterprise, DocumentFilter} from 'src/app/_models';

import {DocumentCardComponent} from '../../../_utilitaries/document/document.component';
import { SortEvent, NgbdSortableHeader } from './sortable.directive';
import { DocumentTableService } from './document-table.service';
import { Observable } from 'rxjs';
import { DecimalPipe } from '@angular/common';
import { DocumentFilterComponent } from '../document-filter/document-filter.component';




@Component({
  selector: 'documents-table',
  templateUrl: './document-table.component.html',
  providers: [DocumentTableService, DecimalPipe]
  //styleUrls:["./document-table.component.css"]
})
export class DocumentsTableComponent implements OnInit,AfterViewInit {
  public ivm_flag:boolean = true;
  public _documentsToApprove: Documentx[];
  @ViewChild('UploadImage', {static: false}) public UploadImage: DocumentCardComponent;
  
  

  documents$: Observable<Documentx[]>;
  total$: Observable<number>;
  filter:DocumentFilter;

  @Output() emmiterTableFilter = new EventEmitter<DocumentFilter>();


  @ViewChildren(NgbdSortableHeader) headers: QueryList<NgbdSortableHeader>;

  constructor(public service: DocumentTableService) {
    this.documents$ = service.documents$;
    this.total$ = service.total$;
  }

  ngOnInit() {
    
  }

  public passDocumentx ( documentsToApprove: Documentx[])
  {
    
    this._documentsToApprove = documentsToApprove;
    this.service.documentsX = documentsToApprove;
    console.log('mecmec recibió',this.service.documentsX);
    this.documents$ = this.service.documents$;
    this.total$ = this.service.total$;
    this.service.mecmec ();
  }
 

  showDetails(id: number) {
    this.UploadImage.show(id);
  }

  ngAfterViewInit(): void {
    this.UploadImage._showButtons = false;
  }

  passDocument(doc:Documentx)
  {
    this.UploadImage.passDocument(doc);
  }

  

  

  onSort({column, direction}: SortEvent) {

    // resetting other headers
    this.headers.forEach(header => {
      if (header.sortable !== column) {
        header.direction = '';
      }
    });

    this.service.sortColumn = column;
    this.service.sortDirection = direction;
  }

}
/*
import {Component, QueryList, ViewChildren} from '@angular/core';
import {DecimalPipe} from '@angular/common';

import {Observable} from 'rxjs';
import {CountryService} from './country.service';
import {Country} from './country';
import {NgbdSortableHeader, SortEvent} from './sortable.directive';

@Component({
  selector: 'ngbd-table-complete',
  templateUrl: './table-complete.html',
  providers: [CountryService, DecimalPipe]
})
export class NgbdTableComplete {
  countries$: Observable<Country[]>;
  total$: Observable<number>;

  @ViewChildren(NgbdSortableHeader) headers: QueryList<NgbdSortableHeader>;

  constructor(public service: CountryService) {
    this.countries$ = service.countries$;
    this.total$ = service.total$;
  }

  onSort({column, direction}: SortEvent) {

    // resetting other headers
    this.headers.forEach(header => {
      if (header.sortable !== column) {
        header.direction = '';
      }
    });

    this.service.sortColumn = column;
    this.service.sortDirection = direction;
  }
}
*/
