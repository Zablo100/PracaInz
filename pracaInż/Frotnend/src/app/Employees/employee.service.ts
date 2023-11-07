import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, filter, find, map, Observable, tap } from 'rxjs';
import { Employee } from '../Models/Employee';
import { app } from '../Core/appip';
import { AddDepartmentDTO } from '../Models/Department';

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

  getDepartmentByID(id: number){
    return this.http.get(`https://${app.ip}/api/department/GetById/${id}`)
  }

  updateDepartment(request: any){ //TODO: Zmienić any na updateDepartmentDTO
    return this.http.put(`https://${app.ip}/api/department/FullUpdate`, request)
  }

  getDataForSelectElement(){
    return this.http.get(`https://${app.ip}/api/Factory/GetDataForSelectElement`)
  }

  getDepartmentsByFactoryId(id: number){
    return this.http.get(`https://${app.ip}/api/department/GetDepartmentsByFactoryId/` + id)
  }

  createNewDepartment(request: AddDepartmentDTO){
    return this.http.post(`https://${app.ip}/api/department/CreateNewDepartment`, request)
  }





}
