  import {Observable} from "rxjs";
  import {Injectable} from "@angular/core";
  import {Participant} from "../interface/participant";
import { environment } from '../../environements/environement';
  import {HttpClient, HttpHeaders} from "@angular/common/http";
  import {Participants} from "../interface/object.arrays";

  const API_URL = environment.apiUrl + '/api/test/';

  @Injectable({
    providedIn: 'root'
  })

  export class ParticipantService {
    header!: HttpHeaders;
    private apiServerUrl = environment.apiUrl;

    constructor(private http: HttpClient) {
    }

    public async initParticipants(): Promise<any> {
      return new Promise(((resolve, reject) => {
        const sub = this.getParticipants().subscribe({next:participants=>{
            Participants.length = 0;
            for (const participant of participants) {
              Participants.push(participant);
            }
            resolve('done');}
          , error:e=> reject(e),
          complete:()=>{
            sub.unsubscribe();
          }}
        );
      }));
    }

    public getParticipants(): Observable<Participant[]> {
      return this.http.get<Participant[]>(`${this.apiServerUrl}/participant/all`);//, {headers:this.header});
    }

    public addParticipant(participant: Participant): Observable<Participant> {
      return this.http.post<Participant>(`${this.apiServerUrl}/participant/add`, participant);//, {headers:this.header});
    }

    public updateParticipant(participant: Participant): Observable<Participant> {
      return this.http.put<Participant>(`${this.apiServerUrl}/participant/update`, participant);//, {headers:this.header});
    }

    public deleteParticipant(participantId: number): Observable<void> {
      return this.http.delete<void>(`${this.apiServerUrl}/participant/${participantId}`);//, {headers:this.header});
    }

    getPublicContent(): Observable<any> {
      return this.http.get(API_URL + 'all', { responseType: 'text' });
    }
    getParticipantBoard(): Observable<any> {
      return this.http.get(API_URL + 'participant', { responseType: 'text' });
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
