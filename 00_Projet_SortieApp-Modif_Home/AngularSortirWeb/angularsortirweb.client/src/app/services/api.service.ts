import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environements/environement';

@Injectable({
  providedIn: 'root'
})

interface Participant {
  nom: string;
  prenom: string;
  mail: string;
  roleid: number;
}
export class ApiService {

  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  get(endpoint: string) {
    return this.http.get<Participant>(`${this.apiUrl}/${endpoint}`);
  }

  // Other API methods (post, put, delete, etc.)
}
