import {Injectable} from '@angular/core';
import {HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import {ApiMethod, EndPoints} from '../../params';
import { environment} from '../../../../environments/environment';
import {catchError} from 'rxjs/operators';
import {Observable, throwError} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(
    private httpClient: HttpClient
  ) { }
  public requestCallUrlencoded<responseModel>(api: EndPoints, method: ApiMethod, payload?: any): Observable<responseModel> {
    let response;
    switch (method) {
      case ApiMethod.POST:
        response = this.httpClient.post<responseModel>(`${environment.apiUrl}/${api}`, payload.toString(),
          {
            withCredentials: false,
            headers: new HttpHeaders()
              .set('Content-Type', 'application/x-www-form-urlencoded')
          }).pipe(catchError(err => this.handleError(err)));
        break;
      default:
        break;
    }
    return response;
  }
  public requestCall<responseModel>(api: EndPoints, method: ApiMethod, payload?: any): Observable<responseModel>{
    let response;
    switch (method) {
      case ApiMethod.GET:
        response = this.httpClient.get<responseModel>(`${environment.apiUrl}/${api}`,
          {
            withCredentials: false
          }).pipe(catchError(err => this.handleError(err)));
        break;
      case ApiMethod.POST:
        response = this.httpClient.post<responseModel>(`${environment.apiUrl}/${api}`, payload,
          {
            withCredentials: false
          }).pipe(catchError(err => this.handleError(err)));
        break;
      case ApiMethod.DELETE:
        response = this.httpClient.delete<responseModel>(`${environment.apiUrl}/${api}`,
          {
            withCredentials: false
          }).pipe(catchError(err => this.handleError(err)));
        break;
      case ApiMethod.PUT:
        response = this.httpClient.put<responseModel>(`${environment.apiUrl}/${api}`, payload,
          {
            withCredentials: false
          }).pipe(catchError(err => this.handleError(err)));
        break;
      default:
        break;
    }
    return response;
  }


  // Should add functionality
  public handleError(error: HttpErrorResponse): any{
    console.error(error);
    return throwError( {error: error.message, status: error.status});
  }
}
