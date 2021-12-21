import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { StorageService } from 'src/app/services/storage.service';
import jwt_decode from "jwt-decode";
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  login = '';
  password = '';
  error = '';

    constructor(
      private authService: AuthService,
      private storageService: StorageService,
      public ref: DynamicDialogRef,
      public config: DynamicDialogConfig
    ) { }

    ngOnInit() { }

    onSubmit() {
      if (this.password && this.login) {
        this.authService.login(this.login, this.password)
          .subscribe(
            (data: any) => {
              this.storageService.saveToken(data);
              const user = jwt_decode(data);
              this.storageService.saveUser(user);
              this.ref.close(user);
            },
            (error: string) => {
              this.error = error + ' Try again.';
            });
      } else {
        this.error = 'Fill all inputs.'
      }
    }
}
