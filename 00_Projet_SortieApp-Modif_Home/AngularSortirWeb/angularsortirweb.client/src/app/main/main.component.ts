
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})

export class MainComponent implements OnInit {
    id!: number;
    login!: string;
    email!: string;
    firstName!: string;
    lastName!: string;
    password!: string;
    role!: 1;

  ngOnInit(): void {
    this.id = 1;
    this.login= "user";
    this.email= "fakeuser@mail.com";
    this.firstName= "User";
    this.lastName= "Fake";
    this.password= "user";
    this.role= 1;
  }

}
