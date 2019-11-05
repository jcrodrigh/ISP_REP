import {NgModule} from '@angular/core';
import {CommonModule, DatePipe} from '@angular/common';

import {CollapseModule} from 'ngx-bootstrap/collapse';

import {FormsModule, ReactiveFormsModule} from '@angular/forms';


import {DocumentsFormService} from './documents-form/documents-form.service';
import {DocumentsFormComponent} from './documents-form/documents-form.component';
import {PaymentDocumentsRoutingModule} from './payment-documents.routing';
import {DocumentsExcelComponent} from './documents-excel/documents-excel.component';
import {SweetAlert2Module} from '@sweetalert2/ngx-sweetalert2';


import {ModalModule} from 'ngx-bootstrap';
import {CarouselModule} from 'ngx-bootstrap/carousel';
import {_UtilitariesModule} from '../../_utilitaries/_utilitaries.module';
import {DocumentCardComponent} from '../../_utilitaries/document/document.component';
import { DocumentsResumeComponent } from './document-resume/documents-resume.component';
import { _PipeModule } from 'src/app/_pipes/pipe.module';




@NgModule({
  imports: [
    CommonModule,
    CollapseModule,
    FormsModule, ReactiveFormsModule,
    PaymentDocumentsRoutingModule,
    SweetAlert2Module.forRoot({
      buttonsStyling: false,
      customClass: 'modal-content',
      confirmButtonClass: 'btn btn-primary',
      cancelButtonClass: 'btn'
    }),
    ModalModule.forRoot(),
    CarouselModule.forRoot(),
    _UtilitariesModule,
    _PipeModule

  ],
  declarations: [DocumentsFormComponent,
    DocumentsExcelComponent,
    DocumentsResumeComponent,
    
    

  ],
  entryComponents: [],
  providers: [DocumentsFormService],
})
export class PaymentDocumentsModule {
}
