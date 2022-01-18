import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { AuthorDto, AuthorCreateDto, AuthorUpdateDto } from '@proxy/app/store';
import { AuthorService } from '@proxy/app/store/authors';
import { format } from 'date-fns';

@Component({
    providers: [
        ListService
    ],
    selector: 'app-author',
    template: `
        <nz-table #nzTable nzBordered nzSize="small" [nzData]="authorPagedResultDto.items">
            <thead>
                <tr>
                    <th>名称</th>
                    <th>生日</th>
                    <th>简介</th>
                    <th>操作</th>
                </tr>
            </thead>
            <tbody>
                <tr *ngFor="let item of nzTable.data">
                    <td>{{ item.name }}</td>
                    <td>{{ item.birthday | date:'yyyy-MM-dd' }}</td>
                    <td>{{ item.biography }}</td>
                    <td>
                        <a nz-button nzSize="small" nzType="link" (click)="updateAuthor(item.id)">
                            {{ 'AbpUi::Edit' | abpLocalization }}
                        </a>
                        <a nz-button nzSize="small" nzType="link" (click)="deleteAuthor(item.id)">
                            {{ 'AbpUi::Delete' | abpLocalization }}
                        </a>
                    </td>
                </tr>
            </tbody>
        </nz-table>

        <button nz-button nzType="primary" (click)="createAuthor()">新增</button>

        <nz-modal nzTitle="新增"  [nzWidth]="320" [nzFooter]="null"
            [(nzVisible)]="createAuthorModalVisible" (nzOnCancel)="createAuthorModalVisible = false"
        >
            <ng-container *nzModalContent>
                <form nz-form [formGroup]="createAuthorFormGroup" (ngSubmit)="createAuthorSubmit()" nzLayout="vertical">

                    <nz-form-item>
                        <nz-form-label nzRequired>名称</nz-form-label>
                        <nz-form-control nzErrorTip="字段名称不可为空">
                            <input nz-input formControlName="name" />
                        </nz-form-control>
                    </nz-form-item>

                    <nz-form-item>
                        <nz-form-label nzRequired>生日</nz-form-label>
                        <nz-form-control nzErrorTip="字段生日不可为空">
                            <nz-date-picker formControlName="birthday"></nz-date-picker>
                        </nz-form-control>
                    </nz-form-item>

                    <nz-form-item>
                        <nz-form-label>简介</nz-form-label>
                        <nz-form-control>
                            <textarea nz-input formControlName="biography" [nzAutosize]="{ minRows: 3, maxRows: 5 }"></textarea>
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

        <nz-modal nzTitle="编辑"  [nzWidth]="320" [nzFooter]="null" [(nzVisible)]="updateAuthorModalVisible" (nzOnCancel)="updateAuthorModalVisible = false">
            <ng-container *nzModalContent>
                <form nz-form [formGroup]="updateAuthorFormGroup" (ngSubmit)="updateAuthorSubmit()"  nzLayout="vertical">

                    <nz-form-item>
                        <nz-form-label nzRequired>名称</nz-form-label>
                        <nz-form-control nzErrorTip="字段名称不可为空">
                            <input nz-input formControlName="name" />
                        </nz-form-control>
                    </nz-form-item>

                    <nz-form-item>
                        <nz-form-label nzRequired>生日</nz-form-label>
                        <nz-form-control nzErrorTip="字段生日不可为空">
                            <nz-date-picker formControlName="birthday"></nz-date-picker>
                        </nz-form-control>
                    </nz-form-item>

                    <nz-form-item>
                        <nz-form-label>简介</nz-form-label>
                        <nz-form-control>
                            <textarea nz-input formControlName="biography" [nzAutosize]="{ minRows: 3, maxRows: 5 }"></textarea>
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
    `
})
export class AuthorComponent implements OnInit {

    authorPagedResultDto = {
        items: [],
        totalCount: 0,
    } as PagedResultDto<AuthorDto>;

    //crudTypeOptions = crudTypeOptions;

    constructor(
        private authorService: AuthorService,
        private formBuilder: FormBuilder,
        public readonly listService: ListService,
    ) {

    }

    ngOnInit(): void {
        const authorPagedResultDto$ = authorGetListDto => this.authorService.getList({ ...authorGetListDto, filter: '' });
        this.listService.hookToQuery(authorPagedResultDto$).subscribe(authorPagedResultDto => {
            this.authorPagedResultDto = authorPagedResultDto;
        });
    }

    createAuthorFormGroup: FormGroup;

    createAuthorModalVisible: boolean = false;

    createAuthor(): void {
        this.createAuthorFormGroup = this.formBuilder.group({
            name: [null, Validators.required],
            /*type: [null, Validators.required],*/
            birthday: [null, Validators.required],
            biography: [null],
        });

        this.createAuthorModalVisible = true;
    }

    createAuthorSubmit(): void {
        if (this.createAuthorFormGroup.invalid)
            return;

        const formGroupValue = this.createAuthorFormGroup.value;

        const authorCreateDto = {
            name: formGroupValue.name,
            //type: formGroupValue.type,
            birthday: format(formGroupValue.birthday, 'yyyy-MM-dd'), //
            biography: formGroupValue.biography
        } as AuthorCreateDto;

        this.authorService.create(authorCreateDto).subscribe(() => {
            this.createAuthorModalVisible = false;
            this.createAuthorFormGroup.reset();
            this.listService.get();
        });
    }

    updateAuthorDtoId: string;

    updateAuthorFormGroup: FormGroup;

    updateAuthorModalVisible: boolean = false;

    updateAuthor(id: string): void {
        this.authorService.get(id).subscribe(authorDto => {
            this.updateAuthorDtoId = id;

            this.updateAuthorFormGroup = this.formBuilder.group({
                name: [authorDto.name, Validators.required],
                //type: [authorDto.type, Validators.required],
                birthday: [new Date(authorDto.birthday), Validators.required],
                biography: [authorDto.biography],
            });

            this.updateAuthorModalVisible = true;
        });
    }

    updateAuthorSubmit(): void {
        if (this.updateAuthorFormGroup.invalid)
            return;

        const formGroupValue = this.updateAuthorFormGroup.value;

        const authorUpdateDto = {
            name: formGroupValue.name,
            //type: formGroupValue.type,
            birthday: format(formGroupValue.birthday, 'yyyy-MM-dd'), //
            biography: formGroupValue.biography
        } as AuthorUpdateDto;

        this.authorService.update(this.updateAuthorDtoId, authorUpdateDto).subscribe(() => {
            this.updateAuthorModalVisible = false;
            this.updateAuthorFormGroup.reset();
            this.listService.get();
        });
    }

    deleteAuthor(id: string): void {
        this.authorService.delete(id).subscribe(() => {
            this.listService.get();
        });
    }
}
