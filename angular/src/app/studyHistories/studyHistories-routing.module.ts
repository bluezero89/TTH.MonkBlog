import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PermissionGuard } from '@abp/ng.core';
import { StudyHistoriesComponent } from './studyHistories/studyHistories.component';

const routes: Routes = [
  {
    path: '',
    children: [{ path: '', component: StudyHistoriesComponent }],
    canActivate: [PermissionGuard],
    data: { requiredPolicy: 'MonkBlog.StudyHistories' },
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StudyHistoriesRoutingModule { }
