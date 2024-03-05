import { HTTP_INTERCEPTORS, HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TokenStorageService } from '../../services/token-storage.service';
import { Observable } from 'rxjs';
import {CanActivate, Router, UrlTree} from "@angular/router";
const TOKEN_HEADER_KEY = 'Authorization';       // for .NET 8.0 back-end
@Injectable()
export class AuthInterceptor implements HttpInterceptor, CanActivate {
  constructor(private token: TokenStorageService,
              private router: Router) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let authReq = req;
    const token = this.token.getToken();
    if (token != null) {
      authReq = req.clone({ headers: req.headers.set(TOKEN_HEADER_KEY, 'Bearer ' + token) });
    }
    return next.handle(authReq);
  }

  canActivate() : Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    if (this.token.getToken()){
      return true;
    }
    this.router.navigate(["/login"]).then();
    return false;
  }
}
export const authInterceptorProviders = [
  { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
];
