import { Routes } from '@angular/router';
import {BlankComponent} from "./shared/layouts/blank";
import {FullComponent} from "./shared/layouts/full";


export const AppRoutes: Routes = [
  { path: '', redirectTo: '/website', pathMatch: 'full' },
  {
    path: '',
    component: BlankComponent,
    children: [
      {
        path: '',
        loadChildren: () => import('./authentication/authentication.module').then(m => m.AuthenticationModule)
      }
    ]
  },
  {
    path: '',
    component: FullComponent,
    children: [
      {
        path: '',
        redirectTo: '/dashboard',
        pathMatch: 'full'
      },
      {
        path: 'dashboard', loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule)
      }
    ]
  },
  {
    path: '',
    component: BlankComponent, //  todo ooo crear una una componente  con marcos de la web
    children: [
      {
        path: '',
        redirectTo: '/website',
        pathMatch: 'full'
      },
      {
        path: 'website', loadChildren: () => import('./website/website.module').then(m => m.WebsiteModule)
      }
    ]
  },
  {
    path: '**',
    redirectTo: '/404'
  }
];
