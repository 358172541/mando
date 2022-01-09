import { Directive, ViewContainerRef } from "@angular/core";

@Directive({
    selector: '[tab]',
})
export class TabDirective {
    constructor(public vcr: ViewContainerRef) {

    }
}
