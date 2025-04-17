import { Routes } from '@angular/router';
import { HomepageComponent } from './pages/homepage/homepage.component';
import { MoviesComponent } from './pages/movies/movies.component';
import { SeriesComponent } from './pages/series/series.component';
import { BookmarksComponent } from './pages/bookmarks/bookmarks.component';
import { LoginComponent } from './components/login/login.component';
import { AppComponent } from './app.component';
import { LayoutComponent } from './components/layout/layout.component';

// export const routes: Routes = [
//   { path: '', redirectTo: 'login', pathMatch: 'full' },
//   { path: 'login', component: LoginComponent },
//   { path: '', component: AppComponent, 
//     children: [
//       { path: 'home', component: HomepageComponent },
// ];


export const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  {
    path: 'login',
    component: LoginComponent
  },

  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: 'home', component: HomepageComponent, title: 'Mango Entertainment: Home' },
      { path: 'movies', component: MoviesComponent },
      { path: 'series', component: SeriesComponent },
      { path: 'bookmarks', component: BookmarksComponent }
    ]
  }
];