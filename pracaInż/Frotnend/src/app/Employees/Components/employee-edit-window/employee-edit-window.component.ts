import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { SelectFactoryDTO } from 'src/app/Models/Factory';
import { EmployeeService } from '../../employee.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-employee-edit-window',
  templateUrl: './employee-edit-window.component.html',
  styleUrls: ['./employee-edit-window.component.css']
})
export class EmployeeEditWindowComponent implements OnInit {
  EditForm: FormGroup;
  SelectFactory: SelectFactoryDTO[];

  constructor(public dialogRef: MatDialogRef<EmployeeEditWindowComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any, public service: EmployeeService, private notification: ToastrService) { }

  async ngOnInit(): Promise<void> {
    this.createForm()
    await this.getFactoryList()
  }

  createForm(){
    this.EditForm = new FormGroup({
      name: new FormControl(),
      surename: new FormControl(),
      email: new FormControl(),
      factory: new FormControl("1"),
    })
  }

  async getFactoryList(){
    this.service.getDataForSelectElement().subscribe((response) => {
      this.SelectFactory = response as SelectFactoryDTO[]
    })
  }

  submit(){

  }
}
