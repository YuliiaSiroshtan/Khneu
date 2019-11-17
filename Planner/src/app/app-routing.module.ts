import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './auth/login-component/login.component';
import { AddUpdateUserComponent } from './core/components/add-update-user-component/add-update-user.component';
import { HomeComponent } from './core/components/home-component/home.component';
import { UserListComponent } from './core/components/user-list-component/user-list.component';
import { NDRComponent } from './core/components/ndr-component/ndr.component';
import { PublicationComponent } from './core/components/publication-component/publication.component';
import { ReportComponent } from './core/components/report-component/report.component';
import { AppDashboardComponent } from './core/components/app-dashboard-component/app.dashboard.component';
import { TrainingJobComponent } from './core/components/training-job-component/training.job.component';
import { PlanManagementComponent } from './core/components/plan-management-component/plan.management.component';
import { PlanMethodicalWorkComponent } from './core/components/plan-methodical-work-component/plan.methodical.work.component';
import { UploadDistributionComponent } from './core/components/upload-distribution-component/upload-distribution.component';
import { PlanScientificWorkComponent } from './core/components/plan-scientific-work-component/plan.scientific.work.component';
import { DistributionComponent } from './core/components/distribution-component/distribution.component';
import { AuthGuard } from './shared/guard/auth-guard';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'user', component: AddUpdateUserComponent, canActivate: [AuthGuard] },
  { path: 'user-list', component: UserListComponent, canActivate: [AuthGuard] },
  { path: 'ndr', component: NDRComponent, canActivate: [AuthGuard] },
  { path: 'publication', component: PublicationComponent, canActivate: [AuthGuard] },
  { path: 'dashboard', component: AppDashboardComponent, canActivate: [AuthGuard] },
  { path: 'reports', component: ReportComponent, canActivate: [AuthGuard] },
  { path: 'training-job', component: TrainingJobComponent, canActivate: [AuthGuard] },
  { path: 'plan-management', component: PlanManagementComponent, canActivate: [AuthGuard] },
  { path: 'plan-methodical-work', component: PlanMethodicalWorkComponent, canActivate: [AuthGuard] },
  { path: 'plan-scientific-work', component: PlanScientificWorkComponent, canActivate: [AuthGuard] },
  { path: 'upload-distribution', component: UploadDistributionComponent, canActivate: [AuthGuard] },
  { path: 'distribution', component: DistributionComponent, canActivate: [AuthGuard] },
];

@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forRoot(routes)]
})
export class AppRoutingModule { }
