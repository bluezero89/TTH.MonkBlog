import { NgModule } from '@angular/core';
import { NgbDatepickerModule, NgbCollapseModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from '../shared/shared.module';
import { MonksRoutingModule } from './monks-routing.module';
import { MonksComponent } from './monks/monks.component';
import { MonkDetailComponent } from './monk-detail/monk-detail.component';

@NgModule({
  declarations: [MonksComponent, MonkDetailComponent],
  imports: [
    MonksRoutingModule,
    SharedModule,
    NgbCollapseModule,
    NgbDatepickerModule
  ],
})
export class MonksModule { }
