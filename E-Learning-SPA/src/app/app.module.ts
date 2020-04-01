import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true
};

const APP_CONTAINERS = [
  DefaultLayoutComponent
];

import {
  AppAsideModule,
  AppBreadcrumbModule,
  AppHeaderModule,
  AppFooterModule,
  AppSidebarModule,
} from '@coreui/angular';

// Import 3rd party components
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { LocationStrategy, HashLocationStrategy } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ChartsModule } from 'ng2-charts';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PaginationModule } from 'ngx-bootstrap';
import { NgxSpinnerModule } from 'ngx-spinner';

import { AuthService } from './_core/_services/auth.service';
import { AuthGuard } from './_core/_guards/auth.guard';
import { AlertifyService } from './_core/_services/alertify.service';

import { NavComponent } from './containers/default-layout/nav/nav.component';
import { AppComponent } from './app.component';
import { DefaultLayoutComponent } from './containers';
import { LoginComponent } from './views/login/login.component';

// Import routing module
import { AppRoutingModule } from './app.routing';
import { CheckLoginComponent } from './views/check-login/check-login.component';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  imports: [
    BrowserModule,
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
    PaginationModule.forRoot(),
    ChartsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    NgxSpinnerModule,
    JwtModule.forRoot({
      config: {
         tokenGetter: tokenGetter,
         whitelistedDomains: ['localhost:5000'],
         blacklistedRoutes: ['localhost:5000/api/auth']
      }
   })
  ],
  declarations: [
    AppComponent,
    ...APP_CONTAINERS,
    LoginComponent,
    NavComponent,
    CheckLoginComponent
  ],
  providers: [
    AuthService,
    AlertifyService,
    AuthGuard,
    {
    provide: LocationStrategy,
    useClass: HashLocationStrategy
    }
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
