import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ApiMethod, EndPoints} from '../../params';
import { environment} from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public requestCall<responseType>(api: EndPoints, method: ApiMethod, payload?: any): any{
    let response;
    switch (method) {
      case ApiMethod.GET:
        response = this.httpClient.get<responseType>(`${environment.apiUrl}/${api}`,
          {
            withCredentials: true
          });
        break;
      case ApiMethod.POST:
        response = this.httpClient.post<responseType>(`${environment.apiUrl}/${api}`, payload,
          {
            withCredentials: true
          });
        break;
      case ApiMethod.DELETE:
        response = this.httpClient.delete<responseType>(`${environment.apiUrl}/${api}`,
          {
            withCredentials: true
          });
        break;
      case ApiMethod.PUT:
        response = this.httpClient.put<responseType>(`${environment.apiUrl}/${api}`, payload,
          {
            withCredentials: true
          });
        break;
      default:
        break;
    }
    return response;
  }
}
