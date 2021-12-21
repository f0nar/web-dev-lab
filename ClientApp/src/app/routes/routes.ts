import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from '../app.component';
import { LoginComponent } from '../components/login/login.component';
import { MapQuizComponent } from '../components/map-quiz/map-quiz.component';
import { AuthGuard } from '../helpers/auth.guard';


export const routes: Routes = [
    // {
    //     path: '',
    //     component: MapQuizComponent,
    //     canActivate: [AuthGuard]
    // },
    // {
    //     path: 'login',
    //     component: LoginComponent
    // },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const appRoutingModule = RouterModule.forRoot(routes);