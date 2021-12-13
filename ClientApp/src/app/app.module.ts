import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ButtonModule as PrimeNGButtonModule } from 'primeng/button';
import { CheckboxModule as PrimeNGCheckboxModule } from 'primeng/checkbox';
import { DynamicDialogModule as PrimeNGDynamicDialogModule } from 'primeng/dynamicdialog';

import { AppComponent } from './app.component';
import { MapQuizComponent } from './components/map-quiz/map-quiz.component';
import { QuizService } from './services/quiz.service';
import { QuizPanelComponent } from './components/quiz-panel/quiz-panel.component';

@NgModule({
  declarations: [
    AppComponent,
    MapQuizComponent,
    QuizPanelComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    BrowserAnimationsModule,
    PrimeNGButtonModule,
    PrimeNGCheckboxModule,
    PrimeNGDynamicDialogModule
  ],
  providers: [QuizService],
  bootstrap: [AppComponent]
})
export class AppModule { }
