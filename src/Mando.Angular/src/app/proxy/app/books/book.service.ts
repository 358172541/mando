import type { AuthorLookupDto, BookCreateDto, BookDto, BookGetListDto, BookUpdateDto } from './models';
import { RestService } from '@abp/ng.core';
import type { ListResultDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  apiName = 'Default';

  create = (input: BookCreateDto) =>
    this.restService.request<any, BookDto>({
      method: 'POST',
      url: '/api/app/books',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/books/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, BookDto>({
      method: 'GET',
      url: `/api/app/books/${id}`,
    },
    { apiName: this.apiName });

  getAuthorLookup = () =>
    this.restService.request<any, ListResultDto<AuthorLookupDto>>({
      method: 'GET',
      url: '/api/app/books/lookup/authors',
    },
    { apiName: this.apiName });

  getList = (input: BookGetListDto) =>
    this.restService.request<any, PagedResultDto<BookDto>>({
      method: 'GET',
      url: '/api/app/books',
      params: { filter: input.filter, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: BookUpdateDto) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/books/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
