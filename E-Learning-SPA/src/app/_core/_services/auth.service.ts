import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { User } from '../_models/user';
import { kStringMaxLength } from 'buffer';
import { promise } from 'protractor';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl;
  currentUser: User;
  jwtHelper = new JwtHelperService();
  decodeToken: any;

  constructor(private http: HttpClient, private router: Router) { }

  login(model: any) {
    return this.http.post(this.baseUrl + 'Auth/login', model)
      .pipe(
        map((response: any) => {
          const user = response;
          if (user) {
            localStorage.setItem('token', user.token);
            localStorage.setItem('user', JSON.stringify(user.user));
            this.decodeToken = this.jwtHelper.decodeToken(user.token);
          }
        })
      );
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

  administrator(account: string): any {
    return this.http.get(this.baseUrl + 'Auth/IsAdministrator/' + account);
  }

  checkLogin(account: string) {
    return this.http.get(this.baseUrl + 'checklogin/Get', { params: { account: account } }).toPromise()
      .then(
        (response: any) => {
          const user = response;
          if (user) {
            localStorage.setItem('token', user.token);
            localStorage.setItem('user', JSON.stringify(user.user));
            this.decodeToken = this.jwtHelper.decodeToken(user.token);
          }
        }
      );
  }
}
