import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { loginRequest } from './Models/Api';
import { getErrorMessage } from '../Core/appip';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
/*
  Dodać model dla response i User
  Dodać notyfikacje
*/
export class LoginService {
  url: string = "https://localhost:7096/Account/login"

  constructor(private http: HttpClient, private router: Router, private notification: ToastrService) { }

  async Login(request: loginRequest){
    const headers = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
    
    this.http.post(this.url, request, headers).subscribe((response) => {
      this.ProcessLoginSucces(response)
    }, (err) => {
      if(err.status == 401){
        this.notification.error("Błąd logowania")
      }else{
        this.notification.error(getErrorMessage(err))
      }
    })
  }

  async ProcessLoginSucces(response: any){
    await this.storeUserData(response)
  }

  async storeUserData(data: any){
    window.sessionStorage.setItem("login", "true")
    window.sessionStorage.setItem("user", data.user.username)
    window.sessionStorage.setItem("role", data.user.role)
    window.sessionStorage.setItem("token", data.token)

    this.redirectUser(data.user.role)
  }

  redirectUser(role: string){
    console.log("Test: ", role)
    if (role == "Admin"){
      this.router.navigate(["./infrastructure"])
    }else if(role == "user"){
      this.router.navigate(["./user"]) // Spolszczyć ?
    }
  }
}
