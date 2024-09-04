import { Component, inject, OnInit } from '@angular/core';
import { RegularCardComponent } from '../../components/regular-card/regular-card.component';
import { SelectionData } from '../../interfaces/selection-data';
// import Selections from '../../../data.json'
import { HttpClient } from '@angular/common/http';
import { AsyncPipe } from '@angular/common';
import { SelectionsService } from '../../lib/selections.service';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [RegularCardComponent, AsyncPipe],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.scss',
})
export class HomepageComponent {
  trendingDataList: SelectionData[] = []
  recommendedDataList: SelectionData[] = []
  trendingSubscription?: Subscription
  recommendedSubscription?: Subscription
  constructor(private selectionsService: SelectionsService) {}
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

  recommendedObservor = {
    next: (data: SelectionData[]) => {
      this.recommendedDataList = data
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
    this.selectionsService.fetchRecommendedSelections().subscribe(data => {
      this.recommendedDataList = data;
    })
  }

  ngOnDestroy(): void {
    if(this.trendingSubscription) {
      this.trendingSubscription.unsubscribe()
    }
    if (this.recommendedSubscription) {
      this.recommendedSubscription.unsubscribe()
    }
  }
}
