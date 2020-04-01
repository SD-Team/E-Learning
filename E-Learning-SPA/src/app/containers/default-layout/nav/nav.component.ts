import { Component, OnInit, OnChanges } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../../../_core/_services/auth.service';
import { User } from '../../../_core/_models/user';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit, OnChanges {
  administrator: boolean = false;
  user: User = JSON.parse(localStorage.getItem('user'));

  constructor(public authService: AuthService, private router: Router) {
    debugger
    this.authService.administrator(this.user.account).subscribe(res => {
      debugger
      this.administrator = res;
    });
   }

  ngOnChanges() {}

  ngOnInit() {}

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('user');

    window.location.href = 'http://eip.shc.ssbshoes.com/';
  }
}
