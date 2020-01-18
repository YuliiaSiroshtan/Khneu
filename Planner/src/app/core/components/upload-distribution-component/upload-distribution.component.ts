import { Component, OnInit } from "@angular/core";
import { PublicationDataService } from "../../services/publication-data.service";
import { EntryLoadService } from '../../services/entry-load.service';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'upload-distribution',
  templateUrl: './upload-distribution.component.html',
  styleUrls: ['./upload-distribution.component.css']
})
export class UploadDistributionComponent implements OnInit{
  displayedColumns: string[] = ['name', 'dateTime', 'hoursPerRate', 'isActive', 'action'];
  file: File;

  hoursEntryLoad: FormGroup;

  constructor(
    private _fb: FormBuilder,
    private _entryLoadService: EntryLoadService){
  }

  ngOnInit(){
    this._entryLoadService.uploadEntryLoadProperties();

    this.hoursEntryLoad = this._fb.group({
      hourPerRate: new FormControl(
        '',
        Validators.compose([Validators.required])
      )});
  }

  get entryLoadsProperty$(){
    return this._entryLoadService.entryLoadsProperty$;
  }

  choseFile(id: number){
    this._entryLoadService.updateEntryLoadFile(id);
  } 

  async uploadFile(data) {
    if(this.hoursEntryLoad.invalid) return;

   this.file = data.files[0];
   this._entryLoadService.uploadFile(this.file,  this.hoursEntryLoad.controls.hourPerRate.value);
   this.file = null;
  }
}
