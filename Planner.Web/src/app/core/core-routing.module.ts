import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomePageComponent } from './conteiners/home-page/home-page.component';
import { AuthGuard } from './services/auth-guard';


const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full'},
  { 
    path: 'home', 
    component: HomePageComponent, 
    canActivate: [AuthGuard] 
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CoreRoutingModule { }
