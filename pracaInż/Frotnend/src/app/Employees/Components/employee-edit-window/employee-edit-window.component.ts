import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { SelectFactoryDTO } from 'src/app/Models/Factory';
import { EmployeeService } from '../../employee.service';
import { ToastrService } from 'ngx-toastr';
import { Employee } from 'src/app/Models/Employee';
import { getErrorMessage } from 'src/app/Core/appip';
import { DepartmentSelectDTO } from 'src/app/Models/Department';

@Component({
  selector: 'app-employee-edit-window',
  templateUrl: './employee-edit-window.component.html',
  styleUrls: ['./employee-edit-window.component.css']
})
export class EmployeeEditWindowComponent implements OnInit {
  PageLoaded: boolean = false
  EditForm: FormGroup;
  employee: Employee;
  SelectFactory: SelectFactoryDTO[];
  DepartmentsSelect: DepartmentSelectDTO[];

  constructor(public dialogRef: MatDialogRef<EmployeeEditWindowComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any, public service: EmployeeService, private notification: ToastrService) { }

  async ngOnInit(): Promise<void> {
    this.createForm()
    await this.getFactoryList()
    this.getDataFromAPI()
    await this.getDepartmentsList()
  }

  getDataFromAPI(){
    this.service.getEmployeeById(this.data.EmployeeId).subscribe((response) => {
      this.employee = response as Employee
      this.fillForm()
      this.PageLoaded = true
    }, (err) => {
      this.notification.error(getErrorMessage(err))
    })

  }

  createForm(){
    this.EditForm = new FormGroup({
      name: new FormControl(),
      surename: new FormControl(),
      email: new FormControl(),
      factory: new FormControl("1"),
      jobTitle: new FormControl(""),
      workPhoneNumber: new FormControl(""),
      departmentId: new FormControl(''),
    })
  }

  fillForm(){
    this.EditForm = new FormGroup({
      id: new FormControl(this.employee.id),
      name: new FormControl(this.employee.name),
      surename: new FormControl(this.employee.surname),
      email: new FormControl(this.employee.email),
      factory: new FormControl(this.employee.factoryId.toString()),
      jobTitle: new FormControl(this.employee.jobTitle),
      workPhoneNumber: new FormControl(this.employee.workPhoneNumber),
      departmentId: new FormControl(this.employee.departmentId.toString())
    })
  }

  async getFactoryList(){
    this.service.getDataForSelectElement().subscribe((response) => {
      this.SelectFactory = response as SelectFactoryDTO[]
    })
  }

  async getDepartmentsList(){
    this.service.getDapartmentsForSelect(parseInt(this.EditForm.value.factory)).subscribe((response) => {
      this.DepartmentsSelect = response as DepartmentSelectDTO[];
    }, (err) => {
      this.notification.error(getErrorMessage(err))
    })
  }

  submit(){
    const body = {
      id: this.EditForm.value.id,
      name: this.EditForm.value.name,
      surname: this.EditForm.value.surename,
      email: this.EditForm.value.email,
      jobTitle: this.EditForm.value.jobTitle,
      workPhoneNumber: this.EditForm.value.workPhoneNumber,
      departmentId: parseInt(this.EditForm.value.departmentId)
    }

    this.service.updateEmployee(body).subscribe(() => {
      this.notification.success("Pomyślnie zaktualizowano informacje o pracowniku")
      this.dialogRef.close()
    }, (err) => {
      this.notification.error(getErrorMessage(err))
    })
  }
}
