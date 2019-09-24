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


  constructor(private fb: FormBuilder,
    private authenticationService: AuthenticationService,
    private router: Router,
    private messageService: MessageService
  ) { }

  ngOnInit() {
    this.loginModel = new LoginModel();

    this.userform = this.fb.group({
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

    this.authenticationService.isAuthenticated(this.loginModel).subscribe((res) => {
      if (res.jwtToken) {
        setTimeout(() => {
          this.router.navigate(['/home']);
        }, 200);
      } else if (res.error) {
        this.messageService.add({ key: 'error', severity: 'error', summary: '', detail: res.error });
      } else {
        this.messageService.add({ key: 'error', severity: 'error', summary: '', detail: 'Некоректний логін чи пароль' });
      }
    });
  }
}
