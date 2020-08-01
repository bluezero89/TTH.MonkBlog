import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';
import { ApplicationLayoutComponent } from '@volo/abp.ng.theme.lepton';
import { PermissionGuard } from '@abp/ng.core';
// import { MonkListComponent } from '../monks/monk-list/monk-list.component' ;

const routes: Routes = [{ 
  path: '',
  children: [{ path: '', component: HomeComponent }],
  canActivate: [PermissionGuard],
  data: { requiredPolicy: 'MonkBlog.Monks' },
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class HomeRoutingModule {}
