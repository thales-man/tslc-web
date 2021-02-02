import { Component, OnInit } from '@angular/core';
import { FlatTreeControl } from '@angular/cdk/tree';
import { MatTreeFlatDataSource, MatTreeFlattener } from '@angular/material/tree';

import { MenuNode } from '../models/menu.node';
import { menuHeaders } from '../models/menu.headers'
import { FlattenedNode } from '../models/flattened.node';
import { TreeNodeConverter } from '../services/treenode.converter';
import { MenuProvider } from '../services/menu.provider';
import { ArticleProvider } from '../services/article.provider';

@Component({
    selector: 'app-sidemenu',
    templateUrl: './sidemenu.component.html',
    styleUrls: ['./sidemenu.component.scss']
})

export class SideMenuComponent implements OnInit {

    constructor(
        private menuProvider: MenuProvider,
        private articleProvider: ArticleProvider,
        private nodeConverter: TreeNodeConverter) {
            this.homeMenu = this.menuProvider.createBranch(menuHeaders.pages);
            this.externalMenu = this.menuProvider.createBranch(menuHeaders.external);
            this.articles = this.menuProvider.createBranch(menuHeaders.articles);
        }

    public homeMenu: MenuNode;
    public externalMenu: MenuNode;
    public articles: MenuNode;
    public flatTree: FlatTreeControl<FlattenedNode>;
    public dataSource: MatTreeFlatDataSource<MenuNode, FlattenedNode>;

    public ngOnInit() {
        this.flatTree = new FlatTreeControl<FlattenedNode>(this.nodeConverter.level, this.nodeConverter.expandable);
        var treeFlattener = new MatTreeFlattener(this.nodeConverter.create, this.nodeConverter.level, this.nodeConverter.expandable, this.nodeConverter.children);

        this.dataSource = new MatTreeFlatDataSource(this.flatTree, treeFlattener);
    
        this.articleProvider
            .getCatalogue()
            .subscribe(catalogue => {

                this.homeMenu = this.menuProvider.getPagesMenu(menuHeaders.pages, catalogue);
                this.externalMenu = this.menuProvider.getExternalMenu(menuHeaders.external, catalogue);
                this.articles = this.menuProvider.getArticlesMenu(menuHeaders.articles, catalogue);

                this.dataSource.data = this.articles.children;
            });
    }

    public hasChild = (_: number, node: FlattenedNode) => this.nodeConverter.expandable(node);

    public closeTree() {
        this.flatTree.collapseAll();
    }

    public updateTree(node: FlattenedNode) {
        this.flatTree.dataNodes.forEach(element => {
            if (element.level === node.level && element !== node) {
                this.flatTree.collapse(element);
            }
        });
    }
}
