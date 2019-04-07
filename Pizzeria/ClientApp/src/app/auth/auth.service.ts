import {Injectable, Inject} from '@angular/core';
import {Router} from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { AppConfig, APP_CONFIG } from '../app-config.module';
import { invalid } from '@angular/compiler/src/render3/view/util';
import { Observable } from 'rxjs';
import { RegisterUser } from './registerUser.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  token: string;
  invalidLogin: boolean;
  constructor(private route: Router,
              private httpClient: HttpClient,
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
            localStorage.setItem(this.config.jwtKey, this.token)
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

  isAuthenticated(): boolean {
    return this.token != null;
  }

  logout() {
    localStorage.removeItem(this.config.jwtKey);
    this.token = null;
    this.route.navigate(['/']);
  }
}
