import { Injectable } from '@angular/core';
import {
  HttpEvent, HttpInterceptor,
  HttpHandler, HttpRequest,
  HttpResponse
} from "@angular/common/http";
import { Observable } from "rxjs";
import { tap } from "rxjs/operators";
@Injectable({
  providedIn: 'root'
})
export class InterceptService implements HttpInterceptor {
  constructor() { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const URL = "https://localhost:44354/api/"
    req = req.clone({ url: URL + req.url });

    return next.handle(req)
      .pipe(tap(event => {
        if (event instanceof HttpResponse) {
        }
      }))
  }
}
