import { Component, OnInit } from '@angular/core';
import { DialogService } from 'primeng/dynamicdialog';
import { QuizTest } from 'src/app/common/QuizTest';
import { QuizService } from '../../services/quiz.service';
import { QuizPanelComponent } from '../quiz-panel/quiz-panel.component';

@Component({
  selector: 'map-quiz',
  templateUrl: './map-quiz.component.html',
  styleUrls: ['./map-quiz.component.scss'],
  providers: [ DialogService, QuizService ]
})
export class MapQuizComponent implements OnInit {

  public quizTests: QuizTest[] = [];

  constructor(
    private quizService: QuizService,
    private dialogService: DialogService
  ) { }

  ngOnInit(): void { }

  public runQuiz(countryName: string) {
    this.quizTests = this.quizService.getTests(countryName);
    const dialogRef = this.dialogService.open(QuizPanelComponent, {
      header: 'Quiz',
      showHeader: true,
      width: '25%',
      data: { tests: this.quizTests }
    });
    dialogRef.onClose.subscribe(answersNumber => console.log('correct answers number: ', answersNumber));
  }

}
