import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { EmployeeService } from '../../employee.service';
import { Employee } from '../../../Models/Employee';
import { Department } from 'src/app/Models/Department';
import { MatDialog } from '@angular/material/dialog';


@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {
  data!: MatTableDataSource<Department>;
  displayedColumns: string[] = ['name', 'shortName', "invoiceCode", "factoryLocation", "options"];

  constructor(private serivce: EmployeeService, private matDialog: MatDialog) { }

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngOnInit(): void {

    this.serivce.getAllDepartmentsWithoutEmployees().subscribe((response) => {
      this.data = new MatTableDataSource<any>(response as Department[]);
      this.data.paginator = this.paginator;
    })
  }

  click(id: number){
    console.log(id)
  }

  async openDeletWindow(id: number){
    // this.matDialog.open("InvoiceComponent", {
    //   "autoFocus": false,
    //   data: {
    //     DepartmentId: id,
    //   }
    // });
  }

  async openEditWindow(id: number){
    console.log("Edytowanie elementu o id: " + id)
  }


}
