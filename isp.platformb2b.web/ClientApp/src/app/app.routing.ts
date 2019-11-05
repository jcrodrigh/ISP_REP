import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {DashboardModule} from './views/dashboard/dashboard.module';
//import {InvoicingModule} from './views/provider/invoicing/invoicing.module'

// Import Containers
import {DefaultLayoutComponent} from './containers';
import {EnterpriceGuard} from './_guards';
import {LoginComponent} from './views/login/login.component';
import {Role} from './_models';
import {PaymentDocumentsModule} from './views/provider/payment-documents/payment-documents.module';
import {AdminIVMModule} from './views/Admin-IVM/Admin-IVM.module';
import { TransferModule } from './views/Transfer/Transfer.module';
import { ReportingModule } from './views/reporting/reporting.module';
import { UserModule } from './views/user/user.module';
import { UserLogoutComponent } from './views/user/user-logout/user-logout.component';

// import { P404Component } from './views/error/404.component';
// import { P500Component } from './views/error/500.component';
// import { LoginComponent } from './views/login/login.component';
// import { RegisterComponent } from './views/register/register.component';

export const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent
  },


  {
    path: '',
    component: DefaultLayoutComponent,
    data: {
      title: 'Inicio',
      roles: [Role.Admin, Role.Client, Role.Supplier]
    },

    children: [
      {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full',
      },
      {
        path: 'dashboard',
        loadChildren: './views/dashboard/dashboard.module#DashboardModule',
        canLoad: [EnterpriceGuard],
        data: {
          title: 'Inicio',
          roles: [Role.Admin, Role.Client, Role.Supplier]
        }
      },
      {
        path: 'DocumentosPago',
        canLoad: [EnterpriceGuard],
        
        // data: {
        //   title: 'documentos de pago',
        //   roles: [Role.Admin, Role.Client, Role.Supplier, 'olenka']
        // },
        children: [
          {
            path: '',
            redirectTo: '',
            pathMatch: 'full',
          },
          {
            path: '',
            loadChildren: './views/provider/payment-documents/payment-documents.module#PaymentDocumentsModule',
            canLoad: [EnterpriceGuard],
            data: {
              title: 'Capture',
              roles: [Role.Admin, Role.Client, Role.Supplier]
            }
          }
        ]
        

       
      },
      {
        path: 'AdminIVM',
        

        children: [
          {
            path: '',
            redirectTo: '',
            pathMatch: 'full',
          },
          {
            path: '',
            loadChildren: './views/Admin-IVM/Admin-IVM.module#AdminIVMModule',
            canLoad: [EnterpriceGuard],
            data: {
              title: 'Verify',
              roles: [Role.Admin, Role.Client, Role.Supplier]
            }
          }
        ]

        // canLoad: [EnterpriceGuard],
        // data: {
        //   title: 'Administración Sistema IVM',
        //   roles: [Role.Admin, Role.Client, Role.Supplier, 'olenka']
        // }
      },
      {       
          path: 'transfer',
          children: [
            {
              path: '',
              redirectTo: '',
              pathMatch: 'full',
            },
            {
              path: '',
              loadChildren: './views/Transfer/Transfer.module#TransferModule',
              canLoad: [EnterpriceGuard],
              data: {
                title: 'Tranfer',
                roles: [Role.Admin, Role.Client, Role.Supplier]
              }
            }
          ]
        
     
      },
      {

        path: 'reporting',
        children: [
          {
            path: '',
            redirectTo: '',
            pathMatch: 'full',
          },
          {
            path: '',
            loadChildren: './views/reporting/reporting.module#ReportingModule',
            canLoad: [EnterpriceGuard],
            data: {
              title: 'Reportes',
              roles: [Role.Admin, Role.Client, Role.Supplier]
            }
          }
        ]       
      },
      {

        path: 'user',   
        loadChildren:() => import('./views/user/user.module').then(m => m.UserModule)  
        //loadChildren: './views/user/user.module#UserModule',
        
      }
    ]
  },
  {path: '**', component: DefaultLayoutComponent, data: {roles: [Role.Admin, Role.Supplier, Role.Client]}}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

  
}
