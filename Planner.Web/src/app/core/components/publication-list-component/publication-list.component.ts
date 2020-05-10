import { Component, OnInit } from '@angular/core';
import { PublicationDataService } from "src/app/core/services/publication-data.service";
import { Publication } from '../../models/models-publication-component/publication.model';

@Component({
    selector: 'publication-list',
    templateUrl: './publication-list.component.html'
})
export class PublicationListComponent implements OnInit {
    publications: Publication[] = [];

    constructor(
        private _publicationDataService: PublicationDataService) {
    }

    ngOnInit() {
        this.getUserPublication();
    }



    getUserPublication() {
        this._publicationDataService.getUserPublication().subscribe((result: Publication[]) => {
            if (result) {
                this.publications = result;
            }
        });
    }

    sendMessage(id: string) {
      this._publicationDataService.sendMessageToLibrary(id).subscribe(s => {
        console.log(s);
      });
    }

}
