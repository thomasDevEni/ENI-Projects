import { Component, OnInit } from '@angular/core';
import {TokenStorageService} from "../../services/token-storage.service";
import {Utilisateur} from "../../interface/utilisateur";
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
  user!: Utilisateur;
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
    this.lastname = new FormControl(this.user.LastName, [Validators.minLength(3), Validators.required]);
    this.firstname = new FormControl(this.user.FirstName, [Validators.minLength(3), Validators.required]);
    this.email = new FormControl(this.user.Mail, [Validators.email, Validators.required]);
    this.password = new FormControl("", [Validators.minLength(6), Validators.required]);
  }

  findUser(): Utilisateur{
    return <Utilisateur>Users.find(user => user.Id === this.tokenService.getUser().Id);
  }

  updateLastname() {
    if (this.lastname.valid) {
      this.user.LastName = this.lastname.value;
      this.updateUser();
    }
  }

  updateFirstname() {
    if (this.firstname.valid) {
      this.user.FirstName = this.firstname.value;
      this.updateUser();
    }
  }

  updateEmail() {
    if (this.email.valid && !this.mailInUse()) {
      this.user.Mail = this.email.value;
      this.updateUser();
    }
  }

  updatePassword() {
    if (this.password.valid) {
      this.user.Password = this.password.value;
      const sub = this.authService.changePassword(<number>this.user.Id, this.password.value).subscribe({
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
    return Users.filter(user => user.Id != this.user.Id && user.Mail === this.email.value).length > 0;
  }
}
