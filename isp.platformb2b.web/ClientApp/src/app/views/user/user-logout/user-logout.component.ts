import { Component, OnInit, OnDestroy, Inject } from '@angular/core';
import { AuthEnterpriceService } from 'src/app/_services';
import { navItems } from 'src/_nav';
import { DOCUMENT } from '@angular/common';

@Component({
  template:"./user-logout.component.html",
  selector: 'app-user-logout'
})
export class UserLogoutComponent implements OnInit {
  
 

  constructor( private auth?: AuthEnterpriceService) {
    console.log("ola pochito x")
    this.salir();
  }

  ngOnInit(): void {
    console.log("ola pochito y")
    this.salir();
  }

 
  salir() {
    this.auth.logout();
  }
}
