import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import { Pastorals } from '../../store/models';
import { PastoralsService } from '../../services/pastorals.service';

@Component({
  selector: 'app-pastorals',
  templateUrl: './pastorals.component.html',
  styleUrls: ['./pastorals.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
})
export class PastoralsComponent implements OnInit {
  data: PagedResultDto<Pastorals.Pastoral> = {
    items: [],
    totalCount: 0,
  };

  filters: Partial<Pastorals.PastoralsQueryParams> = {};

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected: Pastorals.Pastoral;

  

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly pastoralsService: PastoralsService,
    private confirmation: ConfirmationService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    const getData = (query: ABP.PageQueryParams) =>
      this.pastoralsService.getListByInput({
        filterText: query.filter,
        ...query,
        ...this.filters,
      });

    const setData = (response: Pastorals.Response) => (this.data = response);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  buildForm() {
    this.form = this.fb.group({
      monkId: [this.selected.monkId || '', []],
      fromDate: [this.selected.fromDate ? new Date(this.selected.fromDate) : null, []],
      toDate: [this.selected.toDate ? new Date(this.selected.toDate) : null, []],
      placeOfPastoral: [this.selected.placeOfPastoral || '', []],

    });
  }

  hideForm() {
    this.isModalOpen = false;
    this.form.reset();
  }

  showForm() {
    this.buildForm();
    this.isModalOpen = true;
  }

  submitForm() {
    if (this.form.invalid) return;

    const request = this.selected.id
      ? this.pastoralsService.updateByIdAndInput(this.form.value, this.selected.id)
      : this.pastoralsService.createByInput(this.form.value);

    this.isModalBusy = true;

    request
      .pipe(
        finalize(() => (this.isModalBusy = false)),
        tap(() => this.hideForm()),
      )
      .subscribe(this.list.get);
  }

  create() {
    this.selected = {
    
    } as Pastorals.Pastoral;
    this.showForm();
  }

  update(record: Pastorals.Pastoral) {
    this.pastoralsService
      .getById(record.id)
      .subscribe((response: Pastorals.Pastoral) => {
        this.selected = response;
        this.showForm();
      });
  }

  delete(record: Pastorals.Pastoral) {
    this.confirmation.warn(
      '::DeleteConfirmationMessage',
      '::AreYouSure',
      { messageLocalizationParams: [] }
    ).pipe(
      filter(status => status === Confirmation.Status.confirm),
      switchMap(() => this.pastoralsService.deleteById(record.id)),
    ).subscribe(this.list.get);
  }
}
