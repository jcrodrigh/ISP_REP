import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { EnterpriceGuard } from 'src/app/_guards';
import { DocumentTransferTableComponent } from './document-transfer-table/document-transfer-table.component';




const routes: Routes = [
    // {
    //     path: '',
    //     data: {
         
    //     },
        // //canActivateChild:[EnterpriceGuard],
         
        // children: [
          {
            path: '',
            redirectTo: 'tabla'
          },
          {
            path: 'tabla',
            component: DocumentTransferTableComponent,
            data: {
              title: 'Documentos Transferidos'
            }
          },
          /*{
            path: 'tablaTotal',
            component: TotalTableComponent,
            data: {
              title: 'Tabla Total'
            }
          }*/
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
export class TransferRoutingModule {}
