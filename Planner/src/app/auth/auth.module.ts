import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { ReactiveFormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { MatInputModule } from '@angular/material/input';
import { MatRippleModule } from "@angular/material/core";
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
import { ToastModule } from 'primeng/toast';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { MatSidenavModule } from '@angular/material/sidenav';
import { ListboxModule } from 'primeng/listbox';
import { LoginComponent } from "./login-component/login.component";
import { SharedModule } from "primeng/components/common/shared";
import { CommonModule } from "@angular/common";
import { AuthenticationService } from "./services/authentication.service";
import { TokenInterceptor } from "./services/token-interceptor.service";
import { MessageService } from "primeng/components/common/messageservice";

@NgModule({
  declarations: [
    LoginComponent
  ],
  imports: [
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
    ListboxModule
  ],
  providers: [
    { provide: MessageService, useClass: MessageService },
    { provide: AuthenticationService, useClass: AuthenticationService },
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
  ]
})
export class AuthModule { }
