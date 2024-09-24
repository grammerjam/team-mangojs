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

  private apiURL = 'http://localhost:3000/selections'


  fetchAllSelections(): Observable<SelectionData []> {
    return this.http.get<SelectionData[]>(this.apiURL)
  }

  fetchTrendingSelections(): Observable<SelectionData[]> {
    return this.http.get<SelectionData[]>(`${this.apiURL}?isTrending=true`)
  }

  fetchRecommendedSelections(): Observable<SelectionData[]> {
    return this.http.get<SelectionData[]>(`${this.apiURL}?isTrending=false`)
  }

  fetchMovies(): Observable<SelectionData[]> {
    return this.http.get<SelectionData[]>(`${this.apiURL}?category=Movie`)
  }

  fetchSeries(): Observable<SelectionData[]> {
    return this.http.get<SelectionData[]>(`${this.apiURL}?category=TV%20Series`)

  }

  fetchBookmarks(): Observable<SelectionData[]> {
    return this.http.get<SelectionData[]>(`${this.apiURL}?isBookmarked=true`)

  }
}
