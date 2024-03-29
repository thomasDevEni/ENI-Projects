import { Injectable } from '@angular/core';
const TOKEN_KEY = 'auth-token';
const USER_KEY = 'auth-user';
@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {
  constructor() {
    // empty constructor
  }

  signOut(): void {
    window.sessionStorage.clear();
  }

  public saveToken(token: string): void {
    window.sessionStorage.removeItem(TOKEN_KEY);
    window.sessionStorage.setItem(TOKEN_KEY, token);
  }

  public getToken(): string | null {
    return window.sessionStorage.getItem(TOKEN_KEY);
  }

  public saveUser(user: any): void {
    window.sessionStorage.removeItem(USER_KEY);
    window.sessionStorage.setItem(USER_KEY, JSON.stringify(user));
  }

  public getUser(): any {
    const user = window.sessionStorage.getItem(USER_KEY);
    if (user) {
      return JSON.parse(user);
    }
    return {};
  }

  public getUserRole(): number {
    const _user = this.getUser();
    if (this.getToken()) {
      if (_user) {
        if (_user.roles[0] === "Admin")
          return 1;
        else if (_user.roles[0] === "Utilisateur")
          return 2;
        else
          return 3;
      }
    }
    return 3;
  }

  public setUserRole(i: number) {
    const _user = this.getUser();
    if (this.getToken()) {
      if (_user){
        switch (i) {
          case 1:
            _user.roles = ["Admin"];
            break;
          case 2:
            _user.roles = ["Utilisateur"];
            break;
          case 3:
            _user.roles = ["Visiteur"];
            break;
        }
        this.saveUser(_user);
      }
    }
  }

}
