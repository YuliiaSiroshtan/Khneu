import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { take, map, catchError } from "rxjs/operators";
import { BehaviorSubject, of } from "rxjs";
import {
  EntryLoadsPropertyViewModel,
  UserEntryLoadsPropertyViewModel
} from "../models/entry-load.models";

@Injectable()
export class EntryLoadService {
  entryLoadsProperty: BehaviorSubject<
    EntryLoadsPropertyViewModel[]
  > = new BehaviorSubject<EntryLoadsPropertyViewModel[]>([]);

  userEntryLoadsProperty: BehaviorSubject<
    UserEntryLoadsPropertyViewModel[]
  > = new BehaviorSubject<UserEntryLoadsPropertyViewModel[]>([]);

  constructor(private _http: HttpClient) {}

  uploadEntryLoadProperties() {
    this._http
      .get(environment.apiBaseUrl + '/EntryLoad/GetEntryLoadProperties')
      .pipe(
        take(1),
        map((response: EntryLoadsPropertyViewModel[]) => {
          this.entryLoadsProperty.next(response);
        })
      )
      .subscribe();
  }

  uploadUserEntryLoadPropertiesByUserId(userId: number) {
    this._http
      .get(
        environment.apiBaseUrl +
          '/EntryLoad/GetUserEntryLoadPropertiesByUserId?userId=' +
          userId
      )
      .pipe(
        take(1),
        map((response: UserEntryLoadsPropertyViewModel[]) => {
          this.userEntryLoadsProperty.next(response);
        })
      )
      .subscribe();
  }

  makeAnEntryLoadPlan(userId: number) {
    this._http
      .post(environment.apiBaseUrl + '/EntryLoad/MakeAnEntryLoadPlan', userId)
      .pipe(take(1))
      .subscribe();
  }

  updateEntryLoadFile(id: number) {
    this._http
      .post(environment.apiBaseUrl + '/EntryLoad/UpdateEntryLoadFile', id)
      .pipe(take(1))
      .subscribe();
  }

  deleteEntryLoadFile(id: number) {
    this._http
      .post(environment.apiBaseUrl + '/EntryLoad/DeleteEntryLoadFile', id)
      .pipe(take(1))
      .subscribe(
        () => {},
        err => console.log(err)
      );
  }

  deleteUserEntryLoadFile(id: number) {
    this._http
      .post(environment.apiBaseUrl + '/EntryLoad/DeleteUserEntryLoadFile', id)
      .pipe(
        take(1),
        catchError(err => of(console.log(err)))
      )
      .subscribe();
  }

  downloadFile(id: number) {
    this._http
      .get(environment.apiBaseUrl + '/EntryLoad/DownloadFile?id=' + id)
      .pipe(
        take(1),
        map(response => {
          console.log(response);
        }),
        catchError(err => of(console.log(err)))
      )
      .subscribe();
  }

  uploadFile(file: File, hoursPerRate: number) {
    let formData: FormData = new FormData();
    formData.append(file.name, file);
    formData.append('hoursPerRate', hoursPerRate.toString());

    this._http
      .post(environment.apiBaseUrl + '/EntryLoad/UploadFile', formData)
      .pipe(
        take(1),
        catchError(err => of(console.log(err)))
      )
      .subscribe();
  }
}
