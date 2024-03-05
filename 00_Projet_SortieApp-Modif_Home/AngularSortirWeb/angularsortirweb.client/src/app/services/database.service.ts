import { Injectable } from '@angular/core';
import {UserService} from "./user.service";
import { RoleService } from "./role.service";
import { ParticipantService } from "./participant.service";

import {
  Roles,
  Users,
  Participants,
} from "../interface/object.arrays";
import {TokenStorageService} from "./token-storage.service";
import {User} from "../interface/user";
import { Role } from "../interface/role";
import { Participant } from "../interface/participant"

@Injectable({
  providedIn: 'root'
})
export class DatabaseService {

  constructor(private userService: UserService,
    private roleService: RoleService,
    private participantService: ParticipantService,
    private tokenService: TokenStorageService) { }

  async init(): Promise<any> {
    return new Promise(resolve => {
      this.roleService.initRoles()
        .then(() => this.userService.initUsers()
          .then(() => {
            // if only 1 user was found, set his role to Superadmin
            if (Users.length === 1) {
              const user = Users[0];
              user.role = Roles[3];
              const sub = this.userService.updateUser(user).subscribe({complete:() => {
                  sub.unsubscribe();
                }});
              this.tokenService.setUserRole(4);
            }
      
          })
      )
    });
  }
  async updateAll(): Promise<any> {
    return new Promise(resolve => {
      this.updateArray(Users)
        .then(() => this.updateArray(Roles)
          .then(() => resolve('done!'))
        );
    });
  }

  async update(arrays:[...Array<any>]) {
    const promises = new Array<any>();
    arrays.forEach((value) => {
      promises.push(this.updateArray(value));
    });
    return new Promise(resolve => {
      Promise.all(promises).then(() => {
        resolve('done!')
      })
    });
  }

  public async updateArray(array: Array<any>): Promise<any> {
    const promises = new Array<Promise<any>>();
    array.forEach(value => {
      switch (array) {
        case Users:
          promises.push(this.updateUser(value));
          break;
        case Roles:
          promises.push(this.updateRole(value));
          break;
        case Participants:
          promises.push(this.updateParticipant(value));
          break;
      }
    });
    return new Promise(resolve=> {
      Promise.all(promises).then(() => resolve(''));
    });
  }

  async updateUser(user: User){
    return new Promise(resolve => {
      Users[Users.findIndex(r => r.id === user.id)] = user;
      const sub = this.userService.updateUser(user).subscribe({complete:()=>{
        sub.unsubscribe();
          resolve('done');
      }});
    });
  }
  async updateRole(role: Role){
    return new Promise(resolve => {
      Roles[Roles.findIndex(r => r.id === role.id)] = role;
      const sub = this.roleService.updateRole(role).subscribe({complete:()=>{
        sub.unsubscribe();
        resolve('done');
      }});
    });
  }
  async updateParticipant(participant: Participant) {
    return new Promise(resolve => {
      Participants[Participants.findIndex(r => r.id === participant.id)] = participant;
      const sub = this.participantService.updateParticipant(participant).subscribe({
        complete: () => {
          sub.unsubscribe();
          resolve('done');
        }
      });
    });
  }
}
