import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { SelectFactoryDTO } from 'src/app/Models/Factory';
import { EmployeeService } from '../../employee.service';
import { AddDepartmentDTO } from 'src/app/Models/Department';
import { ToastrService } from 'ngx-toastr';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-department-add-window',
  templateUrl: './department-add-window.component.html',
  styleUrls: ['./department-add-window.component.css']
})
export class DepartmentAddWindowComponent implements OnInit {
  AddForm: FormGroup;
  SelectFactory: SelectFactoryDTO[];

  constructor(public dialogRef: MatDialogRef<DepartmentAddWindowComponent>, public service: EmployeeService, private notification: ToastrService) { }

  ngOnInit(): void {
    this.createForm()
    this.getFactoryList()
  }

  createForm(){
    this.AddForm = new FormGroup({
      name: new FormControl(""),
      shortName: new FormControl(""),
      invoiceCode: new FormControl(""),
      factoryId: new FormControl("1")
    })
  }

  getFactoryList(){
    this.service.getDataForSelectElement().subscribe((response) => {
      this.SelectFactory = response as SelectFactoryDTO[]})
  }

  submit(){
    let request: AddDepartmentDTO = {
      name: this.AddForm.value.name,
      shortName: this.AddForm.value.shortName,
      invoiceCode: this.AddForm.value.invoiceCode,
      factoryId: parseInt(this.AddForm.value.factoryId)
    }
    this.service.createNewDepartment(request).subscribe(() => {
      this.notification.success("Pomyślnie utworzono nowy dział")
      this.dialogRef.close()
    }, (err) => {
      console.log(err)
      this.notification.error(err.error.description)
    })
    
  }

}
