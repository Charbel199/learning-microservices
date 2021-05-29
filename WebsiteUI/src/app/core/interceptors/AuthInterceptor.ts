import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  intercept(req: HttpRequest<any>,
            next: HttpHandler): Observable<HttpEvent<any>> {

    const accessToken = localStorage.getItem('access_token');

    if (accessToken) {
      console.log('Found JWT token found in local storage');
      const cloned = req.clone({
        headers: req.headers.set('Authorization', 'Bearer ' + accessToken)
      });

      return next.handle(cloned);
    }
    else {
      console.log('No JWT token found in local storage');
      return next.handle(req);
    }
  }
}
