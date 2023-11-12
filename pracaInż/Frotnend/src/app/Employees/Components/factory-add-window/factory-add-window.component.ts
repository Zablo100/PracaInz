import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Employee } from 'src/app/Models/Employee';
import { EmployeeService } from '../../employee.service';
import { ToastrService } from 'ngx-toastr';
import { getErrorMessage } from 'src/app/Core/appip';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-factory-add-window',
  templateUrl: './factory-add-window.component.html',
  styleUrls: ['./factory-add-window.component.css']
})
export class FactoryAddWindowComponent implements OnInit {
  AddForm: FormGroup;
  constructor(public dialogRef: MatDialogRef<FactoryAddWindowComponent>,private service: EmployeeService, private notification: ToastrService) { }

  ngOnInit(): void {
    this.createFormGroup();
  }

  createFormGroup(){
    this.AddForm = new FormGroup({
      city: new FormControl(""),
      street: new FormControl(""),
      streetNumber: new FormControl(""),
      postalCode: new FormControl("")
    })
  }

  submit(){
    this.service.addNewFactory(this.AddForm.value).subscribe(() => {
      this.notification.success("Pomyślnie dodano fabryke")
      this.dialogRef.close()
    }, (err) => {
      this.notification.error(getErrorMessage(err))
    })
  
  }



}
