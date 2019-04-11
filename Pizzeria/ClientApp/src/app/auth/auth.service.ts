import {Injectable, Inject} from '@angular/core';
import {Router} from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { AppConfig, APP_CONFIG } from '../app-config.module';
import { RegisterUser } from './registerUser.model';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  token: string;
  invalidLogin: boolean;
  constructor(private route: Router,
              private httpClient: HttpClient,
              private jwtHelper: JwtHelperService,
              @Inject(APP_CONFIG) private config: AppConfig) {
        this.token = localStorage.getItem(config.jwtKey);
        console.log("initial jwt ", this.token);
  }

  signupUser(userData: RegisterUser) {
    console.log('registering ', userData);
    const url = `${this.config.apiEndpoint}/auth/register`;
    this.httpClient.post(url, userData)
      .subscribe((response) => {
          console.log(response);
      },(error) => console.log(error));
  }

  signinUser(email: string, password: string){
    const url = `${this.config.apiEndpoint}/auth/login`;
    this.httpClient.post(url, {email, password})
        .subscribe((response: {token: string}) => {
            this.token = response.token;
            localStorage.setItem(this.config.jwtKey, this.token);
            this.invalidLogin = false;
            this.route.navigate(['/']);
          },(error) => {
              this.invalidLogin = true;
              console.log("error on signin ", error);
        });
  }

  getToken(): string {
    const token = localStorage.getItem(this.config.jwtKey);
    return token;
  }

  isTokenExpired(token: string): boolean {
      if (!token) {
        return false;
      }
      return this.jwtHelper.isTokenExpired(token);
  }

  isAuthenticated(): boolean {
  // expired token for test
    // this.token = `eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJFbWFpbCI6ImpvaG5AZG9lLmNvbSIsIkZpcnN0TmFtZSI6IkpvaG4iLCJSb2xlIjoiQ3VzdG9tZXIiLCJleHAiOjE1NTM2MjAxMDcsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTU4NDYiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjU1ODQ2In0.tStuxkBUnt_V5vSBW4r06rkO5wrOi8ReojsAYPo6E6M`;
    if (!this.token) {
      return false;
    } else if (this.isTokenExpired(this.token)) {
      return false;
    } else {
      return true;
    }
  }

  private removeToken() {
    localStorage.removeItem(this.config.jwtKey);
    this.token = null;
  }

  logout() {
    this.removeToken();
    this.route.navigate(['/']);
  }

  redirectToLogin() {
    this.removeToken();
    this.route.navigate(['/signin']);
  }
}
