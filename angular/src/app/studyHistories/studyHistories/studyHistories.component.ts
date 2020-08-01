import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import { StudyHistories } from '../../store/models';
import { StudyHistoriesService } from '../../services/studyHistories.service';

@Component({
  selector: 'app-studyHistories',
  templateUrl: './studyHistories.component.html',
  styleUrls: ['./studyHistories.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
})
export class StudyHistoriesComponent implements OnInit {
  data: PagedResultDto<StudyHistories.StudyHistory> = {
    items: [],
    totalCount: 0,
  };

  filters: Partial<StudyHistories.StudyHistoriesQueryParams> = {};

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected: StudyHistories.StudyHistory;

  

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly studyHistoriesService: StudyHistoriesService,
    private confirmation: ConfirmationService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    const getData = (query: ABP.PageQueryParams) =>
      this.studyHistoriesService.getListByInput({
        filterText: query.filter,
        ...query,
        ...this.filters,
      });

    const setData = (response: StudyHistories.Response) => (this.data = response);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  buildForm() {
    this.form = this.fb.group({
      diploma: [this.selected.diploma || '', []],
      academicLevel: [this.selected.academicLevel || '', []],
      studyAt: [this.selected.studyAt || '', []],
      fromDate: [this.selected.fromDate ? new Date(this.selected.fromDate) : null, []],
      toDate: [this.selected.toDate ? new Date(this.selected.toDate) : null, []],
      achievements: [this.selected.achievements || '', []],

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
      ? this.studyHistoriesService.updateByIdAndInput(this.form.value, this.selected.id)
      : this.studyHistoriesService.createByInput(this.form.value);

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
    
    } as StudyHistories.StudyHistory;
    this.showForm();
  }

  update(record: StudyHistories.StudyHistory) {
    this.studyHistoriesService
      .getById(record.id)
      .subscribe((response: StudyHistories.StudyHistory) => {
        this.selected = response;
        this.showForm();
      });
  }

  delete(record: StudyHistories.StudyHistory) {
    this.confirmation.warn(
      '::DeleteConfirmationMessage',
      '::AreYouSure',
      { messageLocalizationParams: [] }
    ).pipe(
      filter(status => status === Confirmation.Status.confirm),
      switchMap(() => this.studyHistoriesService.deleteById(record.id)),
    ).subscribe(this.list.get);
  }
}
