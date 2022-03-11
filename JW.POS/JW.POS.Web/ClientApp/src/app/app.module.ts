import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';

import { AppComponent } from './app.component';
import {AppRoutingModule} from "./app-routing.module";
import {AuthorizedComponent} from "./layout/authorized/authorized.component";
import {AuthorizeInterceptor} from "@app/shared/interceptors";

@NgModule({
  declarations: [
    AppComponent,
    AuthorizedComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthorizeInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
