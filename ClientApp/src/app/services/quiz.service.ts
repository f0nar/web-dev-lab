import { Injectable } from '@angular/core';
import { QuizTest, SimpleQuizTest } from '../common/QuizTest';

@Injectable({
  providedIn: 'root'
})
export class QuizService {

  constructor() { }

  public getTests(countryName: string): QuizTest[] {
    return [
      new SimpleQuizTest("How are you?", ["OK", 'Fine', 'So-so', 'Bad'], ["Fine", 'OK']),
      new SimpleQuizTest("What is the capital of Great Britain?", ['USA', 'London', 'Kyiv'], ["London"])
    ];
  }

}
