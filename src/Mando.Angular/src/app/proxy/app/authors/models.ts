import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface AuthorCreateDto {
  name: string;
  birthday: string;
  biography?: string;
}

export interface AuthorDto extends EntityDto<string> {
  name?: string;
  birthday?: string;
  biography?: string;
}

export interface AuthorGetListDto extends PagedAndSortedResultRequestDto {
  filter?: string;
}

export interface AuthorUpdateDto {
  name: string;
  birthday: string;
  biography?: string;
}
