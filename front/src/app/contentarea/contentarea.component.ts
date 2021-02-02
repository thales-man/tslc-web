import { Component, ViewEncapsulation, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Subscription } from 'rxjs';

import { ArticleProvider } from '../services/article.provider';
import { PostedArticle } from '../models/posted.article';
import { ResponsiveDisplayService } from '../services/responsivedisplay.service';
import { CatalogueFilter } from '../services/catalogue.filter.provider';

@Component({
    selector: 'app-contentarea',
    templateUrl: './contentarea.component.html',
    styleUrls: ['./contentarea.component.scss'],
    encapsulation: ViewEncapsulation.None
})

export class ContentAreaComponent implements OnInit, OnDestroy {

    private subscription: Subscription;

    public postedArticle: PostedArticle;

    constructor(
        private activatedRoute: ActivatedRoute,
        private articleProvider: ArticleProvider,
        private filter: CatalogueFilter,
        private responsiveDisplay: ResponsiveDisplayService) {
            this.postedArticle = this.filter.defaultArticle();
    }
    
    private processRouteChange(params: ParamMap) {
        let topic = params.get('topic');
        let year = params.get('year');
        let month = params.get('month');
        let article = params.get('article');

        this.articleProvider
            .getCatalogue()
            .subscribe(catalogue => {
                let candidate = this.filter.findArticle(topic, year, month, article, catalogue);

                if(candidate.alias) {
                    candidate = this.filter.findArticleBy(candidate.alias, catalogue);
                }
        
                this.postedArticle = candidate;
                this.responsiveDisplay.checkMobileStatus();
            });
    }

    public ngOnInit() {
        this.subscription = this.activatedRoute.paramMap
            .subscribe(params => this.processRouteChange(params));
    }
    
    public ngOnDestroy() {
        this.subscription.unsubscribe();
    }
}
