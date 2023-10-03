import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-new-log-form',
  templateUrl: './new-log-form.component.html',
  styleUrls: ['./new-log-form.component.css']
})
export class NewLogFormComponent implements OnInit {
  RepairSelected: boolean = false
  CustomSelected: boolean = false
  CatForm: FormGroup
  RepairForm: FormGroup
  CustomForm: FormGroup

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    this.createForm()

  }

  createForm(){
    this.CatForm = new FormGroup({
      category: new FormControl()
    })
  }

  createRepairForm(){
    this.RepairForm = new FormGroup({
      type: new FormControl(0)
    })
  }

  categoryChange(){
    if (this.CatForm.value.category == 1){
      this.CustomSelected = false
      this.createRepairForm()
      this.RepairSelected = true
    }else if(this.CatForm.value.category == 2){
      this.RepairSelected = false

      this.CustomSelected = true
    }
  }

  RepairSubmit(){
    var body = {
      pcId: this.data.pcId,
      type: this.RepairForm.value.type
    }

    //post na endpoint wymian
  }


}
