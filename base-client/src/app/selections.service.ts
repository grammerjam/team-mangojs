import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable} from 'rxjs';
import { SelectionData } from './interfaces/selection-data';

const httpOptions = {
  headers: new HttpHeaders(
    {
      'Content-Type': 'application/json',
    }
  )
};

@Injectable({
  providedIn: 'root'
})
export class SelectionsService {
  selectionUrl = 'http://localhost:3000/selections/'
  constructor(private http: HttpClient) { }
  selections = []
  getSelections(): Observable<SelectionData[]> {
    const selections = this.http.get(`${this.selectionUrl}`)
      .subscribe()

    return selections
  }

}