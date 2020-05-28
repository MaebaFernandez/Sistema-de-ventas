import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {LoginComponent} from "./login/login.component";
import {NotFoundComponent} from "./404/not-found.component";
import {RegisterComponent} from "./register/register.component";


const routes: Routes = [  {
  path: '',
  children: [
    {
      path: '404',
      component: NotFoundComponent
    },
    {
      path: 'login',
      // component: LoginComponent
    },
    {
      path: 'register',
      component: RegisterComponent
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthenticationRoutingModule { }
