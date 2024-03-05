import { NgModule } from '@angular/core';
import { ListComponent } from "./mainFrame/list/list.component";
import { RegisterComponent } from './user/register/register.component';
import { LoginComponent } from "./user/login/login.component";
import { RouterModule, Routes } from '@angular/router';
import { AuthInterceptor } from "./user/_helpers/auth.interceptor";
import { UserParamsComponent } from "./mainFrame/user-params/user-params.component";
import { AdminParamsComponent } from "./mainFrame/admin-params/admin-params.component";

const routes: Routes = [
  { path: "", redirectTo: "login", pathMatch: "full" },
  { path: "login", component: LoginComponent }, // login
  { path: "register", component: RegisterComponent }, // register
  { path: "dashboard", component: ListComponent, canActivate: [AuthInterceptor] }, // projects dashboard
  { path: "userParams", component: UserParamsComponent, canActivate: [AuthInterceptor] }, // user parameters
  { path: "adminParams", component: AdminParamsComponent, canActivate: [AuthInterceptor] }, // admin parameters
  { path: "**", redirectTo: "dashboard" },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { scrollPositionRestoration: 'enabled' })],
  exports: [RouterModule],
  providers: [AuthInterceptor]
})
export class AppRoutingModule { }
