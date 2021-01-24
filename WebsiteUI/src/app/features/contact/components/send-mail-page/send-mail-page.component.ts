import { Component, OnInit } from '@angular/core';
import {MailService} from '../../services/mail.service';
import {Mail} from '../../../../core/models/Mail.model';

@Component({
  selector: 'app-send-mail-page',
  templateUrl: './send-mail-page.component.html',
  styleUrls: ['./send-mail-page.component.scss']
})
export class SendMailPageComponent implements OnInit {

  constructor(
    private mailService: MailService
  ) { }

  ngOnInit(): void {
  }
  sendMail(): any{
    const mail: Mail = {
      EmailAddress: 'toniboumaroun@hotmail.com',
      Message: 'Its working',
      Name: 'Toni',
      Subject: 'Test'
    };
    this.mailService.sendEmail(mail);
  }
}

