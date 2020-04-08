import { Component, OnInit } from '@angular/core';
import { UtilsService } from '../../services/utils.service';
import { Router } from '@angular/router';

@Component({
  selector: 'pl-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

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

  ngOnInit(): void {
  }

  logout(){
    localStorage.clear();
    this._router.navigate(['/login']);
  }

}
