import {NgModule} from '@angular/core';
import {SignupComponent} from './signup/signup.component';
import {SigninComponent} from './signin/signin.component';
import {FormsModule} from '@angular/forms';
import {AuthRoutesModule} from './auth-routes.module';
import { CommonModule } from '@angular/common';
import { JwtModule } from '@auth0/angular-jwt';

export function tokenGetter() {
  return localStorage.getItem('access_token');
}

@NgModule({
  declarations: [
    SignupComponent,
    SigninComponent
  ],
  imports: [
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter
      }
    }),
    FormsModule,
    AuthRoutesModule,
    CommonModule
  ]
})
export class AuthModule {

}
