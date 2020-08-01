import { Injectable } from '@angular/core';
import { RestService, ABP } from '@abp/ng.core';
import { Monks } from '../store/models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MonksService {
  apiName = 'Default';

  constructor(private restService: RestService) { }

  getListByInput(params = {} as Monks.MonksQueryParams): Observable<Monks.Response> {
    return this.restService.request<void, Monks.Response>({
      method: 'GET',
      url: '/api/app/monk',
      params
    },
    { apiName: this.apiName });
  }

  createByInput(createMonkInput: Monks.MonkCreateUpdateDto): Observable<Monks.Monk> {
    return this.restService.request<Monks.MonkCreateUpdateDto, Monks.Monk>({
      method: 'POST',
      url: '/api/app/monk',
      body: createMonkInput
    },
    { apiName: this.apiName });
  }

  

  getById(id: string): Observable<Monks.Monk> {
    return this.restService.request<void, Monks.Monk>({
      method: 'GET',
      url: `/api/app/monk/${id}`
    },
    { apiName: this.apiName });
  }

  updateByIdAndInput(createMonkInput: Monks.MonkCreateUpdateDto, id: string): Observable<Monks.Monk> {
    return this.restService.request<Monks.MonkCreateUpdateDto, Monks.Monk>({
      method: 'PUT',
      url: `/api/app/monk/${id}`,
      body: createMonkInput
    },
    { apiName: this.apiName });
  }

  deleteById(id: string): Observable<void> {
    return this.restService.request<void, void>({
      method: 'DELETE',
      url: `/api/app/monk/${id}`
    },
    { apiName: this.apiName });
  }
}
