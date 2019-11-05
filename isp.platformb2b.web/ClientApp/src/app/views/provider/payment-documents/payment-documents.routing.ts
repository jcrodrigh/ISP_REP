import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { EnterpriceGuard } from 'src/app/_guards';
import { DocumentsFormComponent } from './documents-form/documents-form.component';
import { DocumentsExcelComponent } from './documents-excel/documents-excel.component';
import { DocumentsResumeComponent } from './document-resume/documents-resume.component';


const routes: Routes = [
    // {
    //     path: '',
    //     data: {
         
    //     },
        // //canActivateChild:[EnterpriceGuard],
         
        // children: [
          {
            path: '',
            redirectTo: 'formulario'
          },
          {
            path: 'formulario',
            component: DocumentsFormComponent,
            data: {
              title: 'Ingreso Individual'
            }
          },
          {
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
              title: 'Resumen de documentos'
            }
          },
    //     ]
    // }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PaymentDocumentsRoutingModule {}
