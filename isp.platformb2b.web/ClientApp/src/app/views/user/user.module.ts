import {NgModule} from '@angular/core';
import {CommonModule, DatePipe} from '@angular/common';

import {CollapseModule} from 'ngx-bootstrap/collapse';

import {FormsModule, ReactiveFormsModule} from '@angular/forms';


import {SweetAlert2Module} from '@sweetalert2/ngx-sweetalert2';


import {ModalModule} from 'ngx-bootstrap';
import {CarouselModule} from 'ngx-bootstrap/carousel';


import { _PipeModule } from 'src/app/_pipes/pipe.module';
import { _UtilitariesModule } from '../_utilitaries/_utilitaries.module';
import { NgSelectModule } from '@ng-select/ng-select';

import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UserLogoutComponent } from './user-logout/user-logout.component';
import { UserRoutingModule } from './user.routing';

@NgModule({
  declarations: [UserLogoutComponent],
  imports: [
    CommonModule,
    UserRoutingModule
  ]
})
export class UserModule { }
