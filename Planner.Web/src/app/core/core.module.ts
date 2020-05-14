import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoreRoutingModule } from './core-routing.module';
import { UtilsService } from '../shared/services/utils.service';
import { UserListDataService } from './models/user-list-data.service';
import { NDRDataService } from './services/ndr-data.service';
import { PublicationDataService } from './services/publication-data.service';
import { ReportDataService } from './services/report-data.service';
import { IndivPlanDataService } from './services/indiv-plan-data.service';
import { DistributionDataService } from './services/distribution-data.service';
import { EntryLoadService } from './services/entry-load.service';
import { DesciplineService } from './services/descipline.service';
import { AccountService } from './services/account.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from '../app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatSidenavModule } from '@angular/material/sidenav';
import { MatOptionModule, MatRippleModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { HomeComponent } from './components/home-component/home.component';
import { AddUpdateUserComponent } from './components/add-update-user-component/add-update-user.component';
import { UserListComponent } from './components/user-list-component/user-list.component';
import { NDRComponent } from './components/ndr-component/ndr.component';
import { PublicationComponent } from './components/publication-component/publication.component';
import { AppDashboardComponent } from './components/app-dashboard-component/app.dashboard.component';
import { ReportComponent } from './components/report-component/report.component';
import { AddEditPublicationComponent } from './components/add-edit-publication-component/add-edit-publication.component';
import { PublicationListComponent } from './components/publication-list-component/publication-list.component';
import { TrainingJobComponent } from './components/training-job-component/training.job.component';
import { PlanManagementComponent } from './components/plan-management-component/plan.management.component';
import { PlanMethodicalWorkComponent } from './components/plan-methodical-work-component/plan.methodical.work.component';
import { PlanScientificWorkComponent } from './components/plan-scientific-work-component/plan.scientific.work.component';
import { UploadDistributionComponent } from './components/upload-distribution-component/upload-distribution.component';
import { DistributionComponent } from './components/distribution-component/distribution.component';
import { DayEntryComponent } from './components/day-entry-component/day-entry.component';
import { HomePageComponent } from './conteiners/home-page/home-page.component';
import { TeacherEntryLoadComponent } from './conteiners/teacher-entry-load/teacher-entry-load.component';


//
import { MessageService, ConfirmationService } from 'primeng/api';
// import { SharedModule } from 'primeng';
import { TabViewModule } from 'primeng/tabview';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DialogModule } from 'primeng/dialog';
import { SidebarModule } from 'primeng/sidebar';
import { FileUploadModule } from 'primeng/fileupload';
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
import { MegaMenuModule } from 'primeng/megamenu';
import { ToastModule } from 'primeng/toast';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { ListboxModule } from 'primeng/listbox';


import { SharedModule } from '../shared/shared.module';
import { UserService } from './services/user.service';

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
    TeacherEntryLoadComponent
  ],
  imports: [
    // CommonModule,
    // CoreRoutingModule,
    // SharedModule,

    CoreRoutingModule,
    CommonModule,
    SharedModule,
    FormsModule,
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
    ListboxModule,
    MatSidenavModule,
    MatOptionModule,
    MatSelectModule,
    MatTableModule,
    MatMenuModule,
    MatButtonModule,
    MatInputModule,
    MatFormFieldModule,
    MatRippleModule,
  ],
  providers: [
    UtilsService,
    UserService,
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
