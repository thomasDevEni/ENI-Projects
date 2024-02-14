import { Component, OnInit } from '@angular/core';
import { ApiService } from '././services/api.service';

interface Participant {
  nom: string;
  prenom: string;
  mail: string;
  roleid: number;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public participants: Participant[] = [];

  constructor(private apiService: ApiService) {}

  ngOnInit() {
    this.getParticipants();
  }

  /*getParticipants() {
    this.apiService.get<Participant>('Participant/GetAll').subscribe((participants) => {
      console.log(participants);
      },
      (error) => {
        console.error(error);
      }
    );
  }*/

  getForecasts() {
    this.apiService.get<Participant[]>('Participant/All').subscribe(
      (result) => {
        this.participants = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }
  getParticipants() {
    this.apiService.get('Participant/GetAll').subscribe(
      (participants: Participant[]) => { // Specify type here
        console.log(participants);
        this.participants = participants; // Assuming result is an array of participants
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'angularsortirweb.client';
}
