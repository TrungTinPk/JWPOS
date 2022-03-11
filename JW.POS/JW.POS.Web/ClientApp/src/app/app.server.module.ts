import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppComponent } from './app.component';
import { AppModule } from './app.module';
import {AuthorizedComponent} from "./layout/authorized/authorized.component";

@NgModule({
    imports: [AppModule, ServerModule],
    bootstrap: [AppComponent]
})
export class AppServerModule { }
