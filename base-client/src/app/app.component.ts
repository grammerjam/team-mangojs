import { Component } from "@angular/core";
import { RouterOutlet } from "@angular/router";
import { HomepageComponent } from "./pages/homepage/homepage.component";
import { MoviesComponent } from "./pages/movies/movies.component";
import { SeriesComponent } from "./pages/series/series.component";
import { BookmarksComponent } from "./pages/bookmarks/bookmarks.component";
import { NavbarComponent } from "./components/navbar/navbar.component";

@Component({
	selector: "app-root",
	standalone: true,
	imports: [RouterOutlet, HomepageComponent, MoviesComponent, SeriesComponent, BookmarksComponent, NavbarComponent],
	templateUrl: "./app.component.html",
	styleUrl: "./app.component.scss",
})
export class AppComponent {
	title = "Mango Entertainment";
}