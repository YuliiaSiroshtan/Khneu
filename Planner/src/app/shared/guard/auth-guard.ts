import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { UserInfo } from "src/app/shared/models/user-info.model";

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
    isLogin: boolean;

    constructor(private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        this.isLogin = !!localStorage.getItem('tokenInfo');

        if (this.isLogin) {
            return true;
        }

        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }
}
