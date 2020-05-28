import { NgModule } from "@angular/core";
import { BreadcrumbsComponent } from './breadcrumbs';
import { HeaderComponent } from './header/header.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { NopagefoundComponent } from './nopagefound/nopagefound.component';
import { FullComponent } from './layouts/full';
import { BlankComponent } from './layouts/blank';
import {RouterModule} from "@angular/router";



@NgModule({
  declarations: [
    BreadcrumbsComponent,
    HeaderComponent,
    SidebarComponent,
    NopagefoundComponent,
    FullComponent,
    BlankComponent
  ],
  imports: [
    RouterModule
  ],
  exports: [
    BreadcrumbsComponent,
    HeaderComponent,
    SidebarComponent,
    NopagefoundComponent,
    BlankComponent,
    FullComponent
  ]
})
export class SharedModule { }
