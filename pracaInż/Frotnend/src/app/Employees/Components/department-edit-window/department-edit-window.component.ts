import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EmployeeService } from '../../employee.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Department, DepartmentDTO } from 'src/app/Models/Department';
import { MatInput } from '@angular/material/input';
import { MatFormField } from '@angular/material/form-field';
import { MatSelect } from '@angular/material/select';

@Component({
  selector: 'app-department-edit-window',
  templateUrl: './department-edit-window.component.html',
  styleUrls: ['./department-edit-window.component.css']
})
export class DepartmentEditWindowComponent implements OnInit {
  EditForm: FormGroup;
  Department: DepartmentDTO;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, public service: EmployeeService) { }

  ngOnInit(): void {
    this.test()
    this.GetDataFromAPI()
  }

  test(){
    this.EditForm = new FormGroup({
      name: new FormControl("test"),
      shortName: new FormControl("test"),
      invoiceCode: new FormControl("test"),
      factory: new FormControl("1")
    })
  }

  GetDataFromAPI(){
    console.log(this.data)
    this.service.getDepartmentByID(this.data.DepartmentId).subscribe((response) => {
      this.Department = response as DepartmentDTO;
      this.createForm();
    })
  }

  createForm(){
    this.EditForm = new FormGroup({
      name: new FormControl(this.Department.name),
      shortName: new FormControl(this.Department.shortName),
      invoiceCode: new FormControl(this.Department.invoiceCode),
      factory: new FormControl(`${this.Department.factoryId}`)
    })
  }

  submit(){
    console.log(this.EditForm.value)
  }



}
