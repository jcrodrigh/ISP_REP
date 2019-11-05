import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {DatePipe, HashLocationStrategy, LocationStrategy} from '@angular/common';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import {PerfectScrollbarConfigInterface, PerfectScrollbarModule} from 'ngx-perfect-scrollbar';
import {AppComponent} from './app.component';

import {DefaultLayoutComponent, LoaderComponent} from './containers';
import {AppAsideModule, AppBreadcrumbModule, AppFooterModule, AppHeaderModule, AppSidebarModule,} from '@coreui/angular';

import {AppRoutingModule} from './app.routing';

import {BsDropdownModule} from 'ngx-bootstrap/dropdown';
import {TabsModule} from 'ngx-bootstrap/tabs';
import {ChartsModule} from 'ng2-charts-x';


import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';


import {ErrorInterceptor, fakeBackendProvider, JwtInterceptor} from './_helpers';

import {NgxSmartModalModule, NgxSmartModalService} from 'ngx-smart-modal';


import {LoginComponent} from './views/login/login.component';


import {DashboardModule} from './views/dashboard/dashboard.module';

import {SweetAlert2Module} from '@sweetalert2/ngx-sweetalert2';
import {_UtilitariesModule} from './views/_utilitaries/_utilitaries.module';
import {LoaderService} from './_services/LoaderService';
import {LoaderInterceptor} from './_helpers/loader.interceptor';
import { _PipeModule } from './_pipes/pipe.module';


const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true
};


const APP_CONTAINERS = [
  DefaultLayoutComponent,
  LoaderComponent
];


@NgModule({
  declarations: [
    AppComponent,
    ...APP_CONTAINERS,
    LoginComponent,


  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    BrowserAnimationsModule,
    AppRoutingModule,
    AppAsideModule,
    AppBreadcrumbModule.forRoot(),
    AppFooterModule,
    AppHeaderModule,
    AppSidebarModule,
    PerfectScrollbarModule,
    BsDropdownModule.forRoot(),
    TabsModule.forRoot(),
    ChartsModule,

    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,

    NgxSmartModalModule.forRoot(),


    SweetAlert2Module.forRoot(),


    DashboardModule,


    _UtilitariesModule,
    

  ],

  providers: [
    LoaderService,
    {
      provide: LocationStrategy,
      useClass: HashLocationStrategy
    },
    {provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},

    // provider used to create fake backend
    fakeBackendProvider,
    NgxSmartModalService,
    DatePipe,
    

    //InvoiceHelper

  ],
  exports: [
    _UtilitariesModule,
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
