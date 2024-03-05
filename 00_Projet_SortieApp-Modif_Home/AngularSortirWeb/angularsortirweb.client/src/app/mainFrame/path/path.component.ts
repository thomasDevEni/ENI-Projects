import {Component} from '@angular/core';
import { NavigationEnd, Router} from "@angular/router";


@Component({
  selector: 'app-path',
  templateUrl: './path.component.html',
  styleUrls: ['./path.component.css']
})
export class PathComponent {
  /**
   * @private
   * <code>routeArray</code> stores every part of the url, split with "/"<br>
   * "projects/projectId/thematicId/..." would become ["projects", "projectId", "thematicId", ...], for example<br>
   * This can be used to check where the user is right now, and that's how we know what to show.
   *
   */
  private _routeArray = new Array<string>();
  /**
   * <code>currentRoute</code> is a simple string that stores the current path.
   */
  private _currentRoute!: string;

  constructor(private router : Router) {
    // Subscription that calls this.updateRouter whenever a page change occurs
    router.events.subscribe({
      next: event => {
        if (event instanceof NavigationEnd) {
          this.updateRouter(event.urlAfterRedirects);
        }
      }
    });
    this.updateRouter(router.url);
  }

  // Updates this.routeArray and this.currentRoute
 updateRouter(urlAfterRedirects: string): void {
    this.routeArray.length = 0;
    this.routeArray = urlAfterRedirects.split('/');
    if (this.routeArray[0] === "projects") {
      this.routeArray.shift();
      if (this.routeArray.length > 1) {
        // get project with id == this.routeArray[1], so "projects/>>THIS_ID<</..."
        /*const project = this.findProject(Number(this.routeArray[0]));
        if (project !== undefined) {
          this.routeArray[0] = project.id?.toString() || "";
        }*/
      }
    }
    this.currentRoute = urlAfterRedirects;
  }
    findProject(arg0: number) {
        throw new Error('Method not implemented.');
    }

  get routeArray(): Array<string> {
    return this._routeArray;
  }

  get currentRoute(): any {
    return this._currentRoute;
  }

  set currentRoute(value: any) {
    this._currentRoute = value;
  }

  set routeArray(value: Array<string>) {
    value.forEach((v, i) => {
      if (v.length === 0) {
        value.splice(i, 1);
      }
    });
    this._routeArray = value;
  }

  getRouterLink(i: number, path: string): string {
    switch (i) {
      default: return path.toLowerCase();
    }
  }

  pathName(i: number, path: string): string {
    switch (path.toLowerCase()){
      case "dashboard": return "Tableau de bord";
      default:
        if (path.includes("bugs?")){
          return "Bugs";
        } else if (path.includes("features?")){
          return "Fonctionnalités périmées";
        }
        if (path.includes("?"))
          path = path.split("?")[0];
        switch (i) {
          default: return path;
        }
    }
  }
}
