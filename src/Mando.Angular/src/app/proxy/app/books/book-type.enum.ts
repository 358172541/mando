import { mapEnumToOptions } from '@abp/ng.core';

export enum BookType {
  Undefined = 0,
  Adventure = 1,
  Fantastic = 2,
}

export const bookTypeOptions = mapEnumToOptions(BookType);
