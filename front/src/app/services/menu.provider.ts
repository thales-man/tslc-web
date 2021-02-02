import { Injectable } from '@angular/core';

import { MenuNode } from '../models/menu.node';
import { menuCategories } from '../models/menu.categories'
import { PostedArticle } from '../models/posted.article';
import { ICatalogue } from '../models/catalogue';
import { CatalogueFilter } from './catalogue.filter.provider';

@Injectable()
export class MenuProvider {

    constructor(
        private filter: CatalogueFilter)
    {
    }

    public createBranch(name: string): MenuNode {
        return {
            name: name,
            count: 0,
            children: []
        };        
    }

    private createLeaf(article: PostedArticle): MenuNode {
        return {
            name: article.title,
            topic: article.topic !== menuCategories.external ? article.topic : article.path,
            year: article.year,
            month: article.month,
            article: article.article,
            count: 0
        };        
    }

    private getFilteredArticles(filter: string, fromCatalogue: ICatalogue): PostedArticle[] {
        return this.filter.findArticles(filter, fromCatalogue);
    }

    private getSimpleMenu(subjectTitle: string, filter: string, fromCatalogue: ICatalogue): MenuNode {
        var menu = this.createBranch(subjectTitle);

        this.getFilteredArticles(filter, fromCatalogue)
            .forEach(post => {
                var node = this.createLeaf(post);
                menu.children.push(node);
            });

        return menu;
    }

    public getPagesMenu(subjectTitle: string, fromCatalogue: ICatalogue): MenuNode {
        return this.getSimpleMenu(subjectTitle, menuCategories.pages, fromCatalogue);
    }

    public getExternalMenu(subjectTitle: string, fromCatalogue: ICatalogue): MenuNode {
        return this.getSimpleMenu(subjectTitle, menuCategories.external, fromCatalogue);
    }

    public getArticlesMenu(subjectTitle: string, fromCatalogue: ICatalogue): MenuNode {
        var menu = this.createBranch(subjectTitle);
        var yearBranch: MenuNode;
        var monthBranch: MenuNode;

        this.getFilteredArticles(menuCategories.articles, fromCatalogue)
            .sort((x, y) => 0 - (x.publicationDate > y.publicationDate ? 1 : -1))
            .forEach(post => {
                var node = this.createLeaf(post);

                yearBranch = menu.children.find(x => x.name == node.year);
                if(!yearBranch) {
                    yearBranch = this.createBranch(node.year);
                    menu.children.push(yearBranch);
                }

                monthBranch = yearBranch.children.find(x => x.name == node.month);
                if(!monthBranch) {
                    monthBranch = this.createBranch(node.month);
                    yearBranch.children.push(monthBranch);
                }

                monthBranch.children.push(node);
                monthBranch.count++;
                yearBranch.count++;
            });

        return menu;
    }
}
