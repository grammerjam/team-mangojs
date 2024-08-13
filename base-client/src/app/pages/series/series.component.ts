import { Component } from '@angular/core';
import { RegularCardComponent } from '../../components/regular-card/regular-card.component';
import { SelectionData } from '../../interfaces/selection-data';
import Selections from '../../../data.json'

@Component({
  selector: 'app-series',
  standalone: true,
  imports: [RegularCardComponent],
  templateUrl: './series.component.html',
  styleUrl: './series.component.scss'
})
export class SeriesComponent {
    selectionDataList: SelectionData[] = Selections.filter((selection) => selection.category === "TV Series")

}
