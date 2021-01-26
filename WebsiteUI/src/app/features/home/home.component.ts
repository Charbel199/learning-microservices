import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor() {
  }

  ngOnInit(): void {
    this.changeClassColor('white', 'navitem');
    window.addEventListener('scroll', this.scroll, true);
  }

  ngOnDestroy(): void {
    window.removeEventListener('scroll', this.scroll, true);
    this.changeClassColor('black', 'navitem');
  }

  scroll = (event): void => {
    if (document.body.scrollTop > 80 || document.documentElement.scrollTop > 80) {
      document.getElementById('navbar').style.padding = '8px 90px';
      document.getElementById('navbar').style.backgroundColor = 'white';
      document.getElementById('logo').style.fontSize = '20px';
      this.changeClassColor('black', 'navitem');
    } else {
      document.getElementById('navbar').style.padding = '30px 90px';
      document.getElementById('navbar').style.backgroundColor = 'transparent';
      document.getElementById('logo').style.fontSize = '25px';
      this.changeClassColor('white', 'navitem');
    }
  };

  changeClassColor(color: string, className: string): void {
    var navbarItems = document.getElementsByClassName(className);
    for (var i = 0; i < navbarItems.length; i++) {
      var item = navbarItems[i] as HTMLElement;
      item.style.color = color;
    }
  }


}
