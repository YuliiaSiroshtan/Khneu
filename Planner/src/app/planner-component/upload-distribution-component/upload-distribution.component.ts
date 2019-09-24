import { Component, OnInit } from "@angular/core";

@Component({
  selector: 'upload-distribution',
  templateUrl: './upload-distribution.component.html',
})
export class UploadDistributionComponent implements OnInit {
  file: File;

  ngOnInit() {
   
  }


  //async uploadFile(data) {
  //  this.file = data.files[0];
  //  await this.publicationDataService.uploadFiles(this.file).subscribe(event => {
  //    if (event.type === HttpEventType.Response) {
  //      this.publicationFile = event.body.toString();
  //    }
  //  });
  //}




}
