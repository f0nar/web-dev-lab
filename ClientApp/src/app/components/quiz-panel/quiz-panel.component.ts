import { Component, OnInit } from '@angular/core';
import { DynamicDialogRef } from 'primeng/dynamicdialog';
import { DynamicDialogConfig } from 'primeng/dynamicdialog';
import { IQuiz } from 'src/app/common/QuizTest';
import { QuizService } from 'src/app/services/quiz.service';

@Component({
  templateUrl: './quiz-panel.component.html',
  styleUrls: ['./quiz-panel.component.scss']
})
export class QuizPanelComponent implements OnInit {

  public tests: IQuiz[] = [];
  public correctAnswers = 0;
  public testIndex = -1;
  public selectedAnswers: string[] = [];

  constructor(
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig,
    public quizService: QuizService) { }

  ngOnInit(): void {
    this.tests = this.config.data?.tests || [];
    if (this.tests.length > 0) { this.testIndex = 0 };
    this.correctAnswers = 0;
  }

  public next() {
    this.aceptTask();
  }

  public finish() {
    this.aceptTask();
    this.ref.close(this.correctAnswers);
  }

  private aceptTask() {
    if (this.testIndex >= 0 && this.testIndex < (this.tests?.length || 0)) {
      //this.tests[this.testIndex].isCorrect(this.selectedAnswers) && ++this.correctAnswers;
      ++this.testIndex;
      this.selectedAnswers = [];
    }
  }

}
