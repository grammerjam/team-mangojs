import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { BehaviorSubject, Observable } from "rxjs";
import { SelectionData } from '../interfaces/selection-data';

@Injectable({
  providedIn: 'root'
})
export class SelectionsService {

  Selections$: BehaviorSubject<SelectionData[]>

  constructor(private http: HttpClient) {
    this.Selections$ = new BehaviorSubject<SelectionData[]>(this.selections)
  }

  protected selections: SelectionData[] = [];


  fetchSelections(): Observable<SelectionData []> {
    return this.http.get<SelectionData[]>("http://localhost:3000/selections")
  }

  getSelections() {
    return this.fetchSelections().subscribe((data) => this.selections = data);
  }

  addSelections(s: SelectionData): void {
    this.selections.push(s)
    this.Selections$.next(this.selections)
  }
}
