import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { LoginComponent } from './components/login/login.component';
import { StorageService } from './services/storage.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  providers: [ DialogService, StorageService ]
})
export class AppComponent {
  
  ref: DynamicDialogRef | null = null;
  private user: any;
  
  constructor(
    public dialogService: DialogService,
    private storageService: StorageService
  ) {}

  isLogged(): boolean {
    return !!this.user;
  }

  isStudent(): boolean {
    return this.isLogged() && !this.isLecturer();
  }

  isLecturer(): boolean {
    return this.user?.role === 'Lecturer';
  }

  logout() {
    this.storageService.signOut();
  }

  login() {
    this.ref = this.dialogService.open(LoginComponent, {
      header: 'Log in'
    });
    this.ref.onClose.subscribe(user => {
      this.user = user;
    })
  }

}
