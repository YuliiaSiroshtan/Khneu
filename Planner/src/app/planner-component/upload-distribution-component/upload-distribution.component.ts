import { Component } from "@angular/core";
import { PublicationDataService } from "../publication-component/shared/service/publication-data.service";
import { HttpEventType } from '@angular/common/http';
import { UploadDistributionService } from "./shared/services/upload-distribution.service";


@Component({
  selector: 'upload-distribution',
  templateUrl: './upload-distribution.component.html'
})
export class UploadDistributionComponent{
  file: File;

  constructor(private _publicationDataService: PublicationDataService){
  }

  async uploadFile(data) {
   this.file = data.files[0];
   await this._publicationDataService.uploadFiles(this.file).subscribe(event => {
     console.log(event);
   });
  }
}
