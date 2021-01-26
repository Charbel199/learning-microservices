import { Component, OnInit, OnDestroy } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit, OnDestroy {

  constructor() { }

  ngOnInit(): void {
    this.changeClassColor('black', 'navitem');
    window.addEventListener('scroll', this.scroll, true);
  }

  ngOnDestroy(): void {
    window.removeEventListener('scroll', this.scroll, true);
  }

  scroll = (event): void => {
    if (document.body.scrollTop > 80 || document.documentElement.scrollTop > 80) {
      document.getElementById('navbar').style.padding = '8px 90px';
      document.getElementById('navbar').style.backgroundColor = 'white';
      document.getElementById('logo').style.fontSize = '20px';

    } else {
      document.getElementById('navbar').style.padding = '30px 90px';
      document.getElementById('navbar').style.backgroundColor = 'transparent';
      document.getElementById('logo').style.fontSize = '25px';

    }
  }
  changeClassColor(color: string, className: string): void {
    var navbarItems = document.getElementsByClassName(className);
    for (var i = 0; i < navbarItems.length; i++) {
      var item = navbarItems[i] as HTMLElement;
      item.style.color = color;
    }
  }

}
