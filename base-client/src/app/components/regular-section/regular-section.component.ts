import { Component, Input } from '@angular/core';
import { SelectionData } from '../../interfaces/selection-data';
import { RegularCardComponent } from "../regular-card/regular-card.component";

@Component({
  selector: 'app-regular-section',
  standalone: true,
  imports: [RegularCardComponent],
  templateUrl: './regular-section.component.html',
  styleUrl: './regular-section.component.scss'
})
export class RegularSectionComponent {
  @Input() sectionTitle: string = ''
  @Input() sectionData: SelectionData[] = []
}
