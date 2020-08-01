import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import { ReligousLives } from '../../store/models';
import { ReligousLivesService } from '../../services/religousLives.service';

@Component({
  selector: 'app-religousLives',
  templateUrl: './religousLives.component.html',
  styleUrls: ['./religousLives.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
})
export class ReligousLivesComponent implements OnInit {
  data: PagedResultDto<ReligousLives.ReligousLife> = {
    items: [],
    totalCount: 0,
  };

  filters: Partial<ReligousLives.ReligousLivesQueryParams> = {};

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected: ReligousLives.ReligousLife;

  

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly religousLivesService: ReligousLivesService,
    private confirmation: ConfirmationService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    const getData = (query: ABP.PageQueryParams) =>
      this.religousLivesService.getListByInput({
        filterText: query.filter,
        ...query,
        ...this.filters,
      });

    const setData = (response: ReligousLives.Response) => (this.data = response);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  buildForm() {
    this.form = this.fb.group({
      monkId: [this.selected.monkId || '', []],
      dateOfPractitioners: [this.selected.dateOfPractitioners ? new Date(this.selected.dateOfPractitioners) : null, []],
      dateOfThinhVien: [this.selected.dateOfThinhVien ? new Date(this.selected.dateOfThinhVien) : null, []],
      dateOfTapVien: [this.selected.dateOfTapVien || '', []],
      firstKhan: [this.selected.firstKhan || '', []],
      secondKhan: [this.selected.secondKhan ? new Date(this.selected.secondKhan) : null, []],
      thirdKhan: [this.selected.thirdKhan ? new Date(this.selected.thirdKhan) : null, []],
      remainKhan: [this.selected.remainKhan ? new Date(this.selected.remainKhan) : null, []],
      lifeTimeKhan: [this.selected.lifeTimeKhan ? new Date(this.selected.lifeTimeKhan) : null, []],
      dateOfDeacon: [this.selected.dateOfDeacon ? new Date(this.selected.dateOfDeacon) : null, []],
      dateOfPriest: [this.selected.dateOfPriest ? new Date(this.selected.dateOfPriest) : null, []],

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
      ? this.religousLivesService.updateByIdAndInput(this.form.value, this.selected.id)
      : this.religousLivesService.createByInput(this.form.value);

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
    
    } as ReligousLives.ReligousLife;
    this.showForm();
  }

  update(record: ReligousLives.ReligousLife) {
    this.religousLivesService
      .getById(record.id)
      .subscribe((response: ReligousLives.ReligousLife) => {
        this.selected = response;
        this.showForm();
      });
  }

  delete(record: ReligousLives.ReligousLife) {
    this.confirmation.warn(
      '::DeleteConfirmationMessage',
      '::AreYouSure',
      { messageLocalizationParams: [] }
    ).pipe(
      filter(status => status === Confirmation.Status.confirm),
      switchMap(() => this.religousLivesService.deleteById(record.id)),
    ).subscribe(this.list.get);
  }
}
