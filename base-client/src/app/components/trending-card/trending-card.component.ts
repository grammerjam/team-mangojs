import { Component, Input } from '@angular/core';
import { SelectionData } from '../../interfaces/selection-data';

@Component({
  selector: 'app-trending-card',
  standalone: true,
  imports: [],
  templateUrl: './trending-card.component.html',
  styleUrl: './trending-card.component.scss'
})
export class TrendingCardComponent {
  @Input() selectionData: SelectionData = { id: '', title: '', thumbnail: { trending: { small: '', large: '' }, regular: { small: '', medium: '', large: '' } }, category: '', rating: '', isBookmarked: false, isTrending: false, year: 0 }
  
}
