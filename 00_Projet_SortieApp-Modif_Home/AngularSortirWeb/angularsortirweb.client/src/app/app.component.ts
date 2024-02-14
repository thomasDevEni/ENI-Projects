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

  getParticipants() {
    this.apiService.get<Participant[]>('Participant/GetAll').subscribe(
      (result) => {
        this.participants = result;      // Specify type here
        console.log(result);
        
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'angularsortirweb.client';
}
