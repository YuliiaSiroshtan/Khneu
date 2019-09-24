import { NgModule } from "@angular/core";
import { AppHeaderComponent } from "src/app/common/app-header-component/app-header.component";
import { SharedAppModule } from "src/app/shared/shared.module";
import { HomeComponent } from "src/app/planner-component/home-component/home.component";
import { AddUpdateUserComponent } from "src/app/planner-component/shared/components/add-update-user-component/add-update-user.component";
import { UserListComponent } from "src/app/planner-component/user-list-component/user-list.component";
import { MessageService } from "primeng/components/common/messageservice";
import { UserListDataService } from "src/app/planner-component/user-list-component/shared/service/user-list-data.service";
import { NDRDataService } from "src/app/planner-component/ndr-component/shared/service/ndr-data.service";
import { NDRComponent } from "./ndr-component/ndr.component";
import { PublicationDataService } from "src/app/planner-component/publication-component/shared/service/publication-data.service";
import { PublicationComponent } from "./publication-component/publication.component";
import { ReportDataService } from "src/app/planner-component/report-component/shared/service/report-data.service";
import { ReportComponent } from "./report-component/report.component";
import { AppDashboardComponent } from "./app-dashboard-component/app.dashboard.component";
import { ConfirmationService } from "primeng/api";
import { AddEditPublicationComponent } from "src/app/planner-component/publication-component/add-edit-publication-component/add-edit-publication.component";
import { PublicationListComponent } from "src/app/planner-component/publication-component/publication-list-component/publication-list.component";
import { IndivPlanDataService } from "src/app/planner-component/indiv-plan-component/shared/service/indiv-plan-data.service";
import { TrainingJobComponent } from "src/app/planner-component/indiv-plan-component/training-job-component/training.job.component";
import { PlanManagementComponent } from "src/app/planner-component/indiv-plan-component/plan-management-component/plan.management.component";
import { PlanMethodicalWorkComponent } from "src/app/planner-component/indiv-plan-component/plan-methodical-work-component/plan.methodical.work.component";
import { PlanScientificWorkComponent } from "src/app/planner-component/indiv-plan-component/plan-scientific-work-component/plan.scientific.work.component";
import { UploadDistributionComponent } from "src/app/planner-component/upload-distribution-component/upload-distribution.component";
import { DistributionComponent } from "src/app/planner-component/distribution-component/distribution.component";
import { DistributionDataService } from "src/app/planner-component/distribution-component/shared/services/distribution-data.service";
import { DayEntryComponent } from "src/app/planner-component/distribution-component/day-entry-component/day-entry.component";

@NgModule({
    imports:
    [
        SharedAppModule
    ],
    exports:
    [
        HomeComponent,
        AddUpdateUserComponent,
        UserListComponent,
        NDRComponent,
        PublicationComponent,
        AppDashboardComponent,
        ReportComponent,
        TrainingJobComponent,
        PlanManagementComponent,
        PlanMethodicalWorkComponent,
        PlanScientificWorkComponent,
        UploadDistributionComponent,
      DistributionComponent,
      DayEntryComponent
    ],
    declarations:
    [
        HomeComponent,
        AddUpdateUserComponent,
        UserListComponent,
        NDRComponent,
        PublicationComponent,
        AppDashboardComponent,
        ReportComponent,
        AddEditPublicationComponent,
        PublicationListComponent,
        TrainingJobComponent,
        PlanManagementComponent,
        PlanMethodicalWorkComponent,
        PlanScientificWorkComponent,
        UploadDistributionComponent,
      DistributionComponent,
      DayEntryComponent
    ],
    entryComponents:
    [
        HomeComponent,
        AddUpdateUserComponent,
        UserListComponent,
        NDRComponent,
        PublicationComponent,
        AppDashboardComponent,
        ReportComponent,
        AddEditPublicationComponent,
        PublicationListComponent,
        TrainingJobComponent,
        PlanManagementComponent,
        PlanMethodicalWorkComponent,
        PlanScientificWorkComponent,
        UploadDistributionComponent,
      DistributionComponent,
      DayEntryComponent
    ],
    providers:
    [
        { provide: MessageService, useClass: MessageService },
        { provide: UserListDataService, useClass: UserListDataService},
        { provide: NDRDataService, useClass: NDRDataService },
        { provide: ConfirmationService, useClass: ConfirmationService },
        { provide: PublicationDataService, useClass: PublicationDataService },
        { provide: ReportDataService, useClass: ReportDataService },
        { provide: IndivPlanDataService, useClass: IndivPlanDataService },
        { provide: DistributionDataService, useClass: DistributionDataService }
    ],

})

export class PlannerModule { }
