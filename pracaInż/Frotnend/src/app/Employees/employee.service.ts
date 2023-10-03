import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, filter, find, map, Observable, tap } from 'rxjs';
import { Employee } from '../Models/Employee';
import { app } from '../Core/appip';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  url: string = `http://${app.ip}/api/employee/`;

  constructor(private http: HttpClient) { }


  getAllDepartments(){
    return this.http.get("https://localhost:4040/api/v1/department")
  }

  getEmployeeById(id: number){
    const requestUrl = this.url + `get/${id}` 
    return this.http.get(requestUrl)
  }
  

  getEmployees() {
    const requestUrl = this.url + "all"
    return this.http.get(requestUrl)
  }




}
