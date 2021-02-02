import { NgModule, SecurityContext } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { MatTreeModule } from '@angular/material/tree';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

import { MarkdownModule, MarkedOptions } from 'ngx-markdown';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SideMenuComponent } from './sidemenu/sidemenu.component';
import { HeaderbarComponent } from './headerbar/headerbar.component';
import { FooterbarComponent } from './footerbar/footerbar.component';
import { ContentAreaComponent } from './contentarea/contentarea.component';

import { ArticleProvider } from './services/article.provider';
import { ResponsiveDisplayService } from './services/responsivedisplay.service';
import { TreeNodeConverter } from './services/treenode.converter';
import { MenuProvider } from './services/menu.provider';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { CatalogueFilter } from './services/catalogue.filter.provider';


@NgModule({
    declarations: [
        AppComponent,
        SideMenuComponent,
        HeaderbarComponent,
        FooterbarComponent,
        ContentAreaComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        MatTreeModule,
        MatButtonModule,
        MatIconModule,
        HttpClientModule,
        MarkdownModule.forRoot({
            sanitize: SecurityContext.NONE,
            markedOptions: {
                provide: MarkedOptions,
                useValue: {
                  gfm: true,
                  breaks: false,
                  pedantic: false,
                  smartLists: true,
                  smartypants: false,
                },
            }}),
        NoopAnimationsModule,
    ],
    providers: [
        ArticleProvider,
        MenuProvider,
        ResponsiveDisplayService,
        CatalogueFilter,
        TreeNodeConverter
    ],
    bootstrap: [
        AppComponent
    ]
})

export class AppModule { }
