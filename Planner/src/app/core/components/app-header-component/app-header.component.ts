import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";

@Component({
    selector: 'app-header',
    templateUrl: './app-header.component.html',
    styleUrls: ['./app-header.component.css']
})
export class AppHeaderComponent implements OnInit {
    constructor(private _router: Router) { }

    ngOnInit() {
    }

    public logout() {
        localStorage.clear();
        this._router.navigate(['/login']);
    }
}
