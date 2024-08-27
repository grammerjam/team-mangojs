import { Component, OnInit } from '@angular/core';
import { RegularCardComponent } from '../../components/regular-card/regular-card.component';
import { SelectionData } from '../../interfaces/selection-data';
// import Selections from '../../../data.json'
import { HttpClient } from '@angular/common/http';
import { AsyncPipe } from '@angular/common';
import { SelectionsService } from '../../selections.service';

@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [RegularCardComponent, AsyncPipe],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.scss',
})
export class HomepageComponent {
  // selections: any;
  constructor(private SelectionsService: SelectionsService){}

  // getSelections() {
  //   this.SelectionsService.getSelections('http://localhost:3000/selections').subscribe()
  // }


  trendingDataList = this.SelectionsService.getSelections('http://localhost:3000/selections?isTrending')
  selectionDataList = this.SelectionsService.getSelections('http://localhost:3000/selections?isTrending=false')
}
