import { NgModule } from '@angular/core';
import { NgbDatepickerModule, NgbCollapseModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from '../shared/shared.module';
import { StudyHistoriesRoutingModule } from './studyHistories-routing.module';
import { StudyHistoriesComponent } from './studyHistories/studyHistories.component';

@NgModule({
  declarations: [StudyHistoriesComponent],
  imports: [
    StudyHistoriesRoutingModule,
    SharedModule,
    NgbCollapseModule,
    NgbDatepickerModule
  ],
})
export class StudyHistoriesModule { }
