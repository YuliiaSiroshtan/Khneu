import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from "./components/home-component/home.component";
import { AddUpdateUserComponent } from "./components/add-update-user-component/add-update-user.component";
import { UserListComponent } from "./components/user-list-component/user-list.component";
import { NDRComponent } from "./components/ndr-component/ndr.component";
import { PublicationComponent } from "./components/publication-component/publication.component";
import { ReportComponent } from "./components/report-component/report.component";
import { TrainingJobComponent } from "./components/training-job-component/training.job.component";
import { PlanManagementComponent } from "./components/plan-management-component/plan.management.component";
import { PlanScientificWorkComponent } from "./components/plan-scientific-work-component/plan.scientific.work.component";
import { PlanMethodicalWorkComponent } from "./components/plan-methodical-work-component/plan.methodical.work.component";
import { UploadDistributionComponent } from "./components/upload-distribution-component/upload-distribution.component";
import { DistributionComponent } from "./components/distribution-component/distribution.component";
import { AppDashboardComponent } from "./components/app-dashboard-component/app.dashboard.component";
import { AddEditPublicationComponent } from './components/add-edit-publication-component/add-edit-publication.component';
import { PublicationListComponent } from './components/publication-list-component/publication-list.component';
import { DayEntryComponent } from './components/day-entry-component/day-entry.component';
import { HomePageComponent } from './conteiners/home-page/home-page.component';
import { UserListDataService } from './models/user-list-data.service';
import { NDRDataService } from './services/ndr-data.service';
import { PublicationDataService } from './services/publication-data.service';
import { ReportDataService } from './services/report-data.service';
import { DistributionDataService } from './services/distribution-data.service';
import { IndivPlanDataService } from './services/indiv-plan-data.service';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { SharedModule } from 'primeng/components/common/shared';
import { ToastModule } from 'primeng/toast';
import { FormsModule } from "@angular/forms";
import { ReactiveFormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { MatInputModule } from '@angular/material/input';
import { MatRippleModule, MatOptionModule } from "@angular/material/core";
import { MatFormFieldModule } from "@angular/material/form-field";
import { HTTP_INTERCEPTORS } from "@angular/common/http";
import { AppRoutingModule } from "src/app/app-routing.module";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { InputTextModule } from 'primeng/inputtext';
import { CalendarModule } from 'primeng/calendar';
import { CheckboxModule } from 'primeng/checkbox';
import { DropdownModule } from 'primeng/dropdown';
import { RadioButtonModule } from 'primeng/radiobutton';
import { InputSwitchModule } from 'primeng/inputswitch';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { InputMaskModule } from 'primeng/inputmask';
import { ButtonModule } from 'primeng/button';
import { SplitButtonModule } from 'primeng/splitbutton';
import { PaginatorModule } from 'primeng/paginator';
import { TableModule } from 'primeng/table';
import { TabViewModule } from 'primeng/tabview';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DialogModule } from 'primeng/dialog';
import { SidebarModule } from 'primeng/sidebar';
import { FileUploadModule } from 'primeng/fileupload';
import { MegaMenuModule } from 'primeng/megamenu';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { MatSidenavModule } from '@angular/material/sidenav';
import { ListboxModule } from 'primeng/listbox';
import { MessageService } from 'primeng/components/common/messageservice';
import { CoreRoutingModule } from './core-routing.module';
import { AppHeaderComponent } from './components/app-header-component/app-header.component';
import { AppSidenavComponent } from './components/app-sidenav-component/app-sidenav.component';
import { EntryLoadService } from './services/entry-load.service';
import { DesciplineService } from './services/descipline.service';
import { AccountService } from './services/account.service';
import { TeacherEntryLoadComponent } from './conteiners/teacher-entry-load/teacher-entry-load.component';
import {MatSelectModule} from '@angular/material/select';
import {MatTableModule} from '@angular/material/table';
import {MatButtonModule} from '@angular/material/button'

@NgModule({
  declarations: [
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
    DayEntryComponent,
    HomePageComponent,
    AppHeaderComponent,
    AppSidenavComponent,
    TeacherEntryLoadComponent
  ],
  imports: [
    CoreRoutingModule,
    CommonModule,
    SharedModule,
    FormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatRippleModule,
    AppRoutingModule,
    ReactiveFormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    InputTextModule,
    CalendarModule,
    CheckboxModule,
    DropdownModule,
    RadioButtonModule,
    InputSwitchModule,
    InputTextareaModule,
    InputMaskModule,
    ButtonModule,
    SplitButtonModule,
    PaginatorModule,
    TableModule,
    TabViewModule,
    ConfirmDialogModule,
    DialogModule,
    SidebarModule,
    FileUploadModule,
    MegaMenuModule,
    ToastModule,
    MessagesModule,
    MessageModule,
    ProgressSpinnerModule,
    MatSidenavModule,
    ListboxModule,
    MatOptionModule,
    MatSelectModule,
    MatTableModule,
    MatButtonModule
  ],
  exports: [
    SharedModule,
    ToastModule
  ],
  providers:
    [
      { provide: MessageService, useClass: MessageService },
      { provide: UserListDataService, useClass: UserListDataService },
      { provide: NDRDataService, useClass: NDRDataService },
      { provide: ConfirmationService, useClass: ConfirmationService },
      { provide: PublicationDataService, useClass: PublicationDataService },
      { provide: ReportDataService, useClass: ReportDataService },
      { provide: IndivPlanDataService, useClass: IndivPlanDataService },
      { provide: DistributionDataService, useClass: DistributionDataService },
      EntryLoadService,
      DesciplineService,
      AccountService
    ]
})
export class CoreModule { }
