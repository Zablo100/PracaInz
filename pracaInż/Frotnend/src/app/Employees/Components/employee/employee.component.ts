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
import { FormControl, FormGroup } from '@angular/forms';
import { Factory, SelectFactoryDTO } from 'src/app/Models/Factory';
import { DepartmentSelectDTO } from 'src/app/Models/Department';
import { ToastrService } from 'ngx-toastr';
import { getErrorMessage } from 'src/app/Core/appip';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  SearchForm: FormGroup;
  data: MatTableDataSource<Employee>;
  displayedColumns: string[] = ['department', 'name', 'lastname', 'position', 'email', 'phone', 'factory', 'computer', 'options'];
  rawData: Employee[]
  factories: SelectFactoryDTO[];
  departments: DepartmentSelectDTO[];
  isFactorySelected: boolean = false;
  firstRun: boolean = true;

  constructor(private serivce: EmployeeService, private matDialog: MatDialog, private notification: ToastrService) { }

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  ngOnInit(): void {
    this.createForm()
    this.getDataFromAPI()
    this.getFactoriesForSelect()
  }

  createForm(){
    this.SearchForm = new FormGroup({
      factoryId: new FormControl('0'),
      departmentId: new FormControl({value: '0', disabled: true}),
      query: new FormControl('')
    })
  }

  getDataFromAPI(){
    this.serivce.getEmployeesList().subscribe((response) => {
      this.rawData = response as Employee[]
      this.data = new MatTableDataSource<Employee>(response as Employee[])
    }, (err) => {
      this.notification.error(getErrorMessage(err))
    })
  }

  getFactoriesForSelect(){
    this.serivce.getDataForSelectElement().subscribe((response) => {
      this.factories = response as SelectFactoryDTO[]
    }, (err) => {
      this.notification.error(getErrorMessage(err))
    })
  }

  getDepartmentsForSelect(){
    this.serivce.getDapartmentsForSelect(parseInt(this.SearchForm.value.factoryId)).subscribe((response) => {
      this.departments = response as DepartmentSelectDTO[]
    }, (err) => {
      this.notification.error(getErrorMessage(err))
    })
  }

  factorySelectChange(){
    if(parseInt(this.SearchForm.value.factoryId) == 0){
      this.getDataFromAPI()
      this.SearchForm.get('departmentId')?.disable();
      this.SearchForm.controls['departmentId'].setValue('0')
    }else{
      this.getDepartmentsForSelect()
      this.SearchForm.get('departmentId')?.enable();
    }

    this.submit()
  }

  submit(){
    let dep = 0;
    if(!this.SearchForm.controls['departmentId'].disabled){
      dep = parseInt(this.SearchForm.value.departmentId)
    }

    const body = {
      factoryId: parseInt(this.SearchForm.value.factoryId),
      departmentId: dep,
      query: this.SearchForm.value.query
    }
    this.serivce.searchEmployee(body).subscribe((response) => {
      this.data = new MatTableDataSource<Employee>(response as Employee[])
      this.data.paginator = this.paginator;
    }, (err) => {
      this.notification.error(getErrorMessage(err))
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
