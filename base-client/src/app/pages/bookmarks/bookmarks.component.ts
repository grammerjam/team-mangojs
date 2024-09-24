import { Component, Input } from '@angular/core';
import { RegularCardComponent } from '../../components/regular-card/regular-card.component';
import { SelectionData } from '../../interfaces/selection-data';
import Selections from '../../../data.json'

@Component({
  selector: 'app-bookmarks',
  standalone: true,
  imports: [RegularCardComponent],
  templateUrl: './bookmarks.component.html',
  styleUrl: './bookmarks.component.scss'
})
export class BookmarksComponent {
  selectionDataList: SelectionData[] = Selections.selections.filter((selection) => selection.isBookmarked === true)

}
