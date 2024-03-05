import {Component, EventEmitter, Input, OnInit, Output, TemplateRef} from '@angular/core';
import {Router} from "@angular/router";
import {BsModalRef, BsModalService} from "ngx-bootstrap/modal";
//import {Projects} from "../../interface/object.arrays";
//import {Project} from "../../interface/project";
import {TokenStorageService} from "../../services/token-storage.service";
import {DatabaseService} from "../../services/database.service";

@Component({
  selector: 'app-delete-popup',
  templateUrl: './delete-popup.component.html',
  styleUrls: ['./delete-popup.component.css']
})
export class DeletePopupComponent implements OnInit {
  modalRef?: BsModalRef;
  @Input()
  type!: string;
  @Input()
  id: number | null | undefined;
  @Output()
  eventEmitter = new EventEmitter<string>();


  name!: string;
  updating: boolean = false;
  public userRole = 0;

  constructor(private router: Router,
              private tokenStorageService: TokenStorageService,
              private modalService: BsModalService,
              //private projectService: ProjectService,
              private dbService: DatabaseService) { }

  ngOnInit(): void {
    this.userRole = this.tokenStorageService.getUserRole();
    switch (this.type) {
     /* case "projet":
        this.name = Projects.find(project => project.id === this.id)?.name || "";
        break;*/
    }
  }

  openModal(event: Event, template: TemplateRef<any>) {
    if (this.updating) return;
    if (this.tokenStorageService.getUserRole() < 2) {
      this.userRole = this.tokenStorageService.getUserRole();
      return;
    }
    event?.stopPropagation();
    this.modalRef = this.modalService.show(template);
  }

  closeModal() {
    this.modalRef?.hide();
  }

  /*archived(): boolean {
    switch (this.type) {
      /*case "projet":
        const project = this.getProject();
        return project === undefined ? false : project.archived;
    }
  }*/

  toggleArchive() {
    if (this.id !== undefined && this.id !== null && !this.updating) {
      let arrays!: Array<any>;
      switch (this.type) {
       /* case "projet":
          this.updating = true;
          arrays = [this.getBugsFrom(), this.getTestInstancesFrom(), this.getFeaturesFrom(), this.getGroupsFrom(),
            this.getThematicsFrom(), [this.getProject()]];
          this.toggleArchiveArrays(arrays);
          this.projectService.sort();
          this.eventEmitter.emit('sort!');
          this.closeModal();
          this.dbService.update([Bugs, TestInstances, Features, Groups, Thematics, Projects]).then(() => {
            this.updating = false;
          });
          break;*/
      }
    }
  }

  /*getProject(): Project | undefined {
    return Projects.find(v => v.id === this.id);
  }*/

  toggleArchiveArrays(arrays: [...Array<any>]) {
    for (const array of arrays) {
      for (const element of array) {
        if (element !== null && element !== undefined) {
          element.archived = !element.archived;
          element.lastUpdated = new Date();
        }
      }
    }
  }
  /*confirmationMessage(): string {
    let _type = "e";
    if (this.type == "thématique" || this.type === "fonction")
      _type = "a";
    if (this.archived())
      return `Désarchiver l${_type} ${this.type} ${this.name} ?`;
    else
      return `Archiver l${_type} ${this.type} ${this.name} ?`;
  }*/
}
