import { Component, OnInit, DoCheck, AfterViewInit, AfterContentInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../../_core/_services/auth.service';
import { AlertifyService } from '../../_core/_services/alertify.service';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-dashboard',
  templateUrl: 'login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, AfterViewInit {
  model: any = {};

  constructor(private authService: AuthService,
    private router: Router,
    private alertify: AlertifyService,
    private spinner: NgxSpinnerService) {
    }

  ngOnInit() {
    if (this.authService.loggedIn()) {
      this.router.navigate(['/dashboard']);
    }
  }

  ngAfterViewInit() {
    this.spinner.hide();
  }

  login() {
    this.spinner.show();
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('Login success!');
      this.spinner.hide();
    }, error => {
      this.alertify.error('Login fail!');
      this.spinner.hide();
    }, () => {
      this.router.navigate(['/dashboard']);
      this.spinner.hide();
    });
  }
}
