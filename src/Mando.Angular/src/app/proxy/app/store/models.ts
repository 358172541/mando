import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { BookType } from './book-type.enum';

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

export interface AuthorLookupDto extends EntityDto<string> {
  name?: string;
}

export interface AuthorUpdateDto {
  name: string;
  birthday: string;
  biography?: string;
}

export interface BookCreateDto {
  authorId: string;
  name: string;
  type: BookType;
  publishDate: string;
  price: number;
}

export interface BookDto extends EntityDto<string> {
  authorId?: string;
  authorName?: string;
  name?: string;
  type: BookType;
  publishDate?: string;
  price: number;
}

export interface BookGetListDto extends PagedAndSortedResultRequestDto {
  filter?: string;
}

export interface BookUpdateDto {
  authorId: string;
  name: string;
  type: BookType;
  publishDate: string;
  price: number;
}
