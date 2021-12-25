import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { CountryInfo } from "../models/countryInfo.model";

const countryUrl = "https://localhost:5001/api/countries";

@Injectable({
    providedIn: 'root'
  })
export class CountryService {
    constructor(
        private http: HttpClient
    ) { }

    public getCountryInfo(countryName: string): Observable<CountryInfo> {
        return this.http.get<CountryInfo>(`${countryUrl}/info/${countryName}`);
    }

    public getCountryFlag(countryName: string): Observable<Blob> {
        return this.http.get(`${countryUrl}/flag/${countryName}`,
            { responseType: 'blob' });
    }

    public getCountryCoat(countryName: string): Observable<Blob> {
        return this.http.get(`${countryUrl}/coat/${countryName}`,
            { responseType: 'blob' });
    }

    public getCountryAnthem(countryName: string): Observable<Blob> {
        return this.http.get(`${countryUrl}/anthem/${countryName}`,
            { responseType: 'blob' });
    }
}