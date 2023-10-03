import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Observable, Subscription } from 'rxjs';
import { EmployeeService } from '../../employee.service';
import { Employee } from '../../../Models/Employee';


@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  data: MatTableDataSource<Employee>;
  displayedColumns: string[] = ['department', 'name', 'lastname', 'position', 'email', 'phone', 'factory', 'computer'];
  rawData: Employee[]
  selectedEmp: Employee;

  constructor(private serivce: EmployeeService) { }

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  ngOnInit(): void {
    this.serivce.getEmployees().subscribe((reponse) => {
      this.data = new MatTableDataSource<Employee>(reponse as Employee[]);
      this.data.sort = this.sort;
      this.rawData = reponse as Employee[]
      this.data.paginator = this.paginator

      console.log(this.rawData)
    })

  }


  ngAfterViewInit() {
    setTimeout(() => {
      this.data.sort = this.sort;
    }, 1000);
  }


  sortData(sort: Sort) {
    if (sort.active == "department"){
      this.sortByDepartment(sort.direction)
    }else if(sort.active == "factory"){
      //console.log(sort)
      this.sortByFactory(sort.direction)
    }

    if(sort.direction == ""){
      this.sortByID()
    }

    }


  sortByDepartment(direction: string){

    if(direction == "asc"){
      this.data.data.sort((a,b) => {
        const e1 = a.department.name
        const e2 = b.department.name
  
        return e1 < e2 ? -1 : 1
      });
    }else{
      this.data.data.sort((a,b) => {
        const e1 = a.department.name
        const e2 = b.department.name
  
        return e1 > e2 ? -1 : 1
      });
    }

  }

  sortByFactory(direction: string){

    if(direction == "asc"){
      this.data.data.sort((a,b) => {
        const e1 = a.factory.city
        const e2 = b.factory.city
  
        return e1 < e2 ? -1 : 1
      });
    }else{
      this.data.data.sort((a,b) => {
        const e1 = a.factory.city
        const e2 = b.factory.city
  
        return e1 > e2 ? -1 : 1
      });
    }

  }

  sortByID(){
    this.data.data.sort((a,b) => {
      const e1 = a.id
      const e2 = b.id

      return e1 < e2 ? -1 : 1
    });
  }

  test(emp: Employee){
    console.log(emp)
  }


}
