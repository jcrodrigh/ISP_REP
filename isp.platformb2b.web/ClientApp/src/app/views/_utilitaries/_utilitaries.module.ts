import {NgModule} from '@angular/core';
import {CommonModule, DatePipe} from '@angular/common';

import {CollapseModule} from 'ngx-bootstrap/collapse';

import {FormsModule, ReactiveFormsModule} from '@angular/forms';


import {SweetAlert2Module} from '@sweetalert2/ngx-sweetalert2';
import { Component } from '@angular/core';
import {CarouselModule, ModalModule, TooltipModule} from 'ngx-bootstrap';
import {DocumentDataComponent} from './document/document-data/document-data.component';
import {DocumentDisplayComponent} from './document/document-display/document-display.component';
import {DocumentCardComponent} from './document/document.component';

import { DocumentsTableComponent } from './document/document-table/document-table.component';
import { DocumentsErrorsTableComponent } from './document/document-errors-table/document-errors-table.component';
import { _PipeModule } from 'src/app/_pipes/pipe.module';
import { NgbdSortableHeader } from './document/document-table/sortable.directive';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {  DocumentFilterComponent } from './document/document-filter/document-filter.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { EnterpriseListComponent } from './enterprise/enterprise-list/enterprise-list.component';



@NgModule({
  imports: [
    CommonModule,
    CollapseModule,
    FormsModule, ReactiveFormsModule,

    SweetAlert2Module.forRoot({
      buttonsStyling: false,
      customClass: 'modal-content',
      confirmButtonClass: 'btn btn-primary',
      cancelButtonClass: 'btn'
    }),
    CarouselModule.forRoot(),
    ModalModule.forRoot(),
    TooltipModule.forRoot(),
    
    _PipeModule,

    NgbModule,
    NgSelectModule
  ],
  declarations: [DocumentDisplayComponent,
    DocumentDataComponent,
    DocumentCardComponent,
    DocumentsTableComponent,
    DocumentsErrorsTableComponent,
    DocumentFilterComponent,
    EnterpriseListComponent,
    NgbdSortableHeader,
    
    
  ],
  entryComponents: [],
  exports: [DocumentDisplayComponent,
    DocumentsTableComponent,
    DocumentDataComponent,
    DocumentsErrorsTableComponent,
    DocumentFilterComponent,
    EnterpriseListComponent,
    DocumentCardComponent]
  //providers:[DocumentsFormService],
})
export class _UtilitariesModule {
}
