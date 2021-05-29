import {Injectable} from '@angular/core';
import {HttpService} from '../../../core/services/http/http.service';
import {ApiMethod, EndPoints} from '../../../core/params';
import {HttpClient, HttpErrorResponse} from '@angular/common/http';
import {Project} from '../../../core/models/Project.model';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import {Projects} from '../../models/Projects.model';
@Injectable({
  providedIn: 'root'
})
export class ProjectsService {

  constructor(
    private http: HttpService
  ) { }

  getProjectList(): Observable<Project[]>{
    return this.http.requestCall<Projects>(EndPoints.GET_PROJECTS, ApiMethod.GET)
      .pipe(map(x => x.projects));
  }
}
