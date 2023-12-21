import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, filter, find, map, Observable, tap } from 'rxjs';
import { Employee } from '../Models/Employee';
import { app } from '../Core/appip';
import { AddDepartmentDTO } from '../Models/Department';
import { AddFactoryDTO, Factory } from '../Models/Factory';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private baseUrl = `https://${app.ip}`
  constructor(private http: HttpClient) { }


  getAllDepartmentsWithoutEmployees(){
    return this.http.get(`https://${app.ip}/api/department/GetDepartmentsWithoutEmployees`)
  }

  getEmployeesList(){
    return this.http.get(`https://${app.ip}/Employee/GetEmployeesBasicInfo`)
  }

  getEmployeeById(id: string){
    return this.http.get(`https://${app.ip}/Employee/GetEmployeeById/` + id)
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

  searchDepartmentByQuery(query: any){
    return this.http.put(`${this.baseUrl}/api/department/SearchDepartment`, query)
  }

  getFactories(){
    return this.http.get(`${this.baseUrl}/api/Factory/GetFactoriesWithoutDepartments`)
  }

  searchFactoryByQuery(query: any){
    return this.http.put(`${this.baseUrl}/api/Factory/SearchFactoryByQuery`, query)
  }

  addNewFactory(request: AddFactoryDTO){
    return this.http.post(`${this.baseUrl}/api/Factory/createNewFactory`, request)
  }

  getFactoryById(id: number){
    return this.http.get(`${this.baseUrl}/api/Factory/GetFactoryById/` + id)
  }
  updateFactory(factory: Factory){
  return this.http.put(`${this.baseUrl}/api/Factory/UpdateFactory`, factory)
  }

  deleteFactory(id: number){
    return this.http.delete(`${this.baseUrl}/api/Factory/deleteFactoryById/` + id)
  }

  updateEmployee(body: any){
    return this.http.put(`${this.baseUrl}/Employee/UpdateEmployee`, body)
  }

  getDapartmentsForSelect(id: number){
    return this.http.get(`${this.baseUrl}/api/department/GetDepartmentsForSelectElement/` + id)
  }

  searchEmployee(body: any){
    return this.http.post(`${this.baseUrl}/Employee/SearchByQuery`, body)
  }

  getSummaryById(id: string | null ){
    return this.http.get(`${this.baseUrl}/Ticket/GetSummaryById/` + id)
  }

}
