import {Component, EventEmitter, Output} from '@angular/core';

import {  Enterprise, DocumentFilter} from 'src/app/_models';
import { FormBuilder } from '@angular/forms';
import { NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';
import { getLocaleDateTimeFormat, DatePipe } from '@angular/common';
import { datepickerAnimation } from 'ngx-bootstrap/datepicker/datepicker-animations';
import { PaymentDocumentsService } from 'src/app/_services';


@Component({
  selector: 'document-filter',
  templateUrl: './document-filter.component.html'
})
export class DocumentFilterComponent {
  
  fecha_emision_inferior: Date;
  fecha_emision_superior: Date;

  @Output() emmiterFilter: EventEmitter<DocumentFilter> = new EventEmitter<DocumentFilter>();
  @Output() ExportEmmiter: EventEmitter<DocumentFilter> = new EventEmitter<DocumentFilter>();

  constructor(private _documentService: PaymentDocumentsService,
    private datePipe: DatePipe)
  {

  }

  public document_filter: DocumentFilter =
  {
    ruc_empresa_cliente : [],
    id_tipo_documento_estado : [],
    ruc_empresa_proveedor :[],
    fecha_emision_inferior:new Date(),
    fecha_emision_superior:new Date(),
    fis_elec : []
  };


  estatusDocument = [
    {id: 1, nombre: 'Verificado'},
    {id: 2, nombre: 'Transferido'},
    {id: 3, nombre: 'Contabilizado'},
    {id: 4, nombre: 'Rechazado'},
  ];
  ruc_empresa_cliente:string[]=[];
  id_documento_estado:number[]=[];

  

  public _ActiveClients:Enterprise[] = [];

  form : any;

  onDateInferiorSelect(event){
    let ngbDate = event;
    let myDate = new Date(ngbDate.year, ngbDate.month-1, ngbDate.day);
    this.fecha_emision_inferior = myDate
    console.log('fecha_emision_inferior : '+ this.fecha_emision_inferior);
  }

  onDateSuperiorSelect(event){
    let ngbDate = event;
    let myDate = new Date(ngbDate.year, ngbDate.month-1, ngbDate.day);
    this.fecha_emision_superior = myDate
    console.log('fecha_emision_superior : '+ this.fecha_emision_superior);
  }

  public buscar ()
  {
    

    /*
    var myDate = this.fecha_emision_inferior;
    let day = myDate.getDate()
    let month = myDate.getMonth() + 1
    let year = myDate.getFullYear()
    console.log(day+'/'+month+'/'+year);
    */
    this.updateFilters();
    this.emmiterFilter.emit(this.document_filter);
  }

  public exportar()
  {
    this.updateFilters();
    this.ExportEmmiter.emit(this.document_filter)
  }

  updateFilters()
  {
    this.document_filter.ruc_empresa_cliente = this.ruc_empresa_cliente;
    console.log('ruc empresa ciente :'+this.document_filter.ruc_empresa_cliente);
    
    this.document_filter.id_tipo_documento_estado = this.id_documento_estado;
    console.log('id_estado :'+this.document_filter.id_tipo_documento_estado);

    this.document_filter.fecha_emision_inferior = this.fecha_emision_inferior;
    console.log('fecha_emision_inferior :'+this.document_filter.fecha_emision_inferior);

    this.document_filter.fecha_emision_superior = this.fecha_emision_superior;
    console.log('fecha_emision_superior :'+this.document_filter.fecha_emision_superior);
  }
  


  cambio_fecha()
  {
   this.document_filter.fecha_emision_inferior = this.fecha_emision_inferior;
   this.document_filter.fecha_emision_superior = this.fecha_emision_superior;
  }

  


}

