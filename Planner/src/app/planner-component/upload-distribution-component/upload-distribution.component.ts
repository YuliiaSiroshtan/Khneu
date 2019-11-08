import { Component, OnInit } from "@angular/core";
import { HttpEventType } from '@angular/common/http';
import { UploadDistributionService } from "./shared/services/upload-distribution.service";


@Component({
  selector: 'upload-distribution',
  templateUrl: './upload-distribution.component.html',
})
export class UploadDistributionComponent implements OnInit {
  constructor(
      private uploadService: UploadDistributionService) {
    }

  ngOnInit() {

  }

  upload(files) {
    if (files.length === 0) return;

    const formData = new FormData();

    for (let file of files)
      formData.append(file.name, file);

      this.uploadService.uploadFile(formData).subscribe(event => {
      if (event.type === HttpEventType.Response) {
        return event.body.toString();
      }
    });
  }
}
