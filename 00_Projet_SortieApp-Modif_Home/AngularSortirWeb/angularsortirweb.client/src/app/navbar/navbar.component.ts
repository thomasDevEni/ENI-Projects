import {Component, OnInit, TemplateRef} from '@angular/core';
import {TokenStorageService} from "../services/token-storage.service";
import {Roles, Users} from "../interface/object.arrays";
import {Role} from "../interface/role";
import {User} from "../interface/user";
import {BsModalRef, BsModalService} from "ngx-bootstrap/modal";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  title = 'suivitests';
  public user!: User;
  public role!: Role;
  modalRef?: BsModalRef;
  isLoggedIn = false;
  showAdminBoard = false;
  showModeratorBoard = false;
  username?: string;

  constructor(private tokenStorageService: TokenStorageService,
             private modalService: BsModalService) { }

  ngOnInit(): void {
    this.isLoggedIn = !!this.tokenStorageService.getToken();
    if (this.isLoggedIn){
      const _user = Users.find(user => user.id === this.tokenStorageService.getUser().id);
      if (_user){
        this.user = _user;
        this.role = _user.role || Roles[0];
      }
    }
  }

  logout(): void {
    this.tokenStorageService.signOut();
    window.location.reload();
  }

  openModal(template: TemplateRef<any>, event?: Event) {
    event?.stopPropagation();
   this.modalRef = this.modalService.show(template);
    this.modalRef.setClass("ms-auto me-0");
  }

  closeModal() {
    this.modalRef?.hide();
  }

}
