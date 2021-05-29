import { Component, OnInit } from '@angular/core';
import {ProjectsService} from '../../services/projects/projects.service';
import {Project} from '../../../core/models/Project.model';

import {Observable} from 'rxjs';



@Component({
  selector: 'app-projects-table',
  templateUrl: './projects-table.component.html',
  styleUrls: ['./projects-table.component.scss']
})

export class ProjectsTableComponent implements OnInit{

  constructor(
    private projectsService: ProjectsService
  ) {
  }
  projects$: Observable<Project[]>;

  ngOnInit(): void {
    this.projects$ = this.projectsService.getProjectList();
  }


}
