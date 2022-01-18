import {
    AuthService, CurrentUserDto, ConfigStateService, CurrentTenantDto,
    LanguageInfo, LocalizationService, SessionStateService, SubscriptionService
} from '@abp/ng.core';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { Observable } from 'rxjs';
import { AuthorComponent } from './pages/author/author.component';
import { BookComponent } from './pages/book/book.component';
import { CrudComponent } from './pages/crud/crud.component';

@Component({
    //providers: [
    //    SubscriptionService
    //],
    selector: 'app',
    styles: [
        `.app-layout { height: 100vh; }`,
        `.app-sider-logo { height: 58px; padding-left: 16px; display: flex; align-items: center; }`
    ],
    template: `
        <nz-layout class="app-layout" *ngIf="visible">

            <nz-sider nzCollapsible
                [(nzCollapsed)]="collapsed"
                [nzCollapsedWidth]="collapsedWidth"
                (nzCollapsedChange)="detectRef(tabList[selectedIndex].name)"
                *ngIf="hasLoggedIn && menuMode==='side'"
            >

                <!-- should be component -->
                <div class="app-sider-logo">
                    <i nz-icon nzType="field-string" nzTheme="outline" style="color:white;font-size:30px"></i>
                </div>

                <ul nz-menu nzMode="inline" nzTheme="dark">
                    <ng-container *ngTemplateOutlet="menuTpl; context: { $implicit: menuList }"></ng-container>
                    <ng-template #menuTpl let-menuList>
                        <ng-container *ngFor="let menu of menuList">
                            <li nz-menu-item
                                *ngIf="!menu.children"
                                [nzDisabled]="menu.disabled"
                                [nzPaddingLeft]="menu.level * 16"
                                [nzSelected]="menu.selected"
                                (click)="createTab(menu.name)"
                            >
                                <i nz-icon *ngIf="menu.icon" [nzType]="menu.icon"></i>
                                <span>{{ menu.title }}</span>
                            </li>
                            <li nz-submenu
                                *ngIf="menu.children"
                                [nzDisabled]="menu.disabled"
                                [nzIcon]="menu.icon"
                                [nzOpen]="menu.open"
                                [nzPaddingLeft]="menu.level * 16"
                                [nzTitle]="menu.title"
                            >
                                <ul>
                                    <ng-container *ngTemplateOutlet="menuTpl; context: { $implicit: menu.children }"></ng-container>
                                </ul>
                            </li>
                        </ng-container>
                    </ng-template>
                </ul>

            </nz-sider>

            <nz-layout>

                <nz-header *ngIf="!hasLoggedIn">
                    <nz-layout>
                        <nz-sider nzCollapsible [(nzCollapsed)]="collapsed" [nzCollapsedWidth]="collapsedWidth" [nzTrigger]="null">

                            <!-- should be component -->
                            <div class="app-sider-logo">
                                <i nz-icon nzType="field-string" nzTheme="outline" style="color:white;font-size:30px"></i>
                            </div>

                        </nz-sider>
                        <nz-content></nz-content>

                        <!-- should be component -->
                        <nz-sider>
                            <div nz-row nzJustify="end">
                                <div nz-dropdown [nzDropdownMenu]="langDropdownMenu" nzPlacement="bottomRight"
                                     style="height:58px;margin-right:16px;display:grid;place-items:center;">
                                    <i nz-icon nzType="font-size" nzTheme="outline" style="color:white"></i>
                                </div>
                                <nz-dropdown-menu #langDropdownMenu="nzDropdownMenu">
                                    <ul nz-menu>
                                        <li nz-menu-item
                                            *ngFor="let item of (languages$ | async)"
                                            [nzSelected]="item.cultureName===(currentLanguage$ | async)"
                                            (click)="changeLanguage(item.cultureName)"
                                        >
                                            {{ item.displayName }}
                                        </li>
                                    </ul>
                                </nz-dropdown-menu>
                            </div>
                        </nz-sider>

                    </nz-layout>
                </nz-header>

                <nz-content style="display:grid;place-items:center" *ngIf="!hasLoggedIn">
                    <nz-result nzStatus="403" nzTitle="" nzSubTitle="">
                        <div nz-result-extra>
                            <button nz-button nzType="primary" (click)="goToLogin()">Go to Login</button>
                        </div>
                    </nz-result>
                </nz-content>

                <nz-header *ngIf="hasLoggedIn">
                    <nz-layout>
                        <nz-content></nz-content>

                        <nz-sider>
                            <div nz-row nzJustify="end">
                                <div nz-dropdown [nzDropdownMenu]="userDropdownMenu" nzPlacement="bottomRight"
                                     style="height:58px;margin-right:16px;display:grid;place-items:center;">
                                    <nz-avatar [nzGap]="1" [nzText]="(currentUser$ | async)?.userName" [nzSize]="30" style="background-color:#1890ff">
                                        <!--{{ (selectedTenant$ | async)?.name }}-->
                                    </nz-avatar>
                                </div>
                                <nz-dropdown-menu #userDropdownMenu="nzDropdownMenu">
                                    <ul nz-menu>
                                        <li nz-menu-divider></li>
                                        <li nz-menu-item (click)="logout()">退出登录</li>
                                    </ul>
                                </nz-dropdown-menu>

                                <!-- should be component -->
                                <div nz-dropdown [nzDropdownMenu]="langDropdownMenu" nzPlacement="bottomRight"
                                     style="height:58px;margin-right:16px;display:grid;place-items:center;">
                                    <i nz-icon nzType="font-size" nzTheme="outline" style="color:white"></i>
                                </div>
                                <nz-dropdown-menu #langDropdownMenu="nzDropdownMenu">
                                    <ul nz-menu>
                                        <li nz-menu-item
                                            *ngFor="let item of (languages$ | async)"
                                            [nzSelected]="item.cultureName===(currentLanguage$ | async)"
                                            (click)="changeLanguage(item.cultureName)"
                                        >
                                            {{ item.displayName }}
                                        </li>
                                    </ul>
                                </nz-dropdown-menu>

                            </div>
                        </nz-sider>
                    </nz-layout>
                </nz-header>

                <nz-content *ngIf="hasLoggedIn">
                    <nz-tabset nzType="card" [nzSelectedIndex]="selectedIndex">
                        <nz-tab *ngFor="let item of tabList"
                                [nzTitle]="titleTpl"
                                (nzClick)="selectTab(item.name)"
                                (nzContextmenu)="reloadTab(item.name)">

                            <ng-template #titleTpl>
                                <i nz-icon [nzType]="item.icon"></i>
                                <span>{{ item.title }}</span>
                                <i nz-icon
                                    nzType="close"
                                    *ngIf="item.closable"
                                    (click)="deleteTab(item.name)"
                                    style="margin-left:12px;margin-right:0px"></i>
                            </ng-template>

                            <app-tab [component]="item.component"></app-tab>

                        </nz-tab>
                    </nz-tabset>
                </nz-content>
            </nz-layout>

        </nz-layout>
    `
})
export class AppComponent implements OnInit {

