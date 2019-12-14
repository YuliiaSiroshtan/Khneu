import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { take, map, catchError, tap } from 'rxjs/operators';
import { BehaviorSubject, of } from 'rxjs';
import {
  EntryLoadsPropertyViewModel,
  UserEntryLoadsPropertyViewModel
} from '../models/entry-load.models';

@Injectable()
export class EntryLoadService {
  entryLoadsProperty$: BehaviorSubject<
    EntryLoadsPropertyViewModel[]
  > = new BehaviorSubject<EntryLoadsPropertyViewModel[]>([]);

  userEntryLoadsProperty$: BehaviorSubject<
    UserEntryLoadsPropertyViewModel[]
  > = new BehaviorSubject<UserEntryLoadsPropertyViewModel[]>([]);

  constructor(private _http: HttpClient) {}

  uploadEntryLoadProperties() {
    this._http
      .get(environment.apiBaseUrl + 'api/EntryLoad/GetEntryLoadProperties')
      .pipe(
        take(1),
        map((response: EntryLoadsPropertyViewModel[]) => {
          this.entryLoadsProperty$.next(response);
        })
      )
      .subscribe();
  }

  uploadUserEntryLoadPropertiesByUserId(userId: number) {
    this._http
      .get(
        environment.apiBaseUrl +
          'api/EntryLoad/GetUserEntryLoadPropertiesByUserId?userId=' +
          userId
      )
      .pipe(
        take(1),
        map((response: UserEntryLoadsPropertyViewModel[]) => {
          this.userEntryLoadsProperty$.next(response);
        })
      )
      .subscribe();
  }

  makeAnEntryLoadPlan(userId: number) {
    this._http
      .post(environment.apiBaseUrl + 'api/EntryLoad/MakeAnEntryLoadPlan', userId)
      .pipe(take(1))
      .subscribe();
  }

  updateEntryLoadFile(id: number) {
    console.log('service '  + id);
    this._http
      .get(environment.apiBaseUrl + 'api/EntryLoad/UpdateEntryLoadFile?id=' + id)
      .pipe(take(1))
      .subscribe(()=>{
        this.uploadEntryLoadProperties();
      });
  }

  deleteEntryLoadFile(id: number) {
    this._http
      .post(environment.apiBaseUrl + 'api/EntryLoad/DeleteEntryLoadFile', id)
      .pipe(take(1))
      .subscribe(
        () => {},
        err => console.log(err)
      );
  }

  deleteUserEntryLoadFile(id: number) {
    this._http
      .post(environment.apiBaseUrl + 'api/EntryLoad/DeleteUserEntryLoadFile', id)
      .pipe(
        take(1),
        catchError(err => of(console.log(err)))
      )
      .subscribe();
  }

  downloadFile(id: number) {
    this._http
      .get(environment.apiBaseUrl + 'api/EntryLoad/DownloadFile?id=' + id)
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
    formData.append('file', file);
    formData.append('hoursPerRate', hoursPerRate.toString());
    console.log(file);
    this._http
      .post(environment.apiBaseUrl + 'api/EntryLoad/UploadFile', formData)
      .pipe(
        take(1),
        tap(()=>{
          this.uploadEntryLoadProperties();
        }),
        catchError(err => of(console.log(err)))
      )
      .subscribe();
  }
}
