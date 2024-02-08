import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Frotnend';
  
  constructor(private notification: ToastrService) { }

  ngOnInit(): void {
    this.chekForMobile()
    this.checkBrowser()
  }

  chekForMobile(){
    const isMobile = {
      Android: function() {
          return navigator.userAgent.match(/Android/i);
      },
      BlackBerry: function() {
          return navigator.userAgent.match(/BlackBerry/i);
      },
      iOS: function() {
          return navigator.userAgent.match(/iPhone|iPad|iPod/i);
      },
      Opera: function() {
          return navigator.userAgent.match(/Opera Mini/i);
      },
      Windows: function() {
          return navigator.userAgent.match(/IEMobile/i) || navigator.userAgent.match(/WPDesktop/i);
      },
      any: function() {
          return (isMobile.Android() || isMobile.BlackBerry() || isMobile.iOS() || isMobile.Opera() || isMobile.Windows());
      }
  };

  if(isMobile.any()){
    this.notification.warning("Aplikacje nie wspiera urządzeń mobilnych")
  }

  }

  checkBrowser(){
    if(!this.getBrowserName()){
      this.notification.warning("Używasz nie wspieranej przeglądarki")
    }
  }

  getBrowserName() {
    const agent = window.navigator.userAgent.toLowerCase();
    switch (true) {
      case agent.indexOf('edge') > -1:
        return 1;
      case agent.indexOf('opr') > -1 && !!(<any>window).opr:
        return 0;
      case agent.indexOf('chrome') > -1 && !!(<any>window).chrome:
        return 1;
      case agent.indexOf('trident') > -1:
        return 0;
      case agent.indexOf('firefox') > -1:
        return 0;
      case agent.indexOf('safari') > -1:
        return 0;
      default:
        return 0;
    }
  }
}
