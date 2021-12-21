
export interface OptionJson {
  id: string
  content: string;
  matchContent: string;
  questionId: string;
  question: string;
}

export interface QuestionJson {
  id: string;
  content: string;
  type: 1;
  quizId: string;
  quiz: string;
  options: OptionJson[];
}

export interface QuizJson {
  id: string;
  title: string;
  description: string;
  questions: QuestionJson[];
}

export interface IOption {
  getId(): string;
  getContent(): string;
  getMatch(): string;
  getQuestionId(): string;
  getQuestion(): string;
}

export interface IQuestion {
  getId(): string;
  getContent(): string;
  getType(): number;
  getQuizId(): string;
  getOptions(): IOption[];
}

export interface IQuiz {
  getId(): string;
  getTitle(): string;
  getDescription(): string;
  getQuestions(): IQuestion[];
}

export class Option implements IOption {
  constructor(private json: OptionJson) {}

  getId(): string {
    return this.json.id;
  }
  getContent(): string {
    return this.json.content
  }
  getMatch(): string {
    return this.json.matchContent;
  }
  getQuestionId(): string {
    return this.json.questionId;
  }
  getQuestion(): string {
    return this.json.question;
  }

}

export class Question implements IQuestion {
  private options: IOption[];

  constructor(private json: QuestionJson) {
    this.options = json.options.map(option => new Option(option));
  }

  getType(): number {
    return this.json.type;
  }
  getQuizId(): string {
    return this.json.quizId;
  }
  getOptions(): IOption[] {
    return this.options;
  }
  getId(): string {
    return this.json.id;
  }
  getContent(): string {
    return this.json.content
  }

}

export class Quiz implements IQuiz {
  private questions: IQuestion[];
  constructor(private json: QuizJson) {
    this.questions = this.json.questions.map(question => new Question(question));
  }
  getId(): string {
    return this.json.id;
  }
  getTitle(): string {
    return this.json.title;
  }
  getDescription(): string {
    return this.json.description;
  }
  getQuestions(): IQuestion[] {
    return this.questions;
  }
  
}