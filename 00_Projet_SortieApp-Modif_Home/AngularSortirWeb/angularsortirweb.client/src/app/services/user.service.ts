  import {Observable} from "rxjs";
  import {Injectable} from "@angular/core";
  import {Utilisateur} from "../interface/utilisateur";
import { environment } from '../../environements/environement';
  import {HttpClient, HttpHeaders} from "@angular/common/http";
  import {Users} from "../interface/object.arrays";

  const API_URL = environment.apiUrl + '/api/test/';

  @Injectable({
    providedIn: 'root'
  })

  export class UserService {
    header!: HttpHeaders;
    private apiServerUrl = environment.apiUrl + '/api';

    constructor(private http: HttpClient) {
    }

    public async initUsers(): Promise<any> {
      return new Promise(((resolve, reject) => {
        const sub = this.getUsers().subscribe({next:users=>{
            Users.length = 0;
            for (const user of users) {
              Users.push(user);
            }
            resolve('done');}
          , error:e=> reject(e),
          complete:()=>{
            sub.unsubscribe();
          }}
        );
      }));
    }

    public getUsers(): Observable<Utilisateur[]> {
      return this.http.get<Utilisateur[]>(`${this.apiServerUrl}/Utilisateur/All`);//, {headers:this.header});
    }

   /* public addUser(user: Utilisateur): Observable<Utilisateur> {
      return this.http.post<Utilisateur>(`${this.apiServerUrl}/Utilisateur/add`, user);//, {headers:this.header});
    }*/

    public updateUser(user: Utilisateur): Observable<Utilisateur> {
      return this.http.put<Utilisateur>(`${this.apiServerUrl}/Utilisateur/Update`, user);//, {headers:this.header});
    }

    public deleteUser(userId: number): Observable<void> {
      return this.http.delete<void>(`${this.apiServerUrl}/Utilisateur/${userId}`);//, {headers:this.header});
    }

    getPublicContent(): Observable<any> {
      return this.http.get(API_URL + 'all', { responseType: 'text' });
    }
    getUserBoard(): Observable<any> {
      return this.http.get(API_URL + 'user', { responseType: 'text' });
    }
    getModeratorBoard(): Observable<any> {
      return this.http.get(API_URL + 'mod', { responseType: 'text' });
    }
    getDevBoard(): Observable<any> {
      return this.http.get(API_URL + 'dev', { responseType: 'text' });
    }
    getAdminBoard(): Observable<any> {
      return this.http.get(API_URL + 'admin', { responseType: 'text' });
    }
  }
