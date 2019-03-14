import {Injectable, Inject} from '@angular/core';
import {Router} from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { AppConfig, APP_CONFIG } from '../app-config.module';
import { invalid } from '@angular/compiler/src/render3/view/util';
import { Observable } from 'rxjs';

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

  signupUser(email: string, password: string) {
    console.log('registering ', email, password);
    const url = `${this.config.apiEndpoint}/api/auth/login`;
    this.httpClient.post(url, {email, password})
      .subscribe((response) => {
          console.log(response);
      },(error) => console.log(error));
  }

  signinUser(email: string, password: string){
    const url = `${this.config.apiEndpoint}/api/auth/login`;
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
    return null;
    // const currentUser = firebase.auth().currentUser;
    // if(currentUser){
    //   currentUser.getIdToken()
    //     .then(token => this.token = token)
    //     .catch(error => console.log(error));
      
    //   return this.token;
    // }
    // return null;
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
