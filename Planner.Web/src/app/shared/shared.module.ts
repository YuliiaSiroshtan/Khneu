import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HeaderComponent } from './components/header/header.component';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatSidenavModule } from '@angular/material/sidenav';


//
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

import { MessageService, ConfirmationService } from 'primeng/api';

import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FooterComponent } from './components/footer/footer.component';
import { MenuComponent } from './components/menu/menu.component';
import { MatOptionModule, MatRippleModule } from '@angular/material/core';
import { UserListDataService } from '../core/models/user-list-data.service';
import { NDRDataService } from '../core/services/ndr-data.service';
import { PublicationDataService } from '../core/services/publication-data.service';
import { ReportDataService } from '../core/services/report-data.service';
import { IndivPlanDataService } from '../core/services/indiv-plan-data.service';
import { DistributionDataService } from '../core/services/distribution-data.service';
import { EntryLoadService } from '../core/services/entry-load.service';
import { DesciplineService } from '../core/services/descipline.service';
import { AccountService } from '../core/services/account.service';
import { UserDataService } from '../core/services/user-data.service';
import { SafePipe } from './pipe/safe-pipe ';

import { UtilsService } from './services/utils.service';

const MaterialModules = [
  MatSidenavModule,
  MatSelectModule,
  MatTableModule,
  MatMenuModule,
  MatButtonModule,
  MatInputModule,
  MatFormFieldModule,
  MatOptionModule,
  MatRippleModule
];

@NgModule({
  declarations: [
    FooterComponent,
    HeaderComponent,
    MenuComponent,
    SafePipe
  ],
  imports:
  [
      FormsModule,
      MatInputModule,
      MatFormFieldModule,
      MatRippleModule,
      HttpClientModule,
      BrowserModule,
      ReactiveFormsModule,
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
      MatMenuModule
  ],
  exports:
  [
      FormsModule,
      MatInputModule,
      MatFormFieldModule,
      MatRippleModule,
      ReactiveFormsModule,
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
      FooterComponent,
      HeaderComponent,
      MenuComponent,
      MatMenuModule
  ],
  providers:
  [
      { provide: UserDataService, useClass: UserDataService },
      //{ provide: HomeService, useClass: HomeService }
      UtilsService
  ]
})
export class SharedModule { }
