import { Component } from "@angular/core";
import { PublicationDataService } from "../../services/publication-data.service";
import { HttpEventType } from '@angular/common/http';
import { UploadDistributionService } from "../../services/upload-distribution.service";


@Component({
  selector: 'upload-distribution',
  templateUrl: './upload-distribution.component.html'
})
export class UploadDistributionComponent{
  constructor(
      private uploadService: UploadDistributionService) {
    }

  constructor(private _publicationDataService: PublicationDataService){
  }

  async uploadFile(data) {
   this.file = data.files[0];
   await this._publicationDataService.uploadFiles(this.file).subscribe(event => {
     console.log(event);
   });
  }


    for (let file of files)
      formData.append(file.name, file);


}
