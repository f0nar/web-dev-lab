import { Injectable } from '@angular/core';

const TOKEN_KEY = 'auth-token';
const USER_KEY = 'auth-user';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor() { }

  public signOut(): void {
    window.sessionStorage.clear();
  }
  
  public saveToken(token: string): void {
    this.set(TOKEN_KEY, token);
  }

  public getToken(): string {
    return window.sessionStorage.getItem(TOKEN_KEY) || '';
  }

  public saveUser(user: any): void {
    this.set(USER_KEY, JSON.stringify(user))
  }

  public getUser(): any {
    const user = window.sessionStorage.getItem(USER_KEY);
    return user ? JSON.parse(user) : null;
  }

  private set(key: string, value: any) {
    window.sessionStorage.removeItem(key);
    window.sessionStorage.setItem(key, value);
  }

}
