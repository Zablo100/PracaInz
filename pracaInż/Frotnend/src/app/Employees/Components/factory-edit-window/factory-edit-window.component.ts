import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Employee } from 'src/app/Models/Employee';
import { EmployeeService } from '../../employee.service';
import { ToastrService } from 'ngx-toastr';
import { getErrorMessage } from 'src/app/Core/appip';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Factory } from 'src/app/Models/Factory';


@Component({
  selector: 'app-factory-edit-window',
  templateUrl: './factory-edit-window.component.html',
  styleUrls: ['./factory-edit-window.component.css']
})
export class FactoryEditWindowComponent implements OnInit {
  EditForm: FormGroup;
  factory: Factory
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<FactoryEditWindowComponent>, 
    private service: EmployeeService, 
    private notification: ToastrService) { }

  ngOnInit(): void {
    this.createFormGroup();
    this.getDataFromAPI();
  }

  getDataFromAPI(){
    this.service.getFactoryById(this.data.factoryId).subscribe((response) => {
      this.factory = response as Factory
      this.fillForm()
    }, (err) => {
      this.notification.error(getErrorMessage(err))
    })
  }

  createFormGroup(){
    this.EditForm = new FormGroup({
      city: new FormControl(""),
      street: new FormControl(""),
      streetNumber: new FormControl(""),
      postalCode: new FormControl("")
    })
  }

  fillForm(){
    this.EditForm = new FormGroup({
      city: new FormControl(this.factory.city),
      street: new FormControl(this.factory.street),
      streetNumber: new FormControl(this.factory.streetNumber),
      postalCode: new FormControl(this.factory.postalCode)
    })
  }

  submit(){
    const update: Factory = {
      id: this.data.factoryId,
      city: this.EditForm.value.city,
      street: this.EditForm.value.street,
      streetNumber: this.EditForm.value.streetNumber,
      postalCode: this.EditForm.value.postalCode
    }

    this.service.updateFactory(update).subscribe(() => {
      this.notification.success("Pomyślnie zmodyfikowane informacje o fabryce")
      this.dialogRef.close()
    }, (err) => {
      this.notification.error(getErrorMessage(err))
    })
  
  }
}
