import { Injectable } from '@angular/core';
import { Subject, Observable } from "rxjs";

@Injectable()
export class ResponsiveDisplayService {

    private isMobile = new Subject();

    constructor() {
        this.checkMobileStatus();
    }

    public mobileStatus: Observable<any> = this.isMobile.asObservable();

    public checkMobileStatus() {
        var isMoblie= (window.innerWidth <= 768) ? true : false;
        this.isMobile.next(isMoblie);
    }
}