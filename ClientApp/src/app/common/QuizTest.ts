
export interface QuizTest {

    getQuestion() : string;
  
    getOptions(): string[];
  
    isCorrect(answers: string[]) : boolean;
  
}
  
export class SimpleQuizTest implements QuizTest {
  
    constructor(private questin: string, private options: string[], private answers: string[], private allCorrect = false) { }
    
    public getQuestion() : string {
      return this.questin;
    }
  
    public getOptions(): string[] {
      return this.options;
    }
  
    public isCorrect(answers: string[]) : boolean {
      return answers &&
        this.answers.length == answers.length &&
        this.allCorrect ? this.answers.every(answer => answers.includes(answer)) : this.answers.some(answer => answers.includes(answer));
    }
  
}