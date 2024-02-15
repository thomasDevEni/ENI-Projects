import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environements/environement';

interface Participant {
  nom: string;
  prenom: string;
  mail: string;
  roleid: number;
}

@Injectable({
  providedIn: 'root',
})

export class ApiService {

  apiUrl = environment.apiUrl;
  public participants: Participant[] = [];

  constructor(private http: HttpClient) { }

  get<participants>(endpoint: string) {
    return this.http.get<participants>(`${this.apiUrl}/${endpoint}`);
  }

  // Other API methods (post, put, delete, etc.)
}
