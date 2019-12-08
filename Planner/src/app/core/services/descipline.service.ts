import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { take, map } from "rxjs/operators";
import { BehaviorSubject } from "rxjs";
import {
  FullTimeDisciplinesViewModel,
  PartTimeDisciplineViewModel
} from "../models/disciplines.models";

@Injectable()
export class DesciplineService {
  fullTimeDisciplines: BehaviorSubject<
    FullTimeDisciplinesViewModel[]
  > = new BehaviorSubject<FullTimeDisciplinesViewModel[]>([]);

  partTimeDisciplines: BehaviorSubject<
    PartTimeDisciplineViewModel[]
  > = new BehaviorSubject<PartTimeDisciplineViewModel[]>([]);

  constructor(private _http: HttpClient) {}

  uploadFullTimeDiscipline(id: number) {
    this._http
      .get(
        environment.apiBaseUrl + "/Descipline/GetFullTimeDisciplines?id=" + id
      )
      .pipe(
        take(1),
        map((response: FullTimeDisciplinesViewModel[]) => {
          this.fullTimeDisciplines.next(response);
        })
      )
      .subscribe();
  }

  uploadPartTimeDisciplines(departmentId: number) {
    this._http
      .get(
        environment.apiBaseUrl +
          "/GetPartTimeDisciplines?department=" +
          departmentId
      )
      .pipe(
        take(1),
        map((response: PartTimeDisciplineViewModel[]) => {
          this.partTimeDisciplines.next(response);
        })
      )
      .subscribe();
  }
}
