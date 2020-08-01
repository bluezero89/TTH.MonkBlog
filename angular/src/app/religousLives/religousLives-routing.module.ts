import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PermissionGuard } from '@abp/ng.core';
import { ReligousLivesComponent } from './religousLives/religousLives.component';

const routes: Routes = [
  {
    path: '',
    children: [{ path: '', component: ReligousLivesComponent }],
    canActivate: [PermissionGuard],
    data: { requiredPolicy: 'MonkBlog.ReligousLives' },
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ReligousLivesRoutingModule { }
