import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { ResponsiveDisplayService } from './services/responsivedisplay.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit, OnDestroy {
    title = 'tslc-web';

    private subscription: Subscription;

    public isShowingMenu: boolean;
    public isSmall: boolean;
    public menuWidth: Number;

    constructor(
        private responsiveDisplay: ResponsiveDisplayService) {
    }

    private processDisplayChange(isMobile: boolean) {
        this.isShowingMenu = !isMobile;
        this.isSmall = isMobile;
        this.checkShowMenu();
    }

    private checkShowMenu() {
        this.menuWidth = this.isShowingMenu ? 200 :0;
    }

    public ngOnInit() {
        this.subscription = this.responsiveDisplay.mobileStatus
            .subscribe(isMobile => this.processDisplayChange(isMobile));
            
        this.onResize();
    }

    public ngOnDestroy() {
        this.subscription.unsubscribe();
    }

    public onResize() {
        this.responsiveDisplay.checkMobileStatus();
    }

    public showMenu() {
        this.isShowingMenu = !this.isShowingMenu;
        this.checkShowMenu();
    }
}
