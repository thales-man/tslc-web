import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContentAreaComponent } from './contentarea/contentarea.component';

const routes:Routes = [
    { path: '', redirectTo : 'pages/2020/09/home', pathMatch : 'prefix'},
    { path: ':topic/:year/:month/:article', component: ContentAreaComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }
