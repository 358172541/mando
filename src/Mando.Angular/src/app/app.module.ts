import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { CoreModule } from '@abp/ng.core';

import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { NzAvatarModule } from 'ng-zorro-antd/avatar';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzCheckboxModule } from 'ng-zorro-antd/checkbox';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzResultModule } from 'ng-zorro-antd/result';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzTabsModule } from 'ng-zorro-antd/tabs';

import { AppComponent } from './app.component';
import { BookComponent } from './pages/book/book.component';
import { CrudComponent } from './pages/crud/crud.component';
import { AuthorComponent } from './pages/author/author.component';
import { TabComponent } from './components/tab.component';

import { TabDirective } from './directives/tab.directive';

import { environment } from '../environments/environment';
import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { registerLocale } from '@abp/ng.core/locale';
import { registerLocaleData } from '@angular/common';
import zh from '@angular/common/locales/zh';
import { zh_CN } from 'ng-zorro-antd/i18n';

registerLocaleData(zh);

import { NZ_ICONS } from 'ng-zorro-antd/icon';
import { GithubOutline } from '@ant-design/icons-angular/icons';

@NgModule({
    bootstrap: [
        AppComponent
    ],
    declarations: [
        AppComponent,
        AuthorComponent,
        BookComponent,
        CrudComponent,
        TabComponent,
        TabDirective
    ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,

        CoreModule.forRoot({
            environment,
            registerLocaleFn: registerLocale(),
        }),

        NzAvatarModule,
        NzButtonModule,
        NzCheckboxModule,
        NzDatePickerModule,
        NzDropDownModule,
        NzFormModule,
        NzGridModule,
        NzIconModule,
        NzInputModule,
        NzLayoutModule,
        NzModalModule,
        NzMenuModule,
        NzResultModule,
        NzSelectModule,
        NzTableModule,
        NzTabsModule,

        RouterModule.forRoot([]),
    ],
    providers: [
        { provide: NZ_I18N, useValue: zh_CN },
        { provide: NZ_ICONS, useValue: [ GithubOutline ] }
    ]
})
export class AppModule {

}
