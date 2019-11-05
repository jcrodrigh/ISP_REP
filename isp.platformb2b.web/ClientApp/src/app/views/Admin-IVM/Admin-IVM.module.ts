import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';

import { CollapseModule } from 'ngx-bootstrap/collapse';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { AdminIVMRoutingModule } from './Admin-IVM.routing';
import { AdminDocumentsComponent } from './admin-documents/admin-documents.component';


import { ModalModule } from 'ngx-bootstrap';
import { _UtilitariesModule } from '../_utilitaries/_utilitaries.module';
import { DocumentsErrorsResumeComponent } from './document-errors-resume/documents-errors-resume.componet';

@NgModule({
  imports: [
    CommonModule,
    CollapseModule,
    FormsModule, ReactiveFormsModule,
    AdminIVMRoutingModule,
    SweetAlert2Module.forRoot({
      buttonsStyling: false,
      customClass: 'modal-content',
      confirmButtonClass: 'btn btn-primary',
      cancelButtonClass: 'btn'
  }),
  ModalModule.forRoot(),
  _UtilitariesModule,

  ],
  declarations: [  AdminDocumentsComponent,
    DocumentsErrorsResumeComponent,
    
    

  ],
  entryComponents: [],
  providers:[],
})
export class AdminIVMModule { }
