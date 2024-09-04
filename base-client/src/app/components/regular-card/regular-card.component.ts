import { Component, Input } from '@angular/core';
import { SelectionData } from '../../interfaces/selection-data';

@Component({
  selector: 'app-regular-card',
  standalone: true,
  imports: [],
  templateUrl: './regular-card.component.html',
  styleUrl: './regular-card.component.scss'
})
export class RegularCardComponent {
  @Input() selectionData: SelectionData = {id: '', title: '', thumbnail: {trending: {small: '', large: ''}, regular: {small: '', medium: '', large: ''}}, category: '', rating: '', isBookmarked: false, isTrending: false, year: 0}
}
