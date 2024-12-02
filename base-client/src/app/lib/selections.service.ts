import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { BehaviorSubject, Observable } from "rxjs";
import { SelectionData } from '../interfaces/selection-data';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class SelectionsService {

  Selections$: BehaviorSubject<SelectionData[]>

  constructor(private http: HttpClient) {
    this.Selections$ = new BehaviorSubject<SelectionData[]>(this.selections)
  }

  protected selections: SelectionData[] = [];


  fetchAllSelections(): Observable<SelectionData []> {
    return this.http.get<SelectionData[]>(environment.apiURL)
  }


  fetchTrendingSelections(): Observable<SelectionData[]> {
    return this.http.get<SelectionData[]>(`${environment.apiURL}?isTrending=true`)
  }

  fetchRecommendedSelections(): Observable<SelectionData[]> {
    console.log(environment.apiURL)
    return this.http.get<SelectionData[]>(`${environment.apiURL}?isTrending=false`)
  }

  fetchMovies(): Observable<SelectionData[]> {
    return this.http.get<SelectionData[]>(`${environment.apiURL}?category=Movie`)
  }

  fetchSeries(): Observable<SelectionData[]> {
    return this.http.get<SelectionData[]>(`${environment.apiURL}?category=TV%20Series`)

  }

  fetchBookmarks(): Observable<SelectionData[]> {
    return this.http.get<SelectionData[]>(`${environment.apiURL}?isBookmarked=true`)

  }
}
