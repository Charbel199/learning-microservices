import { Component, OnInit } from '@angular/core';
import {ProjectsService} from '../../services/projects.service';

@Component({
  selector: 'app-projects-list',
  templateUrl: './projects-list.component.html',
  styleUrls: ['./projects-list.component.scss']
})
export class ProjectsListComponent implements OnInit {

  constructor(
    private projectsService: ProjectsService
  ) { }

  ngOnInit(): void {
  }

  getProjects(){
    this.projectsService.getProjectList();
  }
}
