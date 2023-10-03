import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LoginService } from '../login.service';
import { loginRequest } from '../Models/Api';


@Component({
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {
  loginForm!: FormGroup;


  constructor(private service: LoginService) { }

  ngOnInit(): void {
    this.createForm()
  }

  createForm(){
    this.loginForm = new FormGroup({
      username: new FormControl("", Validators.required),
      password: new FormControl("", Validators.required)
    })
  }

  async Login(){
    if (this.loginForm.valid){
      await this.service.Login(this.loginForm.value as loginRequest)
    }
  }

}
