import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsDatepickerModule, PaginationModule } from 'ngx-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxSpinnerModule } from 'ngx-spinner';

import { ReportManagementComponent } from './report-management.component';
import { ReportManagementRoutingModule } from './report-management-routing.module';


@NgModule({
  imports: [
    ReportManagementRoutingModule,
    BsDatepickerModule.forRoot(),
    PaginationModule.forRoot(),
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgxSpinnerModule
  ],
  declarations: [ ReportManagementComponent ]
})
export class ReportManagementModule { }
