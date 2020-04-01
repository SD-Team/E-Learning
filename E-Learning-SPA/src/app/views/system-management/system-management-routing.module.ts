import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SystemManagementComponent } from './system-management.component';

const routes: Routes = [
  {
    path: '',
    component: SystemManagementComponent,
    data: {
      title: 'System Management'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SystemManagementRoutingModule {}
