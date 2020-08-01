import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import { Monks } from '../../store/models';
import { MonksService } from '../../services/monks.service';

@Component({
  selector: 'app-monks',
  templateUrl: './monks.component.html',
  styleUrls: ['./monks.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
})
export class MonksComponent implements OnInit {
  data: PagedResultDto<Monks.Monk> = {
    items: [],
    totalCount: 0,
  };

  filters: Partial<Monks.MonksQueryParams> = {};

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected: Monks.Monk;

  

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly monksService: MonksService,
    private confirmation: ConfirmationService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    const getData = (query: ABP.PageQueryParams) =>
      this.monksService.getListByInput({
        filterText: query.filter,
        ...query,
        ...this.filters,
      });

    const setData = (response: Monks.Response) => (this.data = response);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  buildForm() {
    this.form = this.fb.group({
      imgPath: [this.selected.imgPath || '', []],
      fullName: [this.selected.fullName || '', []],
      holyName: [this.selected.holyName || '', []],
      homeTown: [this.selected.homeTown || '', []],
      permanentAdress: [this.selected.permanentAdress || '', []],
      dateOfBirth: [this.selected.dateOfBirth ? new Date(this.selected.dateOfBirth) : null, []],
      dateOfBaptism: [this.selected.dateOfBaptism ? new Date(this.selected.dateOfBaptism) : null, []],
      placeOfBaptism: [this.selected.placeOfBaptism || '', []],
      dateOfConfirmation: [this.selected.dateOfConfirmation ? new Date(this.selected.dateOfConfirmation) : null, []],
      placeOfConfirmation: [this.selected.placeOfConfirmation || '', []],
      email: [this.selected.email || '', []],
      phoneNumber: [this.selected.phoneNumber || '', []],
      father_FullName: [this.selected.father_FullName || '', []],
      father_HolyName: [this.selected.father_HolyName || '', []],
      mother_FullName: [this.selected.mother_FullName || '', []],
      mother_HolyName: [this.selected.mother_HolyName || '', []],

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
      ? this.monksService.updateByIdAndInput(this.form.value, this.selected.id)
      : this.monksService.createByInput(this.form.value);

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
    
    } as Monks.Monk;
    this.showForm();
  }

  update(record: Monks.Monk) {
    this.monksService
      .getById(record.id)
      .subscribe((response: Monks.Monk) => {
        this.selected = response;
        this.showForm();
      });
  }

  delete(record: Monks.Monk) {
    this.confirmation.warn(
      '::DeleteConfirmationMessage',
      '::AreYouSure',
      { messageLocalizationParams: [] }
    ).pipe(
      filter(status => status === Confirmation.Status.confirm),
      switchMap(() => this.monksService.deleteById(record.id)),
    ).subscribe(this.list.get);
  }
}
