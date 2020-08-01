import { NgModule } from '@angular/core';
import { NgbDatepickerModule, NgbCollapseModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from '../shared/shared.module';
import { ReligousLivesRoutingModule } from './religousLives-routing.module';
import { ReligousLivesComponent } from './religousLives/religousLives.component';

@NgModule({
  declarations: [ReligousLivesComponent],
  imports: [
    ReligousLivesRoutingModule,
    SharedModule,
    NgbCollapseModule,
    NgbDatepickerModule
  ],
})
export class ReligousLivesModule { }
