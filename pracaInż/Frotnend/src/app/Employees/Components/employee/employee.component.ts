import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Observable, Subscription } from 'rxjs';
import { EmployeeService } from '../../employee.service';
import { Employee } from '../../../Models/Employee';
import { MatSelect } from '@angular/material/select';
import { MatIcon } from '@angular/material/icon';
import { MatFormField } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatButton } from '@angular/material/button';
import { EmployeeEditWindowComponent } from '../employee-edit-window/employee-edit-window.component';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  data: MatTableDataSource<Employee>;
  displayedColumns: string[] = ['department', 'name', 'lastname', 'position', 'email', 'phone', 'factory', 'computer', 'options'];
  rawData: Employee[]
  

  constructor(private serivce: EmployeeService, private matDialog: MatDialog) { }

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  ngOnInit(): void {
    this.getDataFromAPI()
  }

  getDataFromAPI(){
    this.serivce.getEmployeesList().subscribe((response) => {
      this.rawData = response as Employee[]
      this.data = new MatTableDataSource<Employee>(response as Employee[])
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
    }

    if(sort.direction == ""){
      this.sortByID()
    }

    }


  sortByDepartment(direction: string){

    if(direction == "asc"){
      this.data.data.sort((a,b) => {
        const e1 = a.departmentShortName
        const e2 = b.departmentShortName
  
        return e1 < e2 ? -1 : 1
      });
    }else{
      this.data.data.sort((a,b) => {
        const e1 = a.departmentShortName
        const e2 = b.departmentShortName
  
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


  openEditWindow(id: number){
    let dialog: MatDialogRef<EmployeeEditWindowComponent> = this.matDialog.open(EmployeeEditWindowComponent, {
      "autoFocus": false,
      enterAnimationDuration: "180ms",
      data: {
        EmployeeId: id,
      }
    });

    dialog.afterClosed().subscribe(async () => {
      await this.getDataFromAPI();
    })

  }



}
