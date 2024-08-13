import { Component } from '@angular/core';
import { RegularCardComponent } from '../../components/regular-card/regular-card.component';
import { SelectionData } from '../../interfaces/selection-data';
import Selections from '../../../data.json'

@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [RegularCardComponent],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.scss'
})
export class HomepageComponent {
  trendingDataList: SelectionData[] = Selections.filter((selection) => selection.isTrending === true)
  selectionDataList: SelectionData[] = Selections.filter((selection) => selection.isTrending === false)
}
