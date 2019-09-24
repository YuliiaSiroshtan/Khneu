
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { BrowserModule } from "@angular/platform-browser";
import { MatInputModule } from '@angular/material/input';
import { MatRippleModule } from "@angular/material/core";
import { MatFormFieldModule } from "@angular/material/form-field";
import { AuthenticationService } from "src/app/shared/components/authentication-component";
import { HTTP_INTERCEPTORS } from "@angular/common/http";
import { TokenInterceptor } from "src/app/shared/components/token-interceptor.service";
import { SafePipe } from "src/app/shared/pipe/safe-pipe ";
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
import { UserDataService } from "src/app/planner-component/shared/service/user-data.service";
import { ListboxModule } from 'primeng/listbox';

@NgModule({
    imports:
    [
        FormsModule,
        MatInputModule,
        MatFormFieldModule,
        MatRippleModule,
        AppRoutingModule,
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
        ListboxModule
    ],
    exports:
    [
        FormsModule,
        MatInputModule,
        MatFormFieldModule,
        MatRippleModule,
        AppRoutingModule,
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
        ListboxModule
    ],
    providers:
    [
        { provide: AuthenticationService, useClass: AuthenticationService },
        { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
        { provide: UserDataService, useClass: UserDataService }
        //{ provide: HomeService, useClass: HomeService }
    ],
    declarations:
    [
        SafePipe
    ]
})

export class SharedAppModule { }
