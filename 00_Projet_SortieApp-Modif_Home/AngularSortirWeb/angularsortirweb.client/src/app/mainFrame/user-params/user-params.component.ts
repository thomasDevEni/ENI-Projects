import { Component, OnInit } from '@angular/core';
import {TokenStorageService} from "../../services/token-storage.service";
import {User} from "../../interface/user";
import {Users} from "../../interface/object.arrays";
import {UserService} from "../../services/user.service";
import {AuthService} from "../../services/auth.service";
import {Router} from "@angular/router";
import {FormControl, Validators} from "@angular/forms";

@Component({
  selector: 'app-user-params',
  templateUrl: './user-params.component.html',
  styleUrls: ['./user-params.component.css']
})
export class UserParamsComponent implements OnInit {
  user!: User;
  lastname!: FormControl;
  firstname!: FormControl;
  email!: FormControl;
  password!: FormControl;

  constructor(private tokenService: TokenStorageService,
              private userService: UserService,
              private authService: AuthService,
              private router: Router) {
  }

  ngOnInit(): void {
    this.user = this.findUser();
    this.lastname = new FormControl(this.user.lastname, [Validators.minLength(3), Validators.required]);
    this.firstname = new FormControl(this.user.firstname, [Validators.minLength(3), Validators.required]);
    this.email = new FormControl(this.user.email, [Validators.email, Validators.required]);
    this.password = new FormControl("", [Validators.minLength(6), Validators.required]);
  }

  findUser(): User{
    return <User>Users.find(user => user.id === this.tokenService.getUser().id);
  }

  updateLastname() {
    if (this.lastname.valid) {
      this.user.lastname = this.lastname.value;
      this.updateUser();
    }
  }

  updateFirstname() {
    if (this.firstname.valid) {
      this.user.firstname = this.firstname.value;
      this.updateUser();
    }
  }

  updateEmail() {
    if (this.email.valid && !this.mailInUse()) {
      this.user.email = this.email.value;
      this.updateUser();
    }
  }

  updatePassword() {
    if (this.password.valid) {
      this.user.password = this.password.value;
      const sub = this.authService.changePassword(<number>this.user.id, this.password.value).subscribe({
        complete: () => {
          this.tokenService.signOut();
          this.router.navigateByUrl("/").then();
          sub.unsubscribe();
        }
      });
    }
  }

  updateUser(): void {
    const sub = this.userService.updateUser(this.user).subscribe({complete:() => { sub.unsubscribe(); }});
  }

  mailInUse():boolean {
    return Users.filter(user => user.id != this.user.id && user.email === this.email.value).length > 0;
  }
}
