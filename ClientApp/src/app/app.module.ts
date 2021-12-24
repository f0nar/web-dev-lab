import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ButtonModule as PrimeNGButtonModule } from 'primeng/button';
import { CheckboxModule as PrimeNGCheckboxModule } from 'primeng/checkbox';
import { DynamicDialogModule as PrimeNGDynamicDialogModule } from 'primeng/dynamicdialog';
import { ToolbarModule as PrimeNGToolbar } from 'primeng/toolbar';
import { InputTextModule as PrimeNGInputTextModule } from 'primeng/inputtext';
import { PanelModule as PrimeNGPanelModule } from 'primeng/panel';
import { PasswordModule as PrimeNGPasswordModule } from 'primeng/password';
import { MessagesModule as PrimeNGMessagesModule } from 'primeng/messages';
import { MessageModule as PrimeNGMessageModule  } from 'primeng/message';

import { AppComponent } from './app.component';
import { MapQuizComponent } from './components/map-quiz/map-quiz.component';
import { QuizService } from './services/quiz.service';
import { QuizPanelComponent } from './components/quiz-panel/quiz-panel.component';
import { CountriesService } from './services/countries.service';
import { StorageService } from './services/storage.service';
import { AuthService } from './services/auth.service';
import { LoginComponent } from './components/login/login.component';
import { authInterceptorProviders } from './helpers/auth.interceptor';
import { errorInterceptorProviders } from './helpers/error.interceptor';
import { appRoutingModule, routes } from './routes/routes';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { TheotyPanelComponent } from './components/theoty-panel/theoty-panel.component';

@NgModule({
  declarations: [
    AppComponent,
    MapQuizComponent,
    QuizPanelComponent,
    LoginComponent,
    TheotyPanelComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    HttpClientModule,

    PrimeNGButtonModule,
    PrimeNGCheckboxModule,
    PrimeNGDynamicDialogModule,
    PrimeNGToolbar,
    PrimeNGPanelModule,
    PrimeNGInputTextModule,
    PrimeNGPasswordModule,
    PrimeNGMessageModule,
    PrimeNGMessagesModule,

    //RouterModule.forRoot(routes)
  ],
  exports: [
    //RouterModule
  ],
  providers: [
    QuizService,
    StorageService,
    AuthService,
    CountriesService,
    authInterceptorProviders,
    //errorInterceptorProviders
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
