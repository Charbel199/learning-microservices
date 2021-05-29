import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { AuthRoutingModule } from './auth-routing.module';


@NgModule({
  declarations: [LoginPageComponent],
  imports: [
    CommonModule,
    AuthRoutingModule
  ]
})
export class AuthModule { }
