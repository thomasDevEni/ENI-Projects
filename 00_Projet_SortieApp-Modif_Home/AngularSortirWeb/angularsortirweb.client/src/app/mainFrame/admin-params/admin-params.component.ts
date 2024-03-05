import { Component, OnInit } from '@angular/core';
import {UserService} from "../../services/user.service";
import {User} from "../../interface/user";
import {Roles, Users} from "../../interface/object.arrays";
import {Subscription} from "rxjs";
import {AuthService} from "../../services/auth.service";
import {TokenStorageService} from "../../services/token-storage.service";

@Component({
  selector: 'app-admin-params',
  templateUrl: './admin-params.component.html',
  styleUrls: ['./admin-params.component.css']
})
export class AdminParamsComponent implements OnInit {
  currentUser!: User;
  users !: Array<User>;
  sub !: Subscription;
  selectedRole!: number;

  constructor(private authService: AuthService,
              private userService: UserService,
              private tokenService: TokenStorageService) {
    this.currentUser = Users.find(u => u.id === this.tokenService.getUser().id)!;
  }

  ngOnInit(): void {
    this.users = Users;
  }



  setRole(user: User, i: number) {
    if (Roles[i-1] && user) {
      user.role = Roles[i-1];
      const sub = this.authService.changeRole(<number>user.id, i).subscribe(() => {
          this.updateUser(user).then(() => {
            Users[Users.findIndex(u => u.id === user.id)] = user;
            sub.unsubscribe();
          });
        }
      );
    }
  }

  getRoleName(i: number) {
    return ["Utilisateur", "Développeur", "Administrateur", "Super Administrateur"][i-1];
  }

  onSelectChange(event: any) {
    this.selectedRole = Number(event.target.value);
  }

  async updateUser(user: User): Promise<any> {
    return new Promise(resolve => {
      const sub = this.userService.updateUser(user).subscribe({
        complete:() => {
          resolve('done!');
          Users[Users.findIndex(u => u.id === user.id)] = user;
          sub.unsubscribe();
        }
      });
    });
  }

}
