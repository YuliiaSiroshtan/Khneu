import { Component, OnInit } from "@angular/core";
import { PublicationDataService } from "../../services/publication-data.service";
import { HttpEventType } from '@angular/common/http';
import { UploadDistributionService } from "../../services/upload-distribution.service";
import { EntryLoadService } from '../../services/entry-load.service';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'upload-distribution',
  templateUrl: './upload-distribution.component.html',
  styleUrls: ['./upload-distribution.component.css']
})
export class UploadDistributionComponent implements OnInit{
  displayedColumns: string[] = ['name', 'dateTime', 'hoursPerRate',  'action'];
  file: File;

  hoursEntryLoad: FormGroup;

  constructor(
    private _publicationDataService: PublicationDataService,
    private _entryLoadService: EntryLoadService){
  }

  ngOnInit(){
    this._entryLoadService.uploadEntryLoadProperties();
  }

  get entryLoadsProperty$(){
    return this._entryLoadService.entryLoadsProperty$;
  }
  async uploadFile(data) {
   this.file = data.files[0];
   this._entryLoadService.uploadFile(this.file,  1);
   this.file = null;
  //  await this._publicationDataService.uploadFiles(this.file).subscribe(event => {
  //    console.log(event);
  //  });
  }
}
