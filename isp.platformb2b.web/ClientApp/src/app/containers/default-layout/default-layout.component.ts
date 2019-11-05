import {Component, OnDestroy, Inject} from '@angular/core';
import {DOCUMENT} from '@angular/common';
import {navItems, NavData} from 'src/_nav';
import {AuthEnterpriceService} from 'src/app/_services';
import { NavBarByRoles } from 'src/app/_models';
import { notDeepEqual } from 'assert';


@Component({
  selector: 'app-dashboard',
  templateUrl: './default-layout.component.html',
  styleUrls:["./default-layout.component.css"]
})
export class DefaultLayoutComponent implements OnDestroy {
  public navItems;
  public sidebarMinimized = true;
  private changes: MutationObserver;
  public element: HTMLElement;

  constructor(@Inject(DOCUMENT) _document?: any, private auth?: AuthEnterpriceService) {

    //this.navItems = navItems;
    this.auth.getNavBar().subscribe(nav => 
      { 
        this.navItems = this.ordenar_navbar(nav);
        
        this.continuacion(_document);
      }); //this.navItems = nav,
    
  }


  continuacion (_document?: any)
  {
    this.changes = new MutationObserver((mutations) => {
      this.sidebarMinimized = _document.body.classList.contains('sidebar-minimized');
    });
    this.element = _document.body;
    this.changes.observe(<Element>this.element, {
      attributes: true,
      //attributeFilter: ['class']
    });
  }

  ordenar_navbar (navbar: NavBarByRoles[]):NavData[]
  {
    let navdata:NavData[]=[];
    navbar = navbar.reduce((unique, o) => {
      if(!unique.some(obj => obj.id_tipo_menu === o.id_tipo_menu )) {
        unique.push(o);
      }
      return unique;
    },[]);
    navbar = navbar.filter( (v, i, a) => a.indexOf(v) === i );
    navbar = navbar.sort((a,b)=> a.id_tipo_menu - b.id_tipo_menu );
    
    let navbar_cabeceras = navbar.filter(nv => nv.id_tipo_menu_padre == null);
    navbar_cabeceras.forEach(nvx => {
      let nd:NavData = {
        icon : nvx.icon,
        name : nvx.name,
        url : nvx.url,
      }
      let navbar_hijos = navbar.filter(nvc => nvc.id_tipo_menu_padre == nvx.id_tipo_menu)
      if (navbar_hijos.length>0)
      {
        nd.children = [];
        navbar_hijos.forEach(nc => 
          {
            let ndc:NavData =
            {
              icon : nc.icon,
              name : nc.name,
              url : nc.url,            
            }
            nd.children.push(ndc);
          })
      }
      navdata.push(nd);
      navdata.push({
        divider:true,        
      })
      
    });

    return navdata;
  }

  ngOnDestroy(): void {
    this.changes.disconnect();
  }

  salir() {
    this.auth.logout();
  }

  onlyUnique(value, index, self) { 
    return self.indexOf(value) === index;
  }

}
