import { Injectable } from '@angular/core';
import { Router, CanActivate,
     ActivatedRouteSnapshot, 
     RouterStateSnapshot, ActivatedRoute,
      CanActivateChild, CanLoad, Route, UrlSegment } from '@angular/router';

import {  AuthEnterpriceService } from '../_services';
import { AnimationQueryMetadata } from '@angular/animations';

@Injectable({ providedIn: 'root' })
export class EnterpriceGuard implements CanActivate,
                                        CanActivateChild,
                                        CanLoad {
    sharedData:any;
    sub:any;
    constructor(
        private router: Router,
        private routeActive: ActivatedRoute,
        private AuthEnterpriceService: AuthEnterpriceService
    ) 
    { 
        
    }

   canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        
    
        const currentUser = this.AuthEnterpriceService.currentUserValue;
        
        console.log('current user',currentUser);
        
        

        if (currentUser) {
            console.log("si está el current user :V")
            /*
            console.log("data",route.data.roles)
            console.log(route.data.roles)
            console.log("titulo",route.data.title)

            
            // check if route is restricted by role
            /*if (route.data.roles && //!route.data.roles.some(ele => !currentUser.roles.includes(ele))
            (route.data.roles.some(v=> currentUser.roles.indexOf(v) === -1)))
            {//this.match_roles(route.data.roles,currentUser.roles)) {
                // role not authorised so redirect to home page
                this.router.navigate(['/']);
                //for (var i = 0 ;i<1000;i++)
                //console.log('result',!(route.data.roles.some(v=> currentUser.roles.indexOf(v) !== -1)))
                return false;
            }

            // authorised so return true*/
            return true;
        }

        // not logged in so redirect to login page with the return url
        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }

     canActivateChild ( route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot)
    {
        const currentUser = this.AuthEnterpriceService.currentUserValue;
            if (currentUser) {
            return true;
            }

            else 
            {
                this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
                return false;
            }
        
        console.log('titulo',route.data['title']);
        console.log('roles',route.data['roles']);
        this.routeActive.data.subscribe(data => {console.log('la data es:',data)});
        
        return  true;
        
    }

    canLoad  ( route: Route, segments: UrlSegment[])
        {
            const currentUser = this.AuthEnterpriceService.currentUserValue;
            console.log('data positiva:',this.routeActive.params);
            console.log('current user',currentUser);
            
            
    
            if (currentUser) {
            return true;
            }

            else 
            {
                this.router.navigate(['/login']);
                return false;
            }
            console.log('titulo',route.data['title']);
        console.log('roles',route.data['roles']);
        this.routeActive.data.subscribe(data => {console.log('la data es:',data)});
         setTimeout(() => {
            return true;
        }, 10000);
        return  true;
        }

    

    
}