/***MODULES***/
import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { PopoverModule } from "ngx-bootstrap/popover";

/***COMPONENTS***/
import { HomeComponent } from './home/home.component';
import { AppComponent } from './app.component';
import { ListComponent } from './mainFrame/list/list.component';
import { LoginComponent } from './user/login/login.component';
import { NavbarComponent } from './navbar/navbar.component';
import { PathComponent } from './mainFrame/path/path.component';
import { RegisterComponent } from './user/register/register.component';
import { ProfileComponent } from './user/profile/profile.component';
import { UserPopupComponent } from './popups/user-popup/user-popup.component';
import { UserParamsComponent } from './mainFrame/user-params/user-params.component';
import { AdminParamsComponent } from './mainFrame/admin-params/admin-params.component';

/***SERVICES***/
import { RoleService } from "./services/role.service";
import { UserService } from "./services/user.service";
import { ParticipantService } from "./services/participant.service"
import { BsModalService } from "ngx-bootstrap/modal";
import { authInterceptorProviders } from './user/_helpers/auth.interceptor';
import { ApiService } from './services/api.service'; // Import ApiService

@NgModule({
  declarations: [
    AppComponent,
    //DeletePopupComponent,
    HomeComponent,
    ListComponent,
    LoginComponent,
    NavbarComponent,
    PathComponent,
    ProfileComponent,
    RegisterComponent,
    ProfileComponent,
    HomeComponent,
   // DeletePopupComponent,
    //NewPopupComponent,
    UserPopupComponent,
    UserParamsComponent,
    AdminParamsComponent,
    ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    PopoverModule,
  ],
  providers: [
    ApiService,
    RoleService,
    UserService,
    ParticipantService,
    authInterceptorProviders,
    BsModalService,
  ], // Add ApiService to providers array
  bootstrap: [AppComponent]
})
export class AppModule { }
