import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedAppModule } from "src/app/shared/shared.module";
import { AccountModule } from "src/app/account-component/account.module";
import { CommonModule } from "@angular/common";
import { AppHeaderComponent } from "src/app/common/app-header-component/app-header.component";
import { AppSidenavComponent } from "src/app/common/app-sidenav-component/app-sidenav.component";
import { PlannerModule } from "src/app/planner-component/planner.module";

@NgModule({
  declarations: [
      AppComponent,
      AppHeaderComponent,
      AppSidenavComponent
  ],
  imports: [
      BrowserModule,
      //AppRoutingModule,
      SharedAppModule,
      AccountModule,
      CommonModule,
      PlannerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
