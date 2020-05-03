import { Component } from '@angular/core';
import { AuthenticationService } from './auth/services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Web';

  get isLoggin(){
    return this._authService.isLoggin;
  }

  constructor(private _authService: AuthenticationService){ }
}
