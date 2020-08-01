import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PermissionGuard } from '@abp/ng.core';
import { MonksComponent } from './monks/monks.component';

const routes: Routes = [
  {
    path: '',
    children: [{ path: '', component: MonksComponent }],
    canActivate: [PermissionGuard],
    data: { requiredPolicy: 'MonkBlog.Monks' },
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MonksRoutingModule { }
