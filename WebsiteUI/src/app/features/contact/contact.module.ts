import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SendMailPageComponent } from './components/send-mail-page/send-mail-page.component';
import { ContactRoutingModule} from './contact-routing.module';


@NgModule({
  declarations: [SendMailPageComponent],
  imports: [
    CommonModule,
    ContactRoutingModule
  ]
})
export class ContactModule { }
