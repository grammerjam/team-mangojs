import { Component } from '@angular/core';
import { RegularCardComponent } from '../../components/regular-card/regular-card.component';
import { SelectionData } from '../../interfaces/selection-data';
import Selections from '../../../data.json'
import { Subscription } from 'rxjs';
import { SelectionsService } from '../../lib/selections.service';

@Component({
  selector: 'app-series',
  standalone: true,
  imports: [RegularCardComponent],
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
