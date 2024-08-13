import { Component } from '@angular/core';
import { SelectionData } from '../../interfaces/selection-data';
import { RegularCardComponent } from '../../components/regular-card/regular-card.component';
import Selections from '../../../data.json'

@Component({
  selector: 'app-movies',
  standalone: true,
  imports: [RegularCardComponent],
  templateUrl: './movies.component.html',
  styleUrl: './movies.component.scss',
})
export class MoviesComponent {
  selectionDataList: SelectionData[] = Selections.filter((selection) => selection.category === "Movie")
}
