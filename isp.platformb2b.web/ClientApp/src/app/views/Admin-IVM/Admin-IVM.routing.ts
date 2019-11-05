import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { EnterpriceGuard } from 'src/app/_guards';
import { AdminDocumentsComponent } from './admin-documents/admin-documents.component';
import { DocumentsErrorsResumeComponent } from './document-errors-resume/documents-errors-resume.componet';



const routes: Routes = [
    // {
    //     path: '',
    //     data: {
         
    //     },
        // //canActivateChild:[EnterpriceGuard],
         
        // children: [
         
          {
            path: 'resumen',
            component: AdminDocumentsComponent,
            data: {
              title: 'Documentos por validar'
            }
          },
          
          {
            path: 'TablaErrores',
            component: DocumentsErrorsResumeComponent,
            data: {
              title: 'Documentos Rechazados'
            }
          },
          
          
          
    //     ]
    // }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminIVMRoutingModule {}
