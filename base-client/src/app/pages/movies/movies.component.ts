import { Component } from '@angular/core';
import { SelectionData } from '../../interfaces/selection-data';
import Selections from '../../../data.json'
import { SelectionsService } from '../../lib/selections.service';
import { Subscription } from 'rxjs';
import { RegularSectionComponent } from '../../components/regular-section/regular-section.component';
import { SearchComponent } from '../../components/search/search.component';

@Component({
  selector: 'app-movies',
  standalone: true,
  imports: [RegularSectionComponent, SearchComponent],
  templateUrl: './movies.component.html',
  styleUrl: './movies.component.scss',
})
export class MoviesComponent {
  movieDataList: SelectionData[] = Selections.selections.filter((selection) => selection.category === "Movie")
  movieSubscription?: Subscription
  constructor(private selectionsService: SelectionsService) { }
  seriesObservor = {
    next: (data: SelectionData[]) => {
      this.movieDataList = data
      console.log('next block', data)
    },
    error: (error: any) => {
      console.log(error)
    },
    complete: () => {
      console.log('stream completed')
    }
  }

  ngOnInit(): void {
    this.selectionsService.fetchMovies().subscribe(data => {
      this.movieDataList = data;
    })
  }

  ngOnDestroy(): void {
    if (this.movieSubscription) {
      this.movieSubscription.unsubscribe()
    }
  }
}
