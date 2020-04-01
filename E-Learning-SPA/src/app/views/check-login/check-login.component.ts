import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../../_core/_services/auth.service';

@Component({
  selector: 'app-check-login',
  templateUrl: './check-login.component.html',
  styleUrls: ['./check-login.component.scss']
})
export class CheckLoginComponent implements OnInit {

  constructor(private authService: AuthService,
    private router: Router) {

  }

  async ngOnInit() {
    const returnUrl = this.router.url;
    if (returnUrl.includes('?Account=')) {
      await this.authService.checkLogin(returnUrl.substring(returnUrl.lastIndexOf('%5C') + 3)).catch(err => {
        window.location.href = 'http://10.1.0.18/LeaveIntegration/Public/AutoLoginHandler.ashx';
      });
    }
    if (this.authService.loggedIn()) {
      this.router.navigate(['/dashboard']);
    }
    else {
      window.location.href = 'http://eip.shc.ssbshoes.com/';
    }
  }

}
