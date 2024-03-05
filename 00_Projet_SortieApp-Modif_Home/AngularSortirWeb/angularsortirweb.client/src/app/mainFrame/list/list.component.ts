import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, ParamMap, Router, UrlSegment} from "@angular/router";
import { TokenStorageService } from '../../services/token-storage.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  private _currentArray!: Array<any>;
  public currentType!: string;
  public userRole!: number;

  constructor(public route: ActivatedRoute,
              private token: TokenStorageService,
              private router: Router) {}

  ngOnInit(): void {
    this.checkParamMap();
    this.userRole = this.token.getUserRole();
    this.init();
  }

  checkParamMap(){
    this.checkAllParams();
  }

  checkAllParams(){
    const paramMap = this.route.snapshot.paramMap;
  }

  checkIdParam(paramMap: ParamMap, idString: string, array: Array<any>){
    if (paramMap.has(idString)){
      const paramId = paramMap.get(idString);
      if (this.invalidId(paramId) || array.filter(v => v.id === Number(paramId)).length === 0)
        this.goTo404();
    }
  }

  invalidId(param: string | null): boolean{
    return (param === null || isNaN(Number(param)));
  }
  goTo404(){
    this.router.navigate(['**']).then();
  }

  init() {
  
    const currentUrl = this.route.snapshot.url;
    this.getCurrentType(currentUrl);
    switch (this.currentType) {
      case "dashboard":
        this.updatePage(true);
        break;
    }
  }
    updatePage(arg0: boolean) {
        throw new Error('Method not implemented.');
    }

  getCurrentType(currentUrl: Array<UrlSegment>) {
    const titleLowerCase = currentUrl[0].toString().toLowerCase();
    switch (titleLowerCase) {
      case "dashboard": this.setCurrentType("dashboard"); return;
      default: return;
    }
  }

  getCurrentTypeFromUrl(currentUrl: Array<UrlSegment>){
    switch(currentUrl.length) {
      case 1: this.setCurrentType("projects"); return;
    }
  }


  setCurrentType(type: string) {
    this.currentType = type;
  }

 

  sort(_array: Array<any>){
    // sort by date
    _array.sort(
      (a, b) => Date.parse(b.lastUpdated.toString()) - Date.parse(a.lastUpdated.toString()));
    // sort by archived
    _array.sort((a,b) => {
      if (a.archived === b.archived)
        return 0;
      return a.archived ? 1 : -1;
    });
  }

  get currentArray(): Array<any> {
    this.sort(this._currentArray);
    return this._currentArray;
  }

  set currentArray(value: Array<any>) {
    this._currentArray = value;
  }


  toNumber(str: string): number{
    return Number(str);
  }
}
