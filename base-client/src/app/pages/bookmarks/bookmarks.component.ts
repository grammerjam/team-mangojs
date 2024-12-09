import { Component, Input } from '@angular/core';
import { RegularCardComponent } from '../../components/regular-card/regular-card.component';
import { SelectionData } from '../../interfaces/selection-data';
import Selections from '../../../data.json'
import { Subscription } from 'rxjs';
import { SelectionsService } from '../../lib/selections.service';

@Component({
  selector: 'app-bookmarks',
  standalone: true,
  imports: [RegularCardComponent],
  templateUrl: './bookmarks.component.html',
  styleUrl: './bookmarks.component.scss'
})
export class BookmarksComponent {
  bookmarkDataList: SelectionData[] = Selections.selections.filter((selection) => selection.isBookmarked === true)
  bookmarkSubscription?: Subscription
  constructor(private selectionsService: SelectionsService) { }
  seriesObservor = {
    next: (data: SelectionData[]) => {
      this.bookmarkDataList = data
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
    this.selectionsService.fetchBookmarks().subscribe(data => {
      this.bookmarkDataList = data;
    })
  }

  ngOnDestroy(): void {
    if (this.bookmarkSubscription) {
      this.bookmarkSubscription.unsubscribe()
    }
  }
}
