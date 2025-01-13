import { Component } from '@angular/core';
import { SelectionData } from '../../interfaces/selection-data';
import { AsyncPipe } from '@angular/common';
import { SelectionsService } from '../../lib/selections.service';
import { Subscription } from 'rxjs';
import { TrendingSectionComponent } from '../../components/trending-section/trending-section.component';
import { RegularSectionComponent } from '../../components/regular-section/regular-section.component';
import { SearchComponent } from '../../components/search/search.component';

@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [AsyncPipe, SearchComponent, TrendingSectionComponent, RegularSectionComponent],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.scss',
})
export class HomepageComponent {
  recommendedDataList: SelectionData[] = []
  recommendedSubscription?: Subscription
  constructor(private selectionsService: SelectionsService) {}
 

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
    this.selectionsService.fetchRecommendedSelections().subscribe(data => {
      this.recommendedDataList = data;
    })
  }

  ngOnDestroy(): void {
    if (this.recommendedSubscription) {
      this.recommendedSubscription.unsubscribe()
    }
  }
}
