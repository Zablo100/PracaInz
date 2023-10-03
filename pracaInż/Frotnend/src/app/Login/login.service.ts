import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { loginRequest } from './Models/Api';

@Injectable({
  providedIn: 'root'
})
/*
  Dodać model dla response i User
  Dodać notyfikacje
*/
export class LoginService {
  url: string = "https://localhost:4040/api/v1/User/login"

  constructor(private http: HttpClient, private router: Router) { }

  async Login(request: loginRequest){
    const headers = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
    
    this.http.post(this.url, request, headers).subscribe((response) => {
      this.ProcessLogin(response)
    })
  }

  async ProcessLogin(response: any){

    if (response.httpStatus == 200){
      await this.storeUserData(response.data)
    }else{
      console.log(response.message)
    }
  }

  async storeUserData(data: any){
    window.sessionStorage.setItem("user", data.username)
    window.sessionStorage.setItem("role", data.role)

    this.redirectUser(data.role)
  }

  redirectUser(role: number){
    if (role == 1 || role == 2){
      this.router.navigate(["./pracownicy"]) // Zmienić potem na dashboard
    }else{
      this.router.navigate(["./user"]) // Spolszczyć ?
    }
  }
}
