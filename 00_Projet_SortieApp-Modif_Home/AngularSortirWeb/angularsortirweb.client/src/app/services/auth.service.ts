import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environements/environement';
const AUTH_API = environment.apiUrl + '/api/auth/';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<any> {
    return this.http.post(AUTH_API + 'signin', {
      username,
      password
    }, httpOptions);
  }

  register(lastname: string, firstname: string,username: string, email: string, password: string): Observable<any> {
    return this.http.post(AUTH_API + 'signup', {
      lastname,
      firstname,
      username,
      email,
      password
    }, httpOptions);
  }

  changePassword(id: number, password: string): Observable<any> {
    return this.http.post(AUTH_API + 'changepw', {
      id,
      password
    }, httpOptions);
  }

  changeRole(id: number, roleId: number): Observable<any> {
    return this.http.post(AUTH_API + 'changerole', {
      id,
      roleId
    }, httpOptions);
  }
}
