import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { BookDto, BookCreateDto, BookService, bookTypeOptions, BookUpdateDto, AuthorLookupDto } from '@proxy/app/books';
import { format } from 'date-fns';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
    providers: [
        ListService
    ],
    selector: 'app-book',
    styles: [],
    template: `
        <nz-table #nzTable nzBordered nzSize="small" [nzData]="bookPagedResultDto.items">
            <thead>
                <tr>
                    <th>作者</th>
                    <th>名称</th>
                    <th>类型</th>
                    <th>出版日期</th>
                    <th>价格</th>
                    <th>操作</th>
                </tr>
            </thead>
            <tbody>
                <tr *ngFor="let item of nzTable.data">
                    <td>{{ item.authorName }}</td>
                    <td>{{ item.name }}</td>
                    <td>{{ item.type }}</td>
                    <td>{{ item.publishDate | date:'yyyy-MM-dd' }}</td>
                    <td>{{ item.price }}</td>
                    <td>
                        <a nz-button nzSize="small" nzType="link" (click)="updateBook(item.id)">
                            {{ 'AbpUi::Edit' | abpLocalization }}
                        </a>
                        <a nz-button nzSize="small" nzType="link" (click)="deleteBook(item.id)">
                            {{ 'AbpUi::Delete' | abpLocalization }}
                        </a>
                    </td>
                </tr>
            </tbody>
        </nz-table>

        <button nz-button nzType="primary" (click)="createBook()">新增</button>

        <nz-modal nzTitle="新增" [nzWidth]="320" [nzFooter]="null" [(nzVisible)]="createBookModalVisible" (nzOnCancel)="createBookModalVisible = false">
            <ng-container *nzModalContent>
                <form nz-form [formGroup]="createBookFormGroup" (ngSubmit)="createBookSubmit()" nzLayout="vertical">

                    <nz-form-item>
                        <nz-form-label nzRequired>作者</nz-form-label>
                        <nz-form-control nzErrorTip="字段作者不可为空">
                            <nz-select formControlName="authorId">
                                <nz-option [nzValue]="item.id" [nzLabel]="item.name" *ngFor="let item of authorLookupDtos$ | async"></nz-option>
                            </nz-select>
                        </nz-form-control>
                    </nz-form-item>

                    <nz-form-item>
                        <nz-form-label nzRequired>名称</nz-form-label>
                        <nz-form-control nzErrorTip="字段名称不可为空">
                            <input nz-input formControlName="name" />
                        </nz-form-control>
                    </nz-form-item>

                    <nz-form-item>
                        <nz-form-label nzRequired>类型</nz-form-label>
                        <nz-form-control nzErrorTip="字段类型不可为空">
                            <nz-select formControlName="type">
                                <nz-option [nzValue]="item.value" [nzLabel]="item.key" *ngFor="let item of bookTypeOptions"></nz-option>
                            </nz-select>
                        </nz-form-control>
                    </nz-form-item>

                    <nz-form-item>
                        <nz-form-label nzRequired>发布日期</nz-form-label>
                        <nz-form-control nzErrorTip="字段发布日期不可为空">
                            <nz-date-picker formControlName="publishDate" [ngStyle]="{ width: '100%' }"></nz-date-picker>
                        </nz-form-control>
                    </nz-form-item>

                    <nz-form-item>
                        <nz-form-label nzRequired>价格</nz-form-label>
                        <nz-form-control nzErrorTip="字段价格不可为空">
                            <input nz-input formControlName="price" />
                        </nz-form-control>
                    </nz-form-item>

                    <nz-form-item>
                        <nz-form-control>
                            <button nz-button nzBlock nzType="primary">提交</button>
                        </nz-form-control>
                    </nz-form-item>

                </form>
            </ng-container>
        </nz-modal>

        <nz-modal nzTitle="编辑" [nzWidth]="320" [nzFooter]="null"
            [(nzVisible)]="updateBookModalVisible" (nzOnCancel)="updateBookModalVisible=false"
        >
            <ng-container *nzModalContent>
                <form nz-form [formGroup]="updateBookFormGroup" (ngSubmit)="updateBookSubmit()" nzLayout="vertical">

                    <nz-form-item>
                        <nz-form-label nzRequired>作者</nz-form-label>
                        <nz-form-control nzErrorTip="字段作者不可为空">
                            <nz-select formControlName="authorId">
                                <nz-option [nzValue]="item.id" [nzLabel]="item.name" *ngFor="let item of authorLookupDtos$ | async"></nz-option>
                            </nz-select>
                        </nz-form-control>
                    </nz-form-item>

                    <nz-form-item>
                        <nz-form-label nzRequired>名称</nz-form-label>
                        <nz-form-control nzErrorTip="字段名称不可为空">
                            <input nz-input formControlName="name" />
                        </nz-form-control>
                    </nz-form-item>

                    <nz-form-item>
                        <nz-form-label nzRequired>类型</nz-form-label>
                        <nz-form-control nzErrorTip="字段类型不可为空">
                            <nz-select formControlName="type">
                                <nz-option [nzValue]="item.value" [nzLabel]="item.key" *ngFor="let item of bookTypeOptions"></nz-option>
                            </nz-select>
                        </nz-form-control>
                    </nz-form-item>

                    <nz-form-item>
                        <nz-form-label nzRequired>发布日期</nz-form-label>
                        <nz-form-control nzErrorTip="字段发布日期不可为空">
                            <nz-date-picker formControlName="publishDate"></nz-date-picker>
                        </nz-form-control>
                    </nz-form-item>

                    <nz-form-item>
                        <nz-form-label nzRequired>价格</nz-form-label>
                        <nz-form-control nzErrorTip="字段价格不可为空">
                            <input nz-input formControlName="price" />
                        </nz-form-control>
                    </nz-form-item>

                    <nz-form-item>
                        <nz-form-control>
                            <button nz-button nzBlock nzType="primary">提交</button>
                        </nz-form-control>
                    </nz-form-item>

                </form>
            </ng-container>
        </nz-modal>
    `,
})
export class BookComponent implements OnInit {

