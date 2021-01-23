import {Injectable} from '@angular/core';
import {HttpService} from '../../../core/services/http/http.service';
import {ApiMethod, EndPoints} from '../../../core/params';
import {HttpParams} from '@angular/common/http';
import {LoginRequest} from '../../../core/models/LoginRequest.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private http: HttpService
  ) { }

  login(loginRequest: LoginRequest): any{
    const body = new HttpParams()
      .set('client_id', loginRequest.client_id)
      .set('client_secret', loginRequest.client_secret)
      .set('grant_type', loginRequest.grant_type)
      .set('scope', loginRequest.scope);
    this.http.requestCallUrlencoded<any>(EndPoints.AUTHENTICATE, ApiMethod.POST, body).subscribe( res => {
      console.log(res);
    }, error => {},
      () => {});
  }
}
