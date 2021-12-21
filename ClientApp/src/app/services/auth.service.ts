import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const AUTH_API = 'https://localhost:5001/api/auth/';

const httpOptionObj = { 'Content-Type': 'application/json' };

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  public login(username: string, password: string): Observable<any> {
    return this.http.post(
      AUTH_API + 'login',
      { UserName: username, Password: password },
      { headers: new HttpHeaders(httpOptionObj), responseType: 'text' }
    );
  }

  // public register(username: string, email: string, password: string): Observable<any> {
  //   return this.http.post(AUTH_API + 'signup', { username, password }, httpOptions);
  // }

}
