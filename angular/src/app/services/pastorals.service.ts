import { Injectable } from '@angular/core';
import { RestService, ABP } from '@abp/ng.core';
import { Pastorals } from '../store/models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PastoralsService {
  apiName = 'Default';

  constructor(private restService: RestService) { }

  getListByInput(params = {} as Pastorals.PastoralsQueryParams): Observable<Pastorals.Response> {
    return this.restService.request<void, Pastorals.Response>({
      method: 'GET',
      url: '/api/app/pastoral',
      params
    },
    { apiName: this.apiName });
  }

  createByInput(createPastoralInput: Pastorals.PastoralCreateUpdateDto): Observable<Pastorals.Pastoral> {
    return this.restService.request<Pastorals.PastoralCreateUpdateDto, Pastorals.Pastoral>({
      method: 'POST',
      url: '/api/app/pastoral',
      body: createPastoralInput
    },
    { apiName: this.apiName });
  }

  

  getById(id: string): Observable<Pastorals.Pastoral> {
    return this.restService.request<void, Pastorals.Pastoral>({
      method: 'GET',
      url: `/api/app/pastoral/${id}`
    },
    { apiName: this.apiName });
  }

  updateByIdAndInput(createPastoralInput: Pastorals.PastoralCreateUpdateDto, id: string): Observable<Pastorals.Pastoral> {
    return this.restService.request<Pastorals.PastoralCreateUpdateDto, Pastorals.Pastoral>({
      method: 'PUT',
      url: `/api/app/pastoral/${id}`,
      body: createPastoralInput
    },
    { apiName: this.apiName });
  }

  deleteById(id: string): Observable<void> {
    return this.restService.request<void, void>({
      method: 'DELETE',
      url: `/api/app/pastoral/${id}`
    },
    { apiName: this.apiName });
  }
}
