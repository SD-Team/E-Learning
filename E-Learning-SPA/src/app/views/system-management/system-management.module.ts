import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModalModule, PaginationModule } from 'ngx-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelect2Module } from 'ng-select2';
import { NgxSpinnerModule } from 'ngx-spinner';

import { SystemManagementComponent } from './system-management.component';
import { SystemManagementRoutingModule } from './system-management-routing.module';


@NgModule({
  imports: [
    SystemManagementRoutingModule,
    ModalModule.forRoot(),
    PaginationModule.forRoot(),
    NgSelect2Module,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    NgxSpinnerModule
  ],
  declarations: [ SystemManagementComponent ]
})
export class SystemManagementModule { }
