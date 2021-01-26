import { Component, OnInit } from '@angular/core';
import {AuthService} from '../../services/auth.service';
import {LoginRequest} from '../../,models/LoginRequest.model';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  constructor(
    private authService: AuthService
  ) { }

  ngOnInit(): void {
  }

  login(): void{
    const request: LoginRequest = {
      client_id: 'charbel199',
      client_secret: 'secret',
      grant_type: 'client_credentials',
      scope: 'read write'
    };
    this.authService.login(
      request
    );
  }

}
