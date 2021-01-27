import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './components/footer/footer.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { RouterModule } from '@angular/router';
import { ProjectsTableComponent } from './components/projects-table/projects-table.component';


@NgModule({
  declarations: [FooterComponent, NavbarComponent, ProjectsTableComponent],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    FooterComponent,
    NavbarComponent,
    ProjectsTableComponent
  ]
})
export class SharedModule { }
