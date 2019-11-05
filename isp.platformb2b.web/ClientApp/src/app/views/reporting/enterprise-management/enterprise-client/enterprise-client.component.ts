import { Component, OnInit, ViewChild, QueryList, ViewChildren } from '@angular/core';

import { EnterpriseModalComponent } from './enterprise-modal/enterprise-modal.component';
import { Enterprise } from 'src/app/_models';
import { EnterpriceService } from 'src/app/_services';
import { Observable } from 'rxjs';
// import { NgbdSortableHeader, SortEvent } from 'src/app/_directive/sortable.directive';
import { DecimalPipe } from '@angular/common';
import { EnterpriseClientService } from './enterprise-client.service';
import { NgbdSortableHeader3, SortEvent3 } from './sortable.directive';
import { SwalComponent } from '@sweetalert2/ngx-sweetalert2';
import { EventEmitter } from 'protractor';
import { Router } from '@angular/router';
//import { NgbdSortableHeader3, SortEvent } from 'src/app/_directive/sortable.directive';



@Component({
  selector: 'enterprise-client',
  templateUrl: './enterprise-client.component.html',
  styleUrls: ['./enterprise-client.component.css'],
   providers: [EnterpriseClientService,DecimalPipe]
})
export class EnterpriseClientComponent implements OnInit {
  
  @ViewChild('SuccessSwal', {static: false}) private SuccessSwal: SwalComponent;
  @ViewChild('DeleteSwal', {static: false}) private DeleteSwal: SwalComponent;

  ruta:string = 'reporting/ranking';
  titulos = {eliminar: "Desactivar Empresa."}
  
  enterprices$:Observable<Enterprise[]>;
  total$:Observable<number>

  _enterpriceCliente:Enterprise[];
  _ruc_enterprise_selected:string;

  @ViewChild('enterpriseModal', {static: false}) public enterpriseModal: EnterpriseModalComponent;

  @ViewChildren(NgbdSortableHeader3) headers: QueryList<NgbdSortableHeader3>;
  
  constructor(private _iEnterpriceService :EnterpriceService,
    public service:EnterpriseClientService,
    private router: Router
    )
    {
      this.enterprices$ = service.documents$;
      this.total$ = service.total$;
     
    }

   private modal_rechazar_empresa (ent:Enterprise)
   {
    
    this._ruc_enterprise_selected = ent.ruc_empresa;
    
    setTimeout(() => {
      this.DeleteSwal.show();
     }, 500);
   
   }

 
   showsuccess ()
   {
    setTimeout(() => {
      this.SuccessSwal.show();
     }, 500);
     
   }

  ngOnInit() {
    this._iEnterpriceService.GetActivesClients()
      .subscribe(ent => {
        this.cargar_tabla(ent);
      });
    
  }

  public desactivar_empresa()
  {
    this._iEnterpriceService.rejectClient(this._ruc_enterprise_selected)
      .subscribe(ent => {
        this.SuccessSwal.title =this.titulos.eliminar;
        this.SuccessSwal.text = "Se desactivo con Éxito!"
        this.showsuccess ();
        
      });

      this._ruc_enterprise_selected = "";
  }

  public refresh()
  {
    this.router.navigateByUrl(this.ruta);
  }
  private cargar_tabla (ent:Enterprise[])
  {
    

        this._enterpriceCliente = ent;
        this.service.documentsX = ent;
        console.log('entrada',this.service.documentsX)
        this.service.mecmec();
  }

  actualizar_empresa (ent:Enterprise)
  {
    this.enterpriseModal.SetEnterprice(ent);
  }

  crear_empresa()
  {
    
    this.enterpriseModal.crear_empresa();
  }

  onSort({column, direction}: SortEvent3) {

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
