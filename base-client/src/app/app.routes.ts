import { Routes } from '@angular/router';
import { HomepageComponent } from './pages/homepage/homepage.component';
import { MoviesComponent } from './pages/movies/movies.component';
import { SeriesComponent } from './pages/series/series.component';
import { BookmarksComponent } from './pages/bookmarks/bookmarks.component';

export const routes: Routes = [
  {path: '', component: HomepageComponent},
  {path: 'movies', component: MoviesComponent},
  {path: 'series', component: SeriesComponent},
  {path: 'bookmarks', component: BookmarksComponent},
];
