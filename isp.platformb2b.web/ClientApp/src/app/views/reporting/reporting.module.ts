import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RankingComponent } from './ranking/ranking.component';
import { DocumentaryCycleComponent } from './documentary-cycle/documentary-cycle.component';
import { DocumentManagementComponent } from './document-management/document-management.component';
import { ReportingRoutingModule } from './reporting.routing';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { _PipeModule } from 'src/app/_pipes/pipe.module';
import { _UtilitariesModule } from '../_utilitaries/_utilitaries.module';

import { NgbdSortableHeader2 } from './document-management/sortable.directive';
import { EnterpriseClientComponent } from './enterprise-management/enterprise-client/enterprise-client.component';
import { EnterpriseModalComponent } from './enterprise-management/enterprise-client/enterprise-modal/enterprise-modal.component';
import { ModalModule } from 'ngx-bootstrap';

import { EnterpriseManagementModule } from './enterprise-management/enterprise-management.module';
import { SharedModule } from 'src/app/_shared/shared.module';
//import { NgbdSortableHeader3 } from './enterprise-management/sortable.directive';
// import { TableService } from 'src/app/_services';

@NgModule({
  declarations: [RankingComponent, 
    DocumentaryCycleComponent, 
    DocumentManagementComponent,
    NgbdSortableHeader2, 
    //NgbdSortableHeader3,
    ],
  
  imports: [
    EnterpriseManagementModule,
    SharedModule,
    ReportingRoutingModule,
    

   
  ],
  providers:[ ] //
})
export class ReportingModule { }
