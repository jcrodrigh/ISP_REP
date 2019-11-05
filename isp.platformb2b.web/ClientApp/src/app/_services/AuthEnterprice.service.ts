import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EnterpriseRegister } from '../_models/enterprice';

import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { NavData } from 'src/_nav';
import { NavBarByRoles } from '../_models';

@Injectable({
  providedIn: 'root'
})
export class AuthEnterpriceService {
    
  private currentUserSubject: BehaviorSubject<EnterpriseRegister>;
  public currentUser: Observable<EnterpriseRegister>;

  constructor(private http:HttpClient, private router: Router) 
  { 
    this.currentUserSubject = new BehaviorSubject<EnterpriseRegister>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  // getEnterprices ():Array<Enterprice>{
  //   return this.Enterprices;
  // }

  public get currentUserValue():EnterpriseRegister {
      return this.currentUserSubject.value;
  }

  login(username: string, password: string) {
    return this.http.post<EnterpriseRegister>(`/Auth/authenticate`, {username: username,password: password })
        .pipe(map(ent => {
          
            // login successful if there's a jwt token in the response
            if (ent && ent.token) {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('currentUser', JSON.stringify(ent));
                this.currentUserSubject.next(ent);
            }

            return ent;
        }));
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
    localStorage.clear();
    this.currentUserSubject.next(null);
    this.router.navigate(['/login']);
  }

  getNavBar():Observable<NavBarByRoles[]>
  {
    return this.http.get<NavBarByRoles[]>('auth/GetNavBarByRoles');
  }
}