    bookPagedResultDto = {
        items: [],
        totalCount: 0,
    } as PagedResultDto<BookDto>;

    authorLookupDtos$: Observable<AuthorLookupDto[]> = this.bookService.getAuthorLookup().pipe(map(r => r.items));

    bookTypeOptions = bookTypeOptions;

    constructor(
        private formBuilder: FormBuilder,
        private bookService: BookService,
        public readonly listService: ListService,
    ) {

    }

    ngOnInit() {
        const bookPagedResultDto$ = bookGetListDto => this.bookService.getList({ ...bookGetListDto, filter: '' });
        this.listService.hookToQuery(bookPagedResultDto$).subscribe(bookPagedResultDto => {
            this.bookPagedResultDto = bookPagedResultDto;
        });
    }

    createBookFormGroup: FormGroup;

    createBookModalVisible: boolean = false;

    createBook() {
        this.createBookFormGroup = this.formBuilder.group({
            authorId: [null, Validators.required],
            name: [null, Validators.required],
            type: [null, Validators.required],
            publishDate: [null, Validators.required],
            price: [null, Validators.required]
        });

        this.createBookModalVisible = true;
    }

    createBookSubmit() {
        if (this.createBookFormGroup.invalid)
            return;

        const formGroupValue = this.createBookFormGroup.value;

        const bookCreateDto = {
            authorId: formGroupValue.authorId,
            name: formGroupValue.name,
            type: formGroupValue.type,
            publishDate: format(formGroupValue.publishDate, 'yyyy-MM-dd'), //
            price: formGroupValue.price
        } as BookCreateDto;

        this.bookService.create(bookCreateDto).subscribe(() => {
            this.createBookModalVisible = false;
            this.createBookFormGroup.reset();
            this.listService.get();
        });
    }

    updateBookDtoId: string;

    updateBookFormGroup: FormGroup;

    updateBookModalVisible: boolean = false;

    updateBook(id: string) {
        this.bookService.get(id).subscribe(bookDto => {
            this.updateBookDtoId = id;

            this.updateBookFormGroup = this.formBuilder.group({
                authorId: [bookDto.authorId, Validators.required],
                name: [bookDto.name, Validators.required],
                type: [bookDto.type, Validators.required],
                publishDate: [new Date(bookDto.publishDate), Validators.required],
                price: [bookDto.price, Validators.required]
            });

            this.updateBookModalVisible = true;
        });
    }

    updateBookSubmit() {
        if (this.updateBookFormGroup.invalid)
            return;

        const formGroupValue = this.updateBookFormGroup.value;

        const bookUpdateDto = {
            authorId: formGroupValue.authorId,
            name: formGroupValue.name,
            type: formGroupValue.type,
            publishDate: format(formGroupValue.publishDate, 'yyyy-MM-dd'), //
            price: formGroupValue.price
        } as BookUpdateDto;

        this.bookService.update(this.updateBookDtoId, bookUpdateDto).subscribe(() => {
            this.updateBookModalVisible = false;
            this.updateBookFormGroup.reset();
            this.listService.get();
        });
    }

    deleteBook(id: string) {
        this.bookService.delete(id).subscribe(() => {
            this.listService.get();
        });
    }
}
