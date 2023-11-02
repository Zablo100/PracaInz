import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, filter, find, map, Observable, tap } from 'rxjs';
import { Employee } from '../Models/Employee';
import { app } from '../Core/appip';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }


  getAllDepartmentsWithoutEmployees(){
    return this.http.get(`https://${app.ip}/api/department/GetDepartmentsWithoutEmployees`)
  }

  getEmployeesList(){
    return this.http.get(`https://${app.ip}/Employee/GetEmployeesBasicInfo`)
  }





}
