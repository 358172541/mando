import { Component, ComponentFactoryResolver, Input, OnInit, Type, ViewChild } from "@angular/core";
import { TabDirective } from "../directives/tab.directive";

@Component({
    providers: [],
    selector: 'app-tab',
    styles: [],
    template: `<ng-template tab></ng-template>`,
})
export class TabComponent implements OnInit {

    @Input() component: Type<any>;

    @ViewChild(TabDirective, { static: true }) tab: TabDirective;

    constructor(private cfr: ComponentFactoryResolver) {

    }

    ngOnInit(): void {
        this.tab.vcr.clear();
        this.tab.vcr.createComponent(
            this.cfr.resolveComponentFactory(this.component)
        );
    }
}
