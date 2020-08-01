import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { OAuthService } from 'angular-oauth2-oidc';
import { MonksService } from '../services/monks.service';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import { Monks } from '../store/models';
import { MatDialog } from '@angular/material/dialog';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }]
})
export class HomeComponent implements OnInit, OnDestroy  {
  @Input() monks: Monks.Monk[] = [];

  get hasLoggedIn(): boolean {
    return this.oAuthService.hasValidAccessToken();
  }

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
    private oAuthService: OAuthService,
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly monksService: MonksService,
    private confirmation: ConfirmationService,
    private fb: FormBuilder,
    public dialog: MatDialog
  ) {}

  ngOnInit() {
    const getData = (query: ABP.PageQueryParams) =>
      this.monksService.getListByInput({
        filterText: query.filter,
        ...query,
        ...this.filters,
      });

    const setData = (response: Monks.Response) => (this.data = response);

    this.list.hookToQuery(getData).subscribe((setData) => {
      // console.log('datta', setData.items)
      this.monks = setData.items;
      // console.log('datta', this.monks[0]);
    });
  }
  ngOnDestroy(){}

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

  public onCardClick(evt: MouseEvent){
    console.log(evt);

    
  }

}
