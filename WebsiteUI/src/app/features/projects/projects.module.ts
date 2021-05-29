import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectsListComponent } from './components/projects-list/projects-list.component';
import { ProjectsRoutingModule} from './projects-routing.module';
import {SharedModule} from '../../shared/shared.module';


@NgModule({
  declarations: [ProjectsListComponent],
  imports: [
    CommonModule,
    ProjectsRoutingModule,
    SharedModule
  ]
})
export class ProjectsModule { }
