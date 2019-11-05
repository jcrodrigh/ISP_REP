import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { _PipeModule } from '../_pipes/pipe.module';
import { _UtilitariesModule } from '../views/_utilitaries/_utilitaries.module';
import { ModalModule } from 'ngx-bootstrap';
import { _DirectiveModule } from '../_directive/directive.module';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';

@NgModule({
  
  imports: [
    CommonModule,
    NgSelectModule,
    NgbModule,
    FormsModule, 
    ReactiveFormsModule,
    _PipeModule,
    _UtilitariesModule,
    SweetAlert2Module.forRoot({
      buttonsStyling: false,
      customClass: 'modal-content',
      confirmButtonClass: 'btn btn-primary',
      cancelButtonClass: 'btn'
    }),
    
    
    
  ],
  exports:[
    CommonModule,
    NgSelectModule,
    NgbModule,
    FormsModule, 
    ReactiveFormsModule,
    _PipeModule,
    _UtilitariesModule,
    SweetAlert2Module
    
  ]
})
export class SharedModule { }
