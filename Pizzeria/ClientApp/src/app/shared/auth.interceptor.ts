import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Injectable} from '@angular/core';
import {AuthService} from '../auth/auth.service';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService,
              private jwtHelper: JwtHelperService,
              private router: Router) {
  }

  whitelist: string[] = ['/recipes'];

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = this.authService.getToken();
    if (this.jwtHelper.isTokenExpired(token)) {
      const currentUrl: string = this.router.url;
      const isPublic: boolean = this.whitelist.some(w => currentUrl.indexOf(w) === 0);
      if(!isPublic) {
        this.authService.redirectToLogin();
      }
    }
    request = request.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
    return next.handle(request);

  }
}
