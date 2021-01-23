import {Injectable} from '@angular/core';
import {HttpService} from '../../../core/services/http/http.service';
import {Mail} from '../../../core/models/Mail.model';
import {ApiMethod, EndPoints} from '../../../core/params';

@Injectable({
  providedIn: 'root'
})
export class MailService {

  constructor(
    private http: HttpService
  ) { }

  sendEmail(mail: Mail): any{
    this.http.requestCall<any>(EndPoints.SEND_MAIL, ApiMethod.POST, mail).subscribe( res => {
      console.log(res);
    }, error => {},
      () => {

    });
  }
}
