import { Component } from '@angular/core';
import { SelectionsService } from '../../lib/selections.service';
import { SelectionData } from '../../interfaces/selection-data';
import { Subscription } from 'rxjs';
import { TrendingCardComponent } from '../trending-card/trending-card.component';


@Component({
  selector: 'app-trending-section',
  standalone: true,
  imports: [TrendingCardComponent],
  templateUrl: './trending-section.component.html',
  styleUrl: './trending-section.component.scss'
})
export class TrendingSectionComponent {
  trendingDataList: SelectionData[] = []
  trendingSubscription?: Subscription
  constructor(private selectionsService: SelectionsService) { }
  trendingObservor = {
    next: (data: SelectionData[]) => {
      this.trendingDataList = data
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
    this.selectionsService.fetchTrendingSelections().subscribe(data => {
      this.trendingDataList = data;
    })
  }

  ngOnDestroy(): void {
    if (this.trendingSubscription) {
      this.trendingSubscription.unsubscribe()
    }
  }
}
