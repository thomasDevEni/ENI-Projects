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
    lastname: null,
    firstname: null,
    username: null,
    email: null,
    password: null
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
    const { lastname,firstname,username, email, password } = this.form;
    this.authService.register(lastname,firstname,username, email, password).subscribe({
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
