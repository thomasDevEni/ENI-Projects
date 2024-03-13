import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environements/environement';
const AUTH_API = environment.apiUrl + '/api/Authentification/';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) { }

  login(Username: string, Password: string): Observable<any> {
    return this.http.post(AUTH_API + 'signin', {
      Username,
      Password
    }, httpOptions);
  }

  register(Username: string, Password: string,LastName: string, FirstName: string, Mail: string): Observable<any> {
    return this.http.post(AUTH_API + 'signup', {
      Username,
      Password,
      LastName,
      FirstName,
      Mail
    }, httpOptions);
  }

  changePassword(Id: number, Password: string): Observable<any> {
    return this.http.post(AUTH_API + 'changepw', {
      Id,
      Password
    }, httpOptions);
  }

  changeRole(Id: number, RoleId: number): Observable<any> {
    return this.http.post(AUTH_API + 'changerole', {
      Id,
      RoleId
    }, httpOptions);
  }
}
