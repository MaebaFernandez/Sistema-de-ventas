import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

// Modulos

import {AppComponent} from './app.component';
// componentes
import {FormsModule} from '@angular/forms';
import {RouterModule} from "@angular/router";
import {AppRoutes} from "./app.routing";
import {SharedModule} from "./shared";


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    // PagesModule,
    RouterModule.forRoot(AppRoutes),
    FormsModule,
    RouterModule,
    SharedModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
