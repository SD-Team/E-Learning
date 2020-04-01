import { NgModule } from '@angular/core';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { ModalModule } from 'ngx-bootstrap';
import { CommonModule } from '@angular/common';
import { MatVideoModule } from 'mat-video';
import { VgCoreModule } from 'videogular2/compiled/core';
import { VgControlsModule } from 'videogular2/compiled/controls';
import { NgxSpinnerModule } from 'ngx-spinner';

import { DashboardComponent } from './dashboard.component';
import { DashboardRoutingModule } from './dashboard-routing.module';
@NgModule({
  imports: [
    DashboardRoutingModule,
    BsDropdownModule.forRoot(),
    ButtonsModule.forRoot(),
    ModalModule.forRoot(),
    CommonModule,
    MatVideoModule,
    NgxSpinnerModule,
    VgCoreModule,
    VgControlsModule
  ],
  declarations: [ DashboardComponent ]
})
export class DashboardModule { }
