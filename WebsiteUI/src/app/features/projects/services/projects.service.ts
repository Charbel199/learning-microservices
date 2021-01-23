import {Injectable} from '@angular/core';
import {HttpService} from '../../../core/services/http/http.service';
import {ApiMethod, EndPoints} from '../../../core/params';
import {HttpClient, HttpErrorResponse} from '@angular/common/http';
import {Project} from '../../../core/models/Project.model';
@Injectable({
  providedIn: 'root'
})
export class ProjectsService {

  constructor(
    private http: HttpService
  ) { }

  getProjectList(): any{
    this.http.requestCall<Project[]>(EndPoints.GET_PROJECTS, ApiMethod.GET).subscribe(
      res => {
        console.log('Got projects: ', res);
        return res;
      },
      error => {
        console.log('Error: ', error);
      },
      () => {
        console.log('Done');
       }
    );
  }
}
