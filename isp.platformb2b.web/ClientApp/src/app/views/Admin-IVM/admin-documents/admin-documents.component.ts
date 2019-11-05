import { Component, ViewChild,Input, OnInit, AfterViewInit } from "@angular/core";
import { ModalDirective} from 'ngx-bootstrap/modal';
import { FormGroup, FormControl } from "@angular/forms";
import { KeysValues, Enterprise, DocumentFilter} from "src/app/_models";



import { PaymentDocumentsService,EnterpriceService ,ExportFileService} from "src/app/_services";

import { DocumentsTableComponent } from "../../_utilitaries/document/document-table/document-table.component";
import { ActivatedRoute } from "@angular/router";
import { DocumentFilterComponent } from "../../_utilitaries/document/document-filter/document-filter.component";
import { EnterpriseListComponent } from "../../_utilitaries/enterprise/enterprise-list/enterprise-list.component";
    


@Component({
    selector: "admin-documents",
    templateUrl: "./admin-documents.component.html",
    styleUrls:["./admin-documents.component.css"]
})
export class AdminDocumentsComponent  implements AfterViewInit  {
    @ViewChild('DocumentTable', {static: false}) public DocumentTable: DocumentsTableComponent;
    @ViewChild('ListEnterprise', {static: false}) public ListEnterprise: EnterpriseListComponent;
    
    filter:DocumentFilter = 
    {
        fis_elec:[true,false],
        ruc_empresa_cliente:[],
        id_tipo_documento_estado:[1,5],
        ruc_empresa_proveedor:[]

    }

    ngAfterViewInit(): void {
        this.DocumentTable.ivm_flag = false;
    }
    
    _ActiveClients:Enterprise[];

    constructor (private _paymentDocumentsService:PaymentDocumentsService,
        private _enterpriceService: EnterpriceService) 
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
        this._paymentDocumentsService.GetDocumentWithQuery([ruc_empresa_cliente],[1,5])
        .subscribe(docs=>{
            
            this.DocumentTable.passDocumentx(docs);
            
        })

        
    }
}




