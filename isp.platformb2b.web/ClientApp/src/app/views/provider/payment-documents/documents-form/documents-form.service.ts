import { Injectable } from '@angular/core';
import { MasterTablesService, EnterpriceService, PurchaseOrderService } from 'src/app/_services';
import { DatePipe, KeyValue } from '@angular/common';
import { TypesOfDocument, KeysValues, Enterprise, PurchaseOrder, detraction, SerialDocuments } from 'src/app/_models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DocumentsFormService {
    
    TypeCurrency: KeysValues[];
    TypeDocuments: KeysValues[];

    _SerialByTypeOfDoc: SerialDocuments[];
    
    
    enterprices: Enterprise[];
    enterpriceByRUC: Enterprise;
    purcharseOrderSelected: PurchaseOrder;
    detractions: detraction[];
  
    public _tipoDocumento: TypesOfDocument;
    public TypeDocumentsComplete: TypesOfDocument[];
    public purchaseOrders: PurchaseOrder[];

  constructor(public masterTableService: MasterTablesService, //servicio para cargar las tablas maestras :V
    public enterpriceServices:EnterpriceService,
    public purchaseOrderService:PurchaseOrderService,
    public datePipe: DatePipe) 
    {
        this.Init();
    }

    public Init ()
    {
        this.enterpriceServices.getAllClientBySupplier()
      .subscribe(ents =>{
        this.enterprices = ents;
        console.log(this.enterprices)
      });
  
      this.masterTableService.getAllTypeDocument().subscribe(
        tydoc =>
        {
          this.TypeDocuments = tydoc.sort((a,b)=> parseInt(a.key) - parseInt(b.key) ); //para que se vea más presentable... lo ordenamos :V
        }
      );
  
      this.masterTableService.getAllTypeDocumentComplete().subscribe(
        tyDoc => 
        {
          console.log(tyDoc);
          this.TypeDocumentsComplete = tyDoc.sort((a,b) => (a.id_tipo_documento > b.id_tipo_documento)? 1:-1);
        }
      );
  
      //...del servicio "tablas maestras" obtenemos el tipo de moneda :V
      this.masterTableService.getAllTypeCurrency().subscribe(
        tycur => 
        {
          this.TypeCurrency = tycur.sort((a,b)=>a.value.localeCompare(b.value)); //para que se vea más presentable... lo ordenamos :V
        }
      );

      this.masterTableService.getAllDetractions().subscribe(
        det =>
        {
          this.detractions = det.sort((a,b)=> a.id_tipo_detracciones.localeCompare(b.id_tipo_detracciones));
          var temp_no = this.detractions.filter(det => det.id_tipo_detracciones== 'NO');
          var temp = this.detractions.filter(det => det.id_tipo_detracciones!= 'NO');
          this.detractions = temp_no.concat(temp);
        }
      )

      this.masterTableService.
      GetListDocumentSerialByTypeDocument()
        .subscribe(doc => 
          this._SerialByTypeOfDoc = doc.sort((a,b)=> a.id_tipo_documento_serie.localeCompare(b.id_tipo_documento_serie)) );

        
    }

    
}