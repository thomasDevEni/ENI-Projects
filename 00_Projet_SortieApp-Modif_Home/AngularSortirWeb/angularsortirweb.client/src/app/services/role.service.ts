import {Observable} from "rxjs";
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Role} from "../interface/role";
import { environment } from '../../environements/environement';
import {Roles} from "../interface/object.arrays";

@Injectable({
  providedIn: 'root'
})

export class RoleService {
  private apiServerUrl = environment.apiUrl + '/api';

  constructor(private  http: HttpClient) {}

  public async initRoles(): Promise<any> {
    return new Promise(((resolve, reject) => {
      this.getRoles().subscribe({next:roles=>{
          Roles.length = 0;
          for (const role of roles) {
            Roles.push(role);
          }
          resolve('done');}
        , error:e=> reject(e)}
      );
    }));
  }

  public getRoles(): Observable<Role[]> {
    return this.http.get<Role[]>(`${this.apiServerUrl}/Role/All`);
  }

  public getRole(id: number): Observable<Role> {
    return this.http.get<Role>(`${this.apiServerUrl}/Role/${id}`);
  }

  public addRole(role: Role): Observable<Role> {
    return this.http.post<Role>(`${this.apiServerUrl}/Role/AddRole`, role);
  }

  public updateRole(role: Role): Observable<Role> {
    return this.http.put<Role>(`${this.apiServerUrl}/Role/UpdateRole`, role);
  }

  public deleteRole(roleId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiServerUrl}/Role/${roleId}`);
  }

}
