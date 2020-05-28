import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {WebSiteComponent} from "./web-site/web-site.component";


const routes: Routes = [
  {
    path: '',
    children: [
      {path: '', component: WebSiteComponent, data: {title: 'web site'}}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WebsiteRoutingModule {
}
