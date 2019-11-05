import { Component, ViewChild,Input, AfterContentInit, AfterViewInit, OnChanges } from "@angular/core";
import { ModalDirective} from 'ngx-bootstrap/modal';
import { FormGroup, FormControl } from "@angular/forms";
import { KeysValues, Enterprise, PurchaseOrder, TypesOfDocument, detraction,  DocumentFilter} from "src/app/_models";



import { PaymentDocumentsService,EnterpriceService } from "src/app/_services";

import { DocumentsTableComponent } from "../../_utilitaries/document/document-table/document-table.component";
import { ActivatedRoute } from "@angular/router";
import { EnterpriseListComponent } from "../../_utilitaries/enterprise/enterprise-list/enterprise-list.component";


@Component({
    selector: "document-transfer-table",
    templateUrl: "./document-transfer-table.component.html",
    styleUrls:["./document-transfer-table.component.css"]
})
export class DocumentTransferTableComponent   implements AfterViewInit {
   
    ngAfterViewInit(): void {
        this.DocumentTable.ivm_flag = false;
    }
    

    @ViewChild('DocumentTable', {static: false}) public DocumentTable: DocumentsTableComponent;
    @ViewChild('ListEnterprise', {static: false}) public ListEnterprise: EnterpriseListComponent;
    
    
    _ActiveClients:Enterprise[];

    filter:DocumentFilter = 
    {
        fis_elec:[true,false],
        ruc_empresa_cliente:[],
        id_tipo_documento_estado:[2,3,4],
        ruc_empresa_proveedor:[]

    }


    constructor (private _paymentDocumentsService:PaymentDocumentsService,
        private _enterpriceService: EnterpriceService,
        ) 
    {
       
        
        _enterpriceService.GetActivesClients().subscribe(ent=>
            {
                this.ListEnterprise.List_Enterprice = ent;
                this._ActiveClients= ent;
            })
    }

    passClientEnterprise(List_Enterprice:string[])
    {

        this.filter.ruc_empresa_cliente = List_Enterprice;
        this._paymentDocumentsService.GetDocumentwithFilter(this.filter)
        .subscribe(docs=>{
            
            this.DocumentTable.passDocumentx(docs);
            
        })
    }
    


    showDocuments(ruc_empresa_cliente:string)
    {
        /*this._paymentDocumentsService.GetAllDocumentsByClient(ruc_empresa_cliente)
        .subscribe();*/
        this._paymentDocumentsService.GetDocumentWithQuery([ruc_empresa_cliente],[2,3,4])
        .subscribe(docs=> 
            {console.log(docs);
                this.DocumentTable.passDocumentx(docs);
            });
    }

}
