import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EnterpriseClientComponent } from './enterprise-client/enterprise-client.component';
import { EnterpriseModalComponent } from './enterprise-client/enterprise-modal/enterprise-modal.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ModalModule } from 'ngx-bootstrap';
import { SharedModule } from 'src/app/_shared/shared.module';
import { _DirectiveModule } from 'src/app/_directive/directive.module';
import { NgbdSortableHeader3 } from './enterprise-client/sortable.directive';

@NgModule({
  declarations: [EnterpriseClientComponent, EnterpriseModalComponent,NgbdSortableHeader3],
  
  imports: [
    CommonModule,
    NgbModule,
    
    ModalModule.forRoot(),
    SharedModule,
    _DirectiveModule
    
    
  ]
})
export class EnterpriseManagementModule { }
