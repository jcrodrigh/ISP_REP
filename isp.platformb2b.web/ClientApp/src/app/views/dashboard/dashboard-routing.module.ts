import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DashboardComponent } from './dashboard.component';
import { Role } from 'src/app/_models';
import { EnterpriceGuard } from 'src/app/_guards';

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
    //canActivate: [EnterpriceGuard],    
    data: {
      title: 'Blackboard',      
      roles:[Role.Admin,Role.Client,Role.Supplier,"olenka"]
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule {}
