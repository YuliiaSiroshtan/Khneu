import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from "@angular/forms";
import { LoginModel } from "src/app/account-component/shared/models/login.model";
import { AuthenticationService } from "src/app/shared/components/authentication-component";
import { Router } from "@angular/router";
import { MessageService } from "primeng/components/common/messageservice";

@Component({
  selector: 'account-login',
  templateUrl: './account-login.component.html',
  styleUrls: ['./account-login.component.css']
})
export class AccountLoginComponent implements OnInit {
  loginModel: LoginModel;
  userform: FormGroup;

  submitted: boolean;


  constructor(private _fb: FormBuilder,
    private _authenticationService: AuthenticationService,
    private _router: Router,
    private _messageService: MessageService
  ) { }

  ngOnInit() {
    this.loginModel = new LoginModel();

    this.userform = this._fb.group({
      'email': new FormControl('', Validators.compose([Validators.required, Validators.email])),
      'password': new FormControl('', Validators.compose([Validators.required, Validators.minLength(4)])),
    });

  }

  getErrorMessage(value: string) {
    if (value == 'password') {
      return this.userform.controls['password'].errors['required'] ? `Пароль - обов'язковий` :
        this.userform.controls['password'].errors['minlength'] ? 'Пароль повинен мати не менше 4-х символів' :'';
    }
    if (value == 'email') {
      return this.userform.controls['email'].errors['required'] ? `Електронна пошта - обов'язкова` :
        this.userform.controls['email'].errors['email'] ? 'Некоректний формат електронної пошти' : '';
    }
  }

  public onSubmit() {
      if (this.userform.invalid) return;

    this._authenticationService.isAuthenticated(this.loginModel).subscribe((res) => {
      if (res.jwtToken) {
        setTimeout(() => {
          this._router.navigate(['/home']);
        }, 200);
      } else if (res.error) {
        this._messageService.add({ key: 'error', severity: 'error', summary: '', detail: res.error });
      } else {
        this._messageService.add({ key: 'error', severity: 'error', summary: '', detail: 'Некоректний логін чи пароль' });
      }
    });
  }
}
