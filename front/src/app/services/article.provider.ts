import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { ICatalogue } from '../models/catalogue';

@Injectable()
export class ArticleProvider {

    private articlesUrl: string = "/articles/catalogue";

    constructor(
        private http: HttpClient) {        
    }

    public getCatalogue(): Observable<ICatalogue> {
        return this.http.get<ICatalogue>(this.articlesUrl);
    }
}
