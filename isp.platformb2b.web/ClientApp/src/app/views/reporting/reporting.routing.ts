import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { EnterpriceGuard } from 'src/app/_guards';
import { RankingComponent } from './ranking/ranking.component';
import { DocumentaryCycleComponent } from './documentary-cycle/documentary-cycle.component';
import { DocumentManagementComponent } from './document-management/document-management.component';
import { EnterpriseClientComponent } from './enterprise-management/enterprise-client/enterprise-client.component';
//import { EnterpriseManagementComponent } from './enterprise-management/enterprise-client/enterprise-client.component';



const routes: Routes = [
    // {
    //     path: '',
    //     data: {
         
    //     },
        // //canActivateChild:[EnterpriceGuard],
         
        // children: [
          {
            path: '',
            redirectTo: 'ranking'
          },
          {
            path: 'ranking',
            component: EnterpriseClientComponent,
            data: {
              title: 'Ranking de Doc. / Costo'
            }
          },
          {
            path: 'DocumentaryCycle',
            component: DocumentaryCycleComponent,
            data: {
              title: 'Ciclo Documentario'
            }
          },
          
          {
            path: 'DocumentManagement',
            component: DocumentManagementComponent,
            data: {
              title: 'Gestión de Documentos'
            }
          },
    //     ]
    // }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ReportingRoutingModule {}
