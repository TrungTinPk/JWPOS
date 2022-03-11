import {Inject, Injectable} from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {AuthenticateService, StorageService} from "@app/shared/services";
import {catchError, mergeMap} from "rxjs/operators";
import {Router} from "@angular/router";
import stringHelper from "@app/shared/helpers/string.helper";
import {mergeMappings} from "@angular/compiler-cli/src/ngtsc/sourcemaps/src/source_file";

@Injectable()
export class AuthorizeInterceptor implements HttpInterceptor {

  constructor(
    @Inject("BASE_URL") private _baseUrl: string,
    private authService: AuthenticateService,
    private router: Router
  ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return this.authService.getToken().pipe(mergeMap(token => this.processRequestWithToken(token,request, next)));
  }

  private processRequestWithToken(token: string | null, req: HttpRequest<unknown>, next: HttpHandler){
    req = req.clone({
      url: stringHelper.trimEnding(this._baseUrl,'/') + '/' + stringHelper.trimLeading(req.url,'/')
    })

    if (!!token && token.length > 0 && this.isSameOrigin(req)) {
      req = req.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
    }

    return next.handle(req).pipe(catchError(this.handleError))
  }

  private handleError = (err: any) => {
    if (err.status === 401) {
      this.authService.clearToken();
      this.router.navigate(['login']);
    }

    return throwError({
      success: false,
      statusCode: 'internal_server_error'
    })
  }

  private isSameOrigin(req: any): boolean {
    if (req.url.startsWith(`${window.location.origin}/`)) {
      return true;
    }

    if (req.url.startsWith(`${window.location.host}/`)) {
      return true;
    }

    if (/^\/[^\/].*/.test(req.url)) {
      return  true;
    }

    return  false;
  }
}
