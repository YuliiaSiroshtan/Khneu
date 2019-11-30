import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { LoginComponent } from "./auth/login-component/login.component";
import { AddUpdateUserComponent } from "./core/components/add-update-user-component/add-update-user.component";
import { HomeComponent } from "./core/components/home-component/home.component";
import { UserListComponent } from "./core/components/user-list-component/user-list.component";
import { NDRComponent } from "./core/components/ndr-component/ndr.component";
import { PublicationComponent } from "./core/components/publication-component/publication.component";
import { ReportComponent } from "./core/components/report-component/report.component";
import { AppDashboardComponent } from "./core/components/app-dashboard-component/app.dashboard.component";
import { TrainingJobComponent } from "./core/components/training-job-component/training.job.component";
import { PlanManagementComponent } from "./core/components/plan-management-component/plan.management.component";
import { PlanMethodicalWorkComponent } from "./core/components/plan-methodical-work-component/plan.methodical.work.component";
import { UploadDistributionComponent } from "./core/components/upload-distribution-component/upload-distribution.component";
import { PlanScientificWorkComponent } from "./core/components/plan-scientific-work-component/plan.scientific.work.component";
import { DistributionComponent } from "./core/components/distribution-component/distribution.component";
import { AuthGuard } from "./shared/guard/auth-guard";
import { HomePageComponent } from "./core/conteiners/home-page/home-page.component";

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full'},
  { path: "login", component: LoginComponent },
  {
    path: "home",
    component: HomePageComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: "",
        component: HomeComponent,
        outlet: "main",
        canActivate: [AuthGuard]
      },
      {
        path: "home",
        component: HomeComponent,
        outlet: "main",
        canActivate: [AuthGuard]
      },
      {
        path: "user",
        component: AddUpdateUserComponent,
        outlet: "main",
        canActivate: [AuthGuard]
      },
      {
        path: "user-list",
        component: UserListComponent,
        outlet: "main",
        canActivate: [AuthGuard]
      },
      {
        path: "ndr",
        component: NDRComponent,
        outlet: "main",
        canActivate: [AuthGuard]
      },
      {
        path: "publication",
        component: PublicationComponent,
        outlet: "main",
        canActivate: [AuthGuard]
      },
      {
        path: "dashboard",
        component: AppDashboardComponent,
        outlet: "main",
        canActivate: [AuthGuard]
      },
      {
        path: "reports",
        component: ReportComponent,
        outlet: "main",
        canActivate: [AuthGuard]
      },
      {
        path: "training-job",
        component: TrainingJobComponent,
        outlet: "main",
        canActivate: [AuthGuard]
      },
      {
        path: "plan-management",
        component: PlanManagementComponent,
        outlet: "main",
        canActivate: [AuthGuard]
      },
      {
        path: "plan-methodical-work",
        component: PlanMethodicalWorkComponent,
        outlet: "main",
        canActivate: [AuthGuard]
      },
      {
        path: "plan-scientific-work",
        component: PlanScientificWorkComponent,
        outlet: "main",
        canActivate: [AuthGuard]
      },
      {
        path: "upload-distribution",
        component: UploadDistributionComponent,
        outlet: "main",
        canActivate: [AuthGuard]
      },
      {
        path: "distribution",
        component: DistributionComponent,
        outlet: "main",
        canActivate: [AuthGuard]
      }
    ]
  }
];

@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forRoot(routes)]
})
export class AppRoutingModule {}
