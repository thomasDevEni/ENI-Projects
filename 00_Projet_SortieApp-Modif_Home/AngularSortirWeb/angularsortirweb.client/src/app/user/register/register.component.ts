import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import {TokenStorageService} from "../../services/token-storage.service";
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  form: any = {
    Username: null,
    Password: null,
    LastName: null,
    FirstName: null,    
    Mail: null,
    
  };
  isSuccessful = false;
  isSignUpFailed = false;
  errorMessage = '';
  constructor(private authService: AuthService,
              private router: Router,
              private tokenStorage: TokenStorageService) { }

  ngOnInit(): void {
    if (this.tokenStorage.getToken()) {
      this.router.navigate(["dashboard"]).then();
    }
  }

  onSubmit(): void {
    const { username, password, lastname, firstname, email } = this.form;
    this.authService.register(username, password, lastname, firstname, email).subscribe({
      next: () => {
        this.isSuccessful = true;
        this.isSignUpFailed = false;
        setTimeout(() => {
          this.router.navigate(['/login']).then();
        }, 3000);  //5s
      },error:err => {
      this.errorMessage = err.error.message;
      this.isSignUpFailed = true;
    }
  }
    );
  }
}