    currentUser$: Observable<CurrentUserDto> = this.configStateService.getOne$('currentUser');
    selectedTenant$ = this.sessionStateService.getTenant$();

    collapsed = false;
    collapsedWidth = 0; // 0 or 62
    menuList = [];
    menuMode = 'side'; // side or top
    selectedIndex = 0;
    tabList = [];

    private src = [
        {
            parentName: null,
            name: 'a',
            icon: 'bars',
            title: '系统首页',
            component: CrudComponent,
            closable: false
        },
        {
            parentName: null,
            name: 'b',
            icon: 'bars',
            title: '网上书店示例',
            component: null,
            closable: false
        },
        {
            parentName: 'b',
            name: 'c',
            icon: 'bars',
            title: '作者管理',
            component: AuthorComponent,
            closable: true
        },
        {
            parentName: 'b',
            name: 'd',
            icon: 'bars',
            title: '书籍管理',
            component: BookComponent,
            closable: true
        },
        {
            parentName: null,
            name: 'e',
            icon: 'bars',
            title: '问题跟踪示例',
            component: null,
            closable: false
        },
        {
            parentName: 'e',
            name: 'f',
            icon: 'bars',
            title: '问题管理',
            component: CrudComponent,
            closable: true
        },
/*
        {
            parentName: null,
            name: 'B',
            icon: 'bars',
            title: '系统权限',
            component: null,
            closable: false
        },
        {
            parentName: 'B',
            name: 'C',
            icon: 'bars',
            title: '权限管理',
            component: null,
            closable: false
        },
        {
            parentName: 'C',
            name: 'D',
            icon: 'bars',
            title: '角色管理',
            component: CrudComponent,
            closable: true
        },
        {
            parentName: 'C',
            name: 'E',
            icon: 'bars',
            title: '用户管理',
            component: CrudComponent,
            closable: true
        },
        {
            parentName: null,
            name: 'F',
            icon: 'bars',
            title: '系统设置',
            component: CrudComponent,
            closable: true
        }
*/
    ];

