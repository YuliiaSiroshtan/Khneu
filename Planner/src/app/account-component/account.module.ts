import { NgModule } from "@angular/core";
import { AccountLoginComponent } from "src/app/account-component/account-login-component/account-login.component";
import { MessageService } from "primeng/components/common/messageservice";
import { SharedAppModule } from "src/app/shared/shared.module";

@NgModule({
    imports:
    [
        SharedAppModule
    ],
    exports:
    [
        AccountLoginComponent
    ],
    declarations:
    [
        AccountLoginComponent
    ],
    entryComponents:
    [
        AccountLoginComponent
    ],
    providers:
    [
        { provide: MessageService, useClass: MessageService}
    ],

})

export class AccountModule { }
