import { Injectable } from '@angular/core';
import { RestService, ABP } from '@abp/ng.core';
import { ReligousLives } from '../store/models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReligousLivesService {
  apiName = 'Default';

  constructor(private restService: RestService) { }

  getListByInput(params = {} as ReligousLives.ReligousLivesQueryParams): Observable<ReligousLives.Response> {
    return this.restService.request<void, ReligousLives.Response>({
      method: 'GET',
      url: '/api/app/religousLife',
      params
    },
    { apiName: this.apiName });
  }

  createByInput(createReligousLifeInput: ReligousLives.ReligousLifeCreateUpdateDto): Observable<ReligousLives.ReligousLife> {
    return this.restService.request<ReligousLives.ReligousLifeCreateUpdateDto, ReligousLives.ReligousLife>({
      method: 'POST',
      url: '/api/app/religousLife',
      body: createReligousLifeInput
    },
    { apiName: this.apiName });
  }

  

  getById(id: string): Observable<ReligousLives.ReligousLife> {
    return this.restService.request<void, ReligousLives.ReligousLife>({
      method: 'GET',
      url: `/api/app/religousLife/${id}`
    },
    { apiName: this.apiName });
  }

  updateByIdAndInput(createReligousLifeInput: ReligousLives.ReligousLifeCreateUpdateDto, id: string): Observable<ReligousLives.ReligousLife> {
    return this.restService.request<ReligousLives.ReligousLifeCreateUpdateDto, ReligousLives.ReligousLife>({
      method: 'PUT',
      url: `/api/app/religousLife/${id}`,
      body: createReligousLifeInput
    },
    { apiName: this.apiName });
  }

  deleteById(id: string): Observable<void> {
    return this.restService.request<void, void>({
      method: 'DELETE',
      url: `/api/app/religousLife/${id}`
    },
    { apiName: this.apiName });
  }
}
