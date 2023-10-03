import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { EmployeeService } from '../../employee.service';
import { Employee } from '../../../Models/Employee';


@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {
  data!: MatTableDataSource<any>;
  displayedColumns: string[] = ['name', 'short'];

  constructor(private serivce: EmployeeService) { }

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngOnInit(): void {

    this.serivce.getAllDepartments().subscribe((response) => {
      this.data = new MatTableDataSource<any>(response as any[]);
      this.data.paginator = this.paginator;
    })
  }
}
