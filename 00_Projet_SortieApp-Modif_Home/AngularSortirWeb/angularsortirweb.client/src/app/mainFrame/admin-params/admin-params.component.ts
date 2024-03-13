import { Component, OnInit } from '@angular/core';
import {UserService} from "../../services/user.service";
import {Utilisateur} from "../../interface/utilisateur";
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
  currentUser!: Utilisateur;
  users !: Array<Utilisateur>;
  sub !: Subscription;
  selectedRole!: number;

  constructor(private authService: AuthService,
              private userService: UserService,
              private tokenService: TokenStorageService) {
    this.currentUser = Users.find(u => u.Id === this.tokenService.getUser().id)!;
  }

  ngOnInit(): void {
    this.users = Users;
  }



  setRole(user: Utilisateur, i: number) {
    if (Roles[i-1] && user) {
      user.Role = Roles[i-1];
      const sub = this.authService.changeRole(<number>user.Id, i).subscribe(() => {
          this.updateUser(user).then(() => {
            Users[Users.findIndex(u => u.Id === user.Id)] = user;
            sub.unsubscribe();
          });
        }
      );
    }
  }

  getRoleName(i: number) {
    return ["Administrateur", "Utilisateur", "Visiteur"][i-1];
  }

  onSelectChange(event: any) {
    this.selectedRole = Number(event.target.value);
  }

  async updateUser(user: Utilisateur): Promise<any> {
    return new Promise(resolve => {
      const sub = this.userService.updateUser(user).subscribe({
        complete:() => {
          resolve('done!');
          Users[Users.findIndex(u => u.Id === user.Id)] = user;
          sub.unsubscribe();
        }
      });
    });
  }

}
