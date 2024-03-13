import { Router } from "@angular/router";
import { Component, OnInit } from '@angular/core';
import { ApiService } from '././services/api.service';
import { TokenStorageService } from './services/token-storage.service';
import { DatabaseService } from "./services/database.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  /*public participants: Participant[] = [];
  public roles: Role[] = [];*/

  title = 'angularsortirweb.client';
  role!: number;
  isLoggedIn = false;
  showAdminBoard = false;
  showModeratorBoard = false;
  username?: string;
  initiated = false;

  constructor(public router: Router,
    private tokenStorageService: TokenStorageService,
    private dbService: DatabaseService,
    private apiService: ApiService) { }

  ngOnInit() {
   // this.getParticipants();
    this.updateInit();
  }

  /*getParticipants() {
    this.apiService.get<Participant[]>('Participant/GetAll').subscribe(
      (result) => {
        this.participants = result;      // Specify type here
        console.log(result);
        
      },
      (error) => {
        console.error(error);
      }
    );
  }*/

  updateInit() {
    this.isLoggedIn = !!this.tokenStorageService.getToken();
    if (this.isLoggedIn) {
      this.dbService.init().then(() => {
        this.initiated = true;
        const user = this.tokenStorageService.getUser();
        this.role = this.tokenStorageService.getUserRole();
        this.username = user.username;
      });
    }
  }

  logout(): void {
    this.tokenStorageService.signOut();
    window.location.reload();
  }

  showPath(): boolean {
    // show app-path component only if url is not in this list
    let bool = true;
    // exact url list
    const exactList = ["/lieux", "/dashboard", "/adminParams"];
    if (exactList.includes(this.router.url))
      bool = false;
    // part of url list
    const list = ["/userParams", "/projectSettings"];
    for (const url of list) {
      if (this.router.url.includes(url))
        bool = false;
    }
    return bool;
  }
  
}
