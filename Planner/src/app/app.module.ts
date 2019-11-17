import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { SharedAppModule } from "src/app/shared/shared.module";
import { CommonModule } from "@angular/common";
import { AppHeaderComponent } from "src/app/common/app-header-component/app-header.component";
import { AppSidenavComponent } from "src/app/common/app-sidenav-component/app-sidenav.component";
import { CoreModule } from './core/core.module';
import { AuthModule } from './auth/auth.module';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
      AppComponent,
      AppHeaderComponent,
      AppSidenavComponent
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
