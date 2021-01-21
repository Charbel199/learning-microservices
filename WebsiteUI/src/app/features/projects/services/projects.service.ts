import {Injectable} from '@angular/core';
import {HttpService} from '../../../core/services/http/http.service';
import {ApiMethod, EndPoints} from '../../../core/params';
import {HttpClient, HttpErrorResponse} from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class ProjectsService {

  constructor(
    private http: HttpService
  ) { }

  getProjectList(): any{
    this.http.requestCall<any>(EndPoints.GET_PROJECTS, ApiMethod.GET).subscribe(
      res => {
        console.log('Got projects: ', res);
      },
      error => {
        console.log('Error: ', error);
      },
      () => console.log('Done')
    );
  }
}
