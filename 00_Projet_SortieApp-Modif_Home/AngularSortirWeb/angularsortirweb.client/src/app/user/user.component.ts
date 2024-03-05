/*
import { Component, OnInit } from '@angular/core';
import {UserService} from "../service/user.service";
import {RoleService} from "../service/role.service";
import {Users} from "./users";
import {User} from "./user";

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  private users!: Array<User>;
  content?: string;

  constructor(private userService: UserService,
              private roleService: RoleService) { }

  ngOnInit(): void {
    if (this.users.length === 0) {
      this.userService.getUsers().subscribe(value => {
        // Récupération de la base de donnée...
        if (value instanceof User) {
          this.users.push(value);
        }
        // ... Ou création de celle-ci
        if (this.users.length === 0) {
          this.users = [...Users];
          for (const user of this.users) {
            this.userService.addUser(user);
          }
        }
        console.log(this.users);
      })
    }

         this.userService.getAdminBoard().subscribe(
        data => {
          this.content = data;
        },
        err => {
          this.content = JSON.parse(err.error).message;
        }
      );
  }

}
*/
