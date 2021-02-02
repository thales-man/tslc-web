import { Injectable } from '@angular/core';

import { ICatalogue } from '../models/catalogue';
import { PostedArticle } from '../models/posted.article';

@Injectable()
export class CatalogueFilter {

    public defaultArticle(): PostedArticle {
        return {article: "loading-content", title: "loading content", topic: "posts", publicationDate: new Date(), path: "/assets/nocontent.md" };
    }

    public findArticles(usingFilter: string, fromCatalogue: ICatalogue): PostedArticle[] {
        return fromCatalogue.articles.filter(x => x.topic == usingFilter);
    }

    public findArticleBy(id: string, fromCatalogue: ICatalogue): PostedArticle {
        return fromCatalogue.articles.find(post => post.article === id);
    }

    public findArticle(withTopic: string, inYear: string, andMonth: string, andName: string, fromCatalogue: ICatalogue): PostedArticle {
        return fromCatalogue.articles.find(post => 
            post.topic === withTopic 
            && post.year === inYear
            && post.month === andMonth 
            && post.article === andName);
    }
}