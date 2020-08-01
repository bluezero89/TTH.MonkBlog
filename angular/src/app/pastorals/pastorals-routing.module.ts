import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PermissionGuard } from '@abp/ng.core';
import { PastoralsComponent } from './pastorals/pastorals.component';

const routes: Routes = [
  {
    path: '',
    children: [{ path: '', component: PastoralsComponent }],
    canActivate: [PermissionGuard],
    data: { requiredPolicy: 'MonkBlog.Pastorals' },
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PastoralsRoutingModule { }
