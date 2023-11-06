import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { EmployeeService } from '../../employee.service';
import { Employee } from '../../../Models/Employee';
import { Department } from 'src/app/Models/Department';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSelect } from '@angular/material/select';
import { MatIcon } from '@angular/material/icon';
import { MatFormField } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatButton } from '@angular/material/button';
import { DepartmentEditWindowComponent } from '../department-edit-window/department-edit-window.component';

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

  async ngOnInit(): Promise<void> {
    await this.GetDataFromApi();
  }

  async GetDataFromApi(){
    this.serivce.getAllDepartmentsWithoutEmployees().subscribe((response) => {
      this.data = new MatTableDataSource<any>(response as Department[]);
      this.data.paginator = this.paginator;
    })
  }

  click(id: number){
    console.log(id)
  }

  openDeletWindow(id: number){
    // this.matDialog.open("InvoiceComponent", {
    //   "autoFocus": false,
    //   data: {
    //     DepartmentId: id,
    //   }
    // });
  }

  openEditWindow(id: number){
    let dialog: MatDialogRef<DepartmentEditWindowComponent> = this.matDialog.open(DepartmentEditWindowComponent, {
      "autoFocus": false,
      enterAnimationDuration: "180ms",
      data: {
        DepartmentId: id,
      }
    });

    dialog.afterClosed().subscribe(async () => {
      await this.GetDataFromApi();
    })

  }


}
