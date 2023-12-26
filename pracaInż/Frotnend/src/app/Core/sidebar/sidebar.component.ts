import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  checkIfLoggedIn(){
    const status = window.sessionStorage.getItem("login")
    if(status == "true"){
      return true
    }else{
      return false
    }
  }

}
