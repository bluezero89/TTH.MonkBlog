import { Injectable } from '@angular/core';
import { RestService, ABP } from '@abp/ng.core';
import { StudyHistories } from '../store/models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudyHistoriesService {
  apiName = 'Default';

  constructor(private restService: RestService) { }

  getListByInput(params = {} as StudyHistories.StudyHistoriesQueryParams): Observable<StudyHistories.Response> {
    return this.restService.request<void, StudyHistories.Response>({
      method: 'GET',
      url: '/api/app/studyHistory',
      params
    },
    { apiName: this.apiName });
  }

  createByInput(createStudyHistoryInput: StudyHistories.StudyHistoryCreateUpdateDto): Observable<StudyHistories.StudyHistory> {
    return this.restService.request<StudyHistories.StudyHistoryCreateUpdateDto, StudyHistories.StudyHistory>({
      method: 'POST',
      url: '/api/app/studyHistory',
      body: createStudyHistoryInput
    },
    { apiName: this.apiName });
  }

  

  getById(id: string): Observable<StudyHistories.StudyHistory> {
    return this.restService.request<void, StudyHistories.StudyHistory>({
      method: 'GET',
      url: `/api/app/studyHistory/${id}`
    },
    { apiName: this.apiName });
  }

  updateByIdAndInput(createStudyHistoryInput: StudyHistories.StudyHistoryCreateUpdateDto, id: string): Observable<StudyHistories.StudyHistory> {
    return this.restService.request<StudyHistories.StudyHistoryCreateUpdateDto, StudyHistories.StudyHistory>({
      method: 'PUT',
      url: `/api/app/studyHistory/${id}`,
      body: createStudyHistoryInput
    },
    { apiName: this.apiName });
  }

  deleteById(id: string): Observable<void> {
    return this.restService.request<void, void>({
      method: 'DELETE',
      url: `/api/app/studyHistory/${id}`
    },
    { apiName: this.apiName });
  }
}
