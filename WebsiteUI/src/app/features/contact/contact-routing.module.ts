import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {SendMailPageComponent} from './components/send-mail-page/send-mail-page.component';



const routes: Routes = [
  {
    path: '', component: SendMailPageComponent
  }
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
// @ts-ignore
export class ContactRoutingModule { }
