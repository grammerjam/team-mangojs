import { Routes } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';
import { MoviesComponent } from './movies/movies.component';
import { SeriesComponent } from './series/series.component';
import { BookmarksComponent } from './bookmarks/bookmarks.component';

export const routes: Routes = [
  {path: '', component: HomepageComponent},
  {path: 'movies', component: MoviesComponent},
  {path: 'series', component: SeriesComponent},
  {path: 'bookmarks', component: BookmarksComponent},
];
