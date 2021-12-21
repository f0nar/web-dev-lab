import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { QuizJson } from '../common/QuizTest';

const QUIZZ_API = 'https://localhost:5001/api/quizzes/'

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class QuizService {

  constructor(private http: HttpClient) { }

  public getQuizz(quizId: any): Observable<QuizJson> {
    return this.http.get<QuizJson>(`${QUIZZ_API}/${quizId}`, httpOptions);
  }

  public getQuizzes(): Observable<QuizJson[] > {
    return this.http.get<QuizJson[]>(QUIZZ_API, httpOptions);
  }

  public submitQuestion(quizRes: any): Observable<any>  {
    return this.http.post(`${QUIZZ_API}/submit`, quizRes, httpOptions);
  }

}
