import { NgModule } from '@angular/core';
import { NgbDatepickerModule, NgbCollapseModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from '../shared/shared.module';
import { PastoralsRoutingModule } from './pastorals-routing.module';
import { PastoralsComponent } from './pastorals/pastorals.component';

@NgModule({
  declarations: [PastoralsComponent],
  imports: [
    PastoralsRoutingModule,
    SharedModule,
    NgbCollapseModule,
    NgbDatepickerModule
  ],
})
export class PastoralsModule { }
