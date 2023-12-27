import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ComputerService } from '../../computer.service';
import { ToastrService } from 'ngx-toastr';
import { getErrorMessage } from 'src/app/Core/appip';

@Component({
  selector: 'app-new-log-form',
  templateUrl: './new-log-form.component.html',
  styleUrls: ['./new-log-form.component.css']
})
export class NewLogFormComponent implements OnInit {
  selectedOption: number = 0;
  RepairSelected: boolean = false
  CleanSelected: boolean = false
  CatForm: FormGroup

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private service: ComputerService, private notification: ToastrService) { }

  ngOnInit(): void {
    this.createForm()
  }

  createForm(){
    this.CatForm = new FormGroup({
      category: new FormControl()
    })
  }

  categoryChange(){
    if (this.CatForm.value.category == 1){
      this.CleanSelected = false
      this.RepairSelected = true
    }else if(this.CatForm.value.category == 2){
      this.RepairSelected = false

      this.CleanSelected = true
    }
  }

  submit(){
    var body = {};
    if(this.RepairSelected){
      body = {
        pcId: this.data.pcId,
        type: 1,
        message: this.selectedOption
      }
    }else if(this.CleanSelected){
      body = {
        pcId: this.data.pcId,
        type: 2,
        message: this.selectedOption
      }
    }
    this.service.addPcLog(body).subscribe((Response) => {
      this.notification.success("Pomyślnie dodano informacje do komputera")
      location.reload()
    }, (err) => {
      this.notification.error(getErrorMessage(err))
    } )
  }

  updateOption(x: any){
    this.selectedOption = parseInt(x)
  }


}
