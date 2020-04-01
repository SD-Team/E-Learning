import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DefaultLayoutComponent } from './containers';
import { LoginComponent } from './views/login/login.component';
import { AuthGuard } from './_core/_guards/auth.guard';
import { CheckLoginComponent } from './views/check-login/check-login.component';

export const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'login', component: LoginComponent},
  { path: 'checkLogin', component: CheckLoginComponent },
  {
    path: '',
    component: DefaultLayoutComponent,
    canActivate: [AuthGuard],
    children: [{
      path: 'dashboard',
      loadChildren: () => import('./views/dashboard/dashboard.module').then(m => m.DashboardModule)
    },
    {
      path: 'system-management',
      loadChildren: () => import('./views/system-management/system-management.module').then(m => m.SystemManagementModule)
    },
    {
      path: 'report-management',
      loadChildren: () => import('./views/report-management/report-management.module').then(m => m.ReportManagementModule)
    },
    ]
  },
  // { path: '**', redirectTo: 'dashboard' }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes, { useHash: true })],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
