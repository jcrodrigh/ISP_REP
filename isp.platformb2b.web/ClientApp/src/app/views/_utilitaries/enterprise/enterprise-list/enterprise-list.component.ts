import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Enterprise } from 'src/app/_models';

@Component({
  selector: 'enterprise-list',
  templateUrl: './enterprise-list.component.html',
  styleUrls: ['./enterprise-list.component.css']
})
export class EnterpriseListComponent implements OnInit {
  public List_Enterprice: Enterprise[];

  @Output() ruc_empresas_emmiter: EventEmitter<string[]> = new EventEmitter<string[]>();

  list_ruc_enterpises: string[]= [];


  constructor() { }

  ngOnInit() {
  }

  clickInItem (ruc_empresa:string)
  {
    this.list_ruc_enterpises = [ruc_empresa];
    this.ruc_empresas_emmiter.emit(this.list_ruc_enterpises)

  }

  include_trucho(ruc_empresa:string)
  {
    /*for (var i = 0; i<this.list_ruc_enterpises.length; i++)
    {
      if (this.list_ruc_enterpises[i]==ruc_empresa)  return true;
    }*/
    //this.list_ruc_enterpises.includes(ruc_empresa)
    return  this.list_ruc_enterpises.includes(ruc_empresa);
  }

}
