import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map ,} from 'rxjs/operators';
import { Content } from './content';
import {HttpParams} from  "@angular/common/http";

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AppService {

  private Url = 'http://localhost:52295/api/save';  // URL to web api
  
  constructor(private http: HttpClient) { }

  public sendText (cont: Content): Observable<string[]> {
    var temp =  this.http.get<string[]>(`${this.Url}?text=${cont.value}`);
    return temp;
    
  }
}
