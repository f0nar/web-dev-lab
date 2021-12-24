import { Component, OnInit } from '@angular/core';
import { DialogService } from 'primeng/dynamicdialog';
import { filter } from 'rxjs/operators';
import { IQuiz } from 'src/app/common/QuizTest';
//import { QuizTest } from 'src/app/common/QuizTest';
import { QuizService } from '../../services/quiz.service';
import { QuizPanelComponent } from '../quiz-panel/quiz-panel.component';
import { TheotyPanelComponent } from '../theoty-panel/theoty-panel.component';

@Component({
  selector: 'map-quiz',
  templateUrl: './map-quiz.component.html',
  styleUrls: ['./map-quiz.component.scss'],
  providers: [ DialogService, QuizService ]
})
export class MapQuizComponent implements OnInit {

  public quizTests: IQuiz[] = [];

  constructor(
    private quizService: QuizService,
    private dialogService: DialogService
  ) { }

  ngOnInit(): void { }

  public showInfo(countryName: string) {
    const dialogRef = this.dialogService.open(TheotyPanelComponent, {
      header: 'Country info',
      showHeader: true,
      width: '40%',
      data: { countryName }
    });
  }

}
