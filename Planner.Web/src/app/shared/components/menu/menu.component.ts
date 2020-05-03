import { Component } from '@angular/core';
import { UtilsService } from '../../services/utils.service';
import { Router } from '@angular/router';

@Component({
  selector: 'pl-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent {
  
  get isHeadOfDepartmen(){
    return this._utilsService.isHeadOfDepartmen;
  }

  get isTeacher(){
    return this._utilsService.isTeacher;
  }

  get isTrainingDivision(){
    return this._utilsService.isTrainingDivision;
  }

  constructor(
    private _utilsService: UtilsService,
    private _router: Router
    ) { }

  logout(){
    localStorage.clear();
    this._router.navigate(['/login']);
  }
}