    private structSrc(name: string, src: any[]): any[] {
        // assign properties
        let assignStruct = [];
        for (let i in src) {
            assignStruct.push(
                Object.assign(src[i], {
                    children: null,
                    disabled: false, // TODO
                    level: 0,
                    open: false,
                    selected: false,
                })
            );
        }

        // selected property handling
        let selectedStruct = [];
        for (let i in assignStruct) {
            let data = assignStruct[i];
            let selected = false;
            if (data.name === name) {
                selected = true;
            }
            data.selected = selected;
            selectedStruct.push(data);
        }

        // open property handling
        let openNames = []
        let openNamesFunc = (name) => {
            let item = selectedStruct.find(x => x.name === name);
            if (item) {
                openNames.push(name);
            } else {
                return;
            }
            if (item.parentName === null) {
                return;
            }
            openNamesFunc(item.parentName);
        }
        openNamesFunc(name);

        let openStruct = [];
        for (let i in selectedStruct) {
            let item = selectedStruct[i];
            let open = false;
            if (this.collapsed === false) { // when sider not collapsed
                if (openNames.includes(item.name) && this.menuMode === 'side') {
                    open = true;
                }
            }
            item.open = open;
            openStruct.push(item);
        }

        // level property handling
        let levelStruct = [];
        let levelStructFunc = (data, name = null, level = 0) => {
            if (this.collapsed === false && this.menuMode === 'side') { // when sider not collapsed
                level++;
            }
            //if (this.menuMode === 'top') {
            //    level = 1;
            //}
            let items = data.filter(x => x.parentName === name);
            for (let i in items) {
                let item = items[i];
                item.level = level;
                levelStruct.push(item);
                levelStructFunc(data, item.name, level);
            }
        }
        levelStructFunc(openStruct);

        // children property handling
        let childrenStruct = [];
        let childrenStructFunc = (data, name = null) => {
            let items = data.filter(x => {
                let children = data.filter(y => x.name === y.parentName);
                if (children.length > 0) {
                    x.children = children;
                }
                return x.parentName === name;
            })
            for (let i in items) {
                childrenStruct.push(items[i]);
            }
        }
        childrenStructFunc(levelStruct);

        return childrenStruct;
    }

    private detectRef(name: string): void {
        const index = this.tabList.findIndex(x => x.name === name);
        this.selectedIndex = 0;
        this.changeDetectorRef.detectChanges();
        this.selectedIndex = index;

        const struct = this.structSrc(name, this.src); // rxjs?
        this.menuList = [];
        this.changeDetectorRef.detectChanges();
        this.menuList = struct;
    }

    createTab(name: string): void {
        const index = this.tabList.findIndex(x => x.name === name);
        if (this.selectedIndex === index) {
            return;
        }
        if (index < 0) {
            const find = this.src.find(x => x.name === name);
            this.tabList.push({
                icon: find.icon,
                component: find.component,
                name: find.name,
                title: find.title,
                closable: find.closable,
            });
        }
        this.detectRef(name);
    }

    deleteTab(name: string): void {
        const index = this.tabList.findIndex(x => x.name === name);
        this.tabList.splice(index, 1);
        if (this.selectedIndex === index) {
            this.detectRef(this.tabList[0].name);
        }
    }

    reloadTab(name: string): void {
        const index = this.tabList.findIndex(x => x.name === name);
        if (this.selectedIndex === index) {
            if (confirm('reload this tab?')) {
                const component = this.tabList[index];
                this.tabList.splice(index, 1);
                this.changeDetectorRef.detectChanges();
                this.tabList.splice(index, 0, component);
                this.detectRef(name);
            }
        }
    }

    selectTab(name: string): void {
        const index = this.tabList.findIndex(x => x.name === name);
        if (this.selectedIndex === index) {
            return;
        }
        this.detectRef(name);
    }

    constructor(
        private authService: AuthService,
        private changeDetectorRef: ChangeDetectorRef,
        private configStateService: ConfigStateService,
        //private localizationService: LocalizationService,
        private oAuthService: OAuthService,
        private sessionStateService: SessionStateService,
        //private subscriptionService: SubscriptionService
    ) {
        //this.changeLanguageSubscription();
    }

    get hasLoggedIn(): boolean {
        return this.oAuthService.hasValidAccessToken();
    }

    goToLogin(): void {
        this.authService.navigateToLogin();
    }

    logout(): void {
        this.authService.logout().subscribe();
    }

    ngOnInit(): void {
        if (this.hasLoggedIn) {
            const item = this.src[0]; // HOME
            if (this.tabList.length <= 0) {
                this.tabList.push({
                    icon: item.icon,
                    component: item.component,
                    name: item.name,
                    title: item.title,
                    closable: item.closable,
                })
            }
            this.menuList = this.structSrc(item.name, this.src);
        }
    }

    visible: boolean = true;

    languages$: Observable<LanguageInfo[]> = this.configStateService.getDeep$('localization.languages');

    currentLanguage$: Observable<string> = this.sessionStateService.getLanguage$();

    changeLanguage(cultureName: string): void {
        this.sessionStateService.setLanguage(cultureName);
    }

    //changeLanguageSubscription(): void {
    //    this.subscriptionService.addOne(this.localizationService.languageChange$, () => {
    //        this.visible = false;
    //        setTimeout(() => {
    //            this.visible = true;
    //        }, 0);
    //    });
    //}
}
