import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { SharedAppModule } from "src/app/shared/shared.module";
import { CommonModule } from "@angular/common";
import { CoreModule } from './core/core.module';
import { AuthModule } from './auth/auth.module';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
      AppComponent
  ],
  imports: [
      BrowserModule,
      AppRoutingModule,
      SharedAppModule,
      AuthModule,
      CommonModule,
      CoreModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
