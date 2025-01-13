import { Component } from '@angular/core';
import { SelectionData } from '../../interfaces/selection-data';
import Selections from '../../../data.json'
import { Subscription } from 'rxjs';
import { SelectionsService } from '../../lib/selections.service';
import { RegularSectionComponent } from '../../components/regular-section/regular-section.component';
import { SearchComponent } from '../../components/search/search.component';

@Component({
  selector: 'app-series',
  standalone: true,
  imports: [RegularSectionComponent, SearchComponent],
  templateUrl: './series.component.html',
  styleUrl: './series.component.scss'
})
export class SeriesComponent {
  seriesDataList: SelectionData[] = Selections.selections.filter((selection) => selection.category === "TV Series")
  seriesSubscription?: Subscription
  constructor(private selectionsService: SelectionsService) { }
  seriesObservor = {
    next: (data: SelectionData[]) => {
      this.seriesDataList = data
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
    this.selectionsService.fetchSeries().subscribe(data => {
      this.seriesDataList = data;
    })
  }

  ngOnDestroy(): void {
    if (this.seriesSubscription) {
      this.seriesSubscription.unsubscribe()
    }
  }
}
