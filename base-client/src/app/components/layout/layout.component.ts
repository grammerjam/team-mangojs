import { Component } from "@angular/core";
import { RouterOutlet } from "@angular/router";
import { HomepageComponent } from "../../pages/homepage/homepage.component";
import { MoviesComponent } from "../../pages/movies/movies.component";
import { SeriesComponent } from "../../pages/series/series.component";
import { BookmarksComponent } from "../../pages/bookmarks/bookmarks.component";
import { NavbarComponent } from "../../components/navbar/navbar.component";

@Component({
  selector: "app-layout",
  standalone: true,
  imports: [RouterOutlet, HomepageComponent, MoviesComponent, SeriesComponent, BookmarksComponent, NavbarComponent],
  templateUrl: "./layout.component.html",
  styleUrl: "./layout.component.scss",
})
export class LayoutComponent {
  title = "Mango Entertainment";
}
