import { Component } from '@angular/core';
import { Router } from "@angular/router";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    isShowSidebar: boolean;

    constructor(private router: Router) { }

    ngOnInit() {
        this.isShowSidebar = this.router.url !== '/login';
    }
}
