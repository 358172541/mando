import type { AuthorCreateDto, AuthorDto, AuthorGetListDto, AuthorUpdateDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AuthorService {
  apiName = 'Default';

  create = (input: AuthorCreateDto) =>
    this.restService.request<any, AuthorDto>({
      method: 'POST',
      url: '/api/app/authors',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/authors/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, AuthorDto>({
      method: 'GET',
      url: `/api/app/authors/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: AuthorGetListDto) =>
    this.restService.request<any, PagedResultDto<AuthorDto>>({
      method: 'GET',
      url: '/api/app/authors',
      params: { filter: input.filter, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: AuthorUpdateDto) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/authors/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
