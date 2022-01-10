import {
    AuthService, ConfigStateService, CurrentTenantDto,
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
        `.app-sider-logo { color: #FFFFFFA6; height: 40px; padding-left: 16px; display: flex; align-items: center; }`
    ],
    template: `
<!--
        <select #mySelect (change)="changeLanguage(mySelect.value)">
            <option *ngFor="let item of (languages$ | async)"
                [value]="item.cultureName"
                [selected]="item.cultureName===(currentLanguage$ | async)"
                (click)="changeLanguage(item.cultureName)">
                {{ item.displayName }}
            </option>
        </select>

        <select #mySelect1 (change)="changeLanguage(mySelect1.value)">
            <option *ngFor="let item of (languages$ | async)"
                [value]="item.cultureName"
                [selected]="item.cultureName===(currentLanguage$ | async)"
                (click)="changeLanguage(item.cultureName)">
                {{ item.displayName }}
            </option>
        </select>
-->
        <nz-layout class="app-layout" *ngIf="visible">

            <nz-sider nzCollapsible
                      [(nzCollapsed)]="collapsed"
                      [nzCollapsedWidth]="collapsedWidth"
                      (nzCollapsedChange)="detectRef(tabList[selectedIndex].name)"
                      *ngIf="hasLoggedIn && menuMode==='side'">
                <div class="app-sider-logo">
                    <i nz-icon nzType="github" nzTheme="outline"></i>
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
                                (click)="createTab(menu.name)">
                                <i nz-icon *ngIf="menu.icon" [nzType]="menu.icon"></i>
                                <span>{{ menu.title }}</span>
                            </li>
                            <li nz-submenu
                                *ngIf="menu.children"
                                [nzDisabled]="menu.disabled"
                                [nzIcon]="menu.icon"
                                [nzOpen]="menu.open"
                                [nzPaddingLeft]="menu.level * 16"
                                [nzTitle]="menu.title">
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
                        <nz-sider nzCollapsible [(nzCollapsed)]="collapsed" [nzCollapsedWidth]="48" [nzTrigger]="null">
                            <div class="app-sider-logo">
                                <i nz-icon nzType="bars"></i>
                            </div>
                        </nz-sider>
                    </nz-layout>
                </nz-header>

                <nz-content style="display:grid;place-items:center" *ngIf="!hasLoggedIn">
                    <nz-result nzStatus="403" nzTitle="401" nzSubTitle="Sorry, you are not authorized to access this page.就是不显示中文">
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
                                <div nz-dropdown [nzDropdownMenu]="menu2" nzPlacement="bottomRight"
                                     style="height:40px;margin-right:16px;display:grid;place-items:center;">
                                    <nz-avatar [nzGap]="1" [nzText]="'Edward'" [nzSize]="30"></nz-avatar>
                                </div>
                                <nz-dropdown-menu #menu2="nzDropdownMenu">
                                    <ul nz-menu>
                                        <li nz-menu-item>个人中心</li>
                                        <li nz-menu-item>个人设置</li>
                                        <li nz-menu-divider></li>
                                        <li nz-menu-item>退出登录</li>
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

    collapsed = false;
    collapsedWidth = 0; // 0 or 46
    menuList = [];
    menuMode = 'side'; // side or top
    selectedIndex = 0;
    tabList = [];

    private src = [
        {
            parentName: null,
            name: 'A',
            icon: 'bars',
            title: '仪表盘',
            component: AuthorComponent,
            closable: false
        },
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
            component: BookComponent,
            closable: true
        }
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
        //private configStateService: ConfigStateService,
        //private localizationService: LocalizationService,
        private oAuthService: OAuthService,
        //private sessionStateService: SessionStateService,
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

    /*currentTenant$: Observable<CurrentTenantDto> = this.sessionStateService.getTenant$();*/

    visible: boolean = true;

    //languages$: Observable<LanguageInfo[]> = this.configStateService.getDeep$('localization.languages');

    //currentLanguage$: Observable<string> = this.sessionStateService.getLanguage$();

    //changeLanguage(cultureName: string): void {
    //    this.sessionStateService.setLanguage(cultureName);
    //}

    //changeLanguageSubscription(): void {
    //    this.subscriptionService.addOne(this.localizationService.languageChange$, () => {
    //        this.visible = false;
    //        setTimeout(() => {
    //            this.visible = true;
    //        }, 0);
    //    });
    //}
}
