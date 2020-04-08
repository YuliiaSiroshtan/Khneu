import { Injectable } from "@angular/core";
import { Roles } from '../static/constants/roles.constants';

@Injectable()
export class UtilsService {

  constructor() { }

  get role(){
      return localStorage.getItem('role');
  }

  get isHeadOfDepartmen(){
    return this.role === Roles.HeadOfDepartmen;
  }

  get isTeacher(){
    return this.role === Roles.Teacher;
  }

  get isTrainingDivision(){
    return this.role === Roles.TrainingDivision;
  }
}
