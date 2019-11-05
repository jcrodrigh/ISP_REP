import {NgModule} from '@angular/core';
import {CommonModule, DatePipe} from '@angular/common';

import {CollapseModule} from 'ngx-bootstrap/collapse';

import {FormsModule, ReactiveFormsModule} from '@angular/forms';



import { DocumentTransferTableComponent} from './document-transfer-table/document-transfer-table.component';

import {SweetAlert2Module} from '@sweetalert2/ngx-sweetalert2';


import {ModalModule} from 'ngx-bootstrap';
import {CarouselModule} from 'ngx-bootstrap/carousel';


import { _PipeModule } from 'src/app/_pipes/pipe.module';
import { _UtilitariesModule } from '../_utilitaries/_utilitaries.module';
import { TransferRoutingModule } from './Transfer.routing';


import { NgSelectModule } from '@ng-select/ng-select';

import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  imports: [
    CommonModule,
    CollapseModule,
    FormsModule, ReactiveFormsModule,
    TransferRoutingModule,
    SweetAlert2Module.forRoot({
      buttonsStyling: false,
      customClass: 'modal-content',
      confirmButtonClass: 'btn btn-primary',
      cancelButtonClass: 'btn'
    }),
    ModalModule.forRoot(),
    CarouselModule.forRoot(),
    BsDropdownModule.forRoot(),
    NgbModule,

    _UtilitariesModule,
    _PipeModule,

    NgSelectModule

  ],
  declarations: [DocumentTransferTableComponent,
   ],
  entryComponents: [],
  providers: [],
})
export class TransferModule {
}
