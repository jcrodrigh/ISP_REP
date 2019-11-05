import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { EnterpriceGuard } from 'src/app/_guards';
import { UserLogoutComponent } from './user-logout/user-logout.component';




const routes: Routes = [
    
          {
            path: '',
            component: UserLogoutComponent,
            
            children: [
              {
                path: 'logout',
                component: UserLogoutComponent
              },
              
            ]
          },
          
         
          
          /*{
            path: 'excel',
            component: DocumentsExcelComponent,
            data: {
              title: 'Ingreso masivo'
            }
          },
          
          {
            path: 'tabla',
            component: DocumentsResumeComponent,
            data: {
              title: 'tabla Display'
            }
          },*/
    //     ]
    // }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule {}
