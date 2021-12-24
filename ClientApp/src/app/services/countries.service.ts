import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const COUNTRIES_API = 'https://localhost:5001/api/countries';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class CountriesService {

  constructor(private http: HttpClient) { }

  public getInfo(countryName: string): Observable<any> {
    return this.get('info', countryName);
  }

  public getFlag(countryName: string): Observable<any> {
    return this.http.get(`${COUNTRIES_API}/flag/${countryName}`, { ...httpOptions, responseType: 'blob' });
  }

  public getCoat(countryName: string): Observable<any> {
    return this.get('coat', countryName);
  }

  public getAnthem(countryName: string): Observable<any> {
    return this.get('anthem', countryName);
  }

  private get(property: string, countryName: string): Observable<any> {
    return this.http.get(`${COUNTRIES_API}/${property}/${countryName}`, httpOptions);
  }

}
