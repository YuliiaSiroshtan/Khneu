import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomePageComponent } from './conteiners/home-page/home-page.component';
import { AuthGuard } from './services/auth-guard';
import { AddUpdateUserComponent } from './components/add-update-user-component/add-update-user.component';
import { UserListComponent } from './components/user-list-component/user-list.component';
import { NDRComponent } from './components/ndr-component/ndr.component';
import { PublicationComponent } from './components/publication-component/publication.component';
import { AppDashboardComponent } from './components/app-dashboard-component/app.dashboard.component';
import { ReportComponent } from './components/report-component/report.component';
import { TrainingJobComponent } from './components/training-job-component/training.job.component';
import { PlanManagementComponent } from './components/plan-management-component/plan.management.component';
import { PlanMethodicalWorkComponent } from './components/plan-methodical-work-component/plan.methodical.work.component';
import { PlanScientificWorkComponent } from './components/plan-scientific-work-component/plan.scientific.work.component';
import { UploadDistributionComponent } from './components/upload-distribution-component/upload-distribution.component';
import { DistributionComponent } from './components/distribution-component/distribution.component';
import { TeacherEntryLoadComponent } from './conteiners/teacher-entry-load/teacher-entry-load.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  {
    path: 'home',
    component: HomePageComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'user',
    component: AddUpdateUserComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'user-list',
    component: UserListComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'ndr',
    component: NDRComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'publication',
    component: PublicationComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'dashboard',
    component: AppDashboardComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'reports',
    component: ReportComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'training-job',
    component: TrainingJobComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'plan-management',
    component: PlanManagementComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'plan-methodical-work',
    component: PlanMethodicalWorkComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'plan-scientific-work',
    component: PlanScientificWorkComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'upload-distribution',
    component: UploadDistributionComponent,
    canActivate: [AuthGuard],
  },
  // {
  //   path: "distribution",
  //   canActivate: [AuthGuard]
  // },
  {
    path: 'entry-load',
    component: TeacherEntryLoadComponent,
    canActivate: [AuthGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CoreRoutingModule {}
