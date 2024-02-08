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
    const role = window.sessionStorage.getItem("role")
    if(status == "true" && role == "Admin"){
      return true
    }else{
      return false
    }
  }

}
