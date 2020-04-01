import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ReportManagementComponent } from './report-management.component';

const routes: Routes = [
  {
    path: '',
    component: ReportManagementComponent,
    data: {
      title: 'Report Management'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ReportManagementRoutingModule {}
