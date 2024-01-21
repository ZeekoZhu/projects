import { Route } from '@angular/router';
import { HomePageComponent } from './pages/home-page.component';

export const appRoutes: Route[] = [
  {
    path: '',
    pathMatch: 'full',
    component: HomePageComponent,
  },
];
