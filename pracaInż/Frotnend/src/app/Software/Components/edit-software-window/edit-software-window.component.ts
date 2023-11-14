import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { SoftwareServiceService } from '../../software-service.service';
import { ToastrService } from 'ngx-toastr';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { getErrorMessage } from 'src/app/Core/appip';
import { Software } from 'src/app/Models/Software';

@Component({
  selector: 'app-edit-software-window',
  templateUrl: './edit-software-window.component.html',
  styleUrls: ['./edit-software-window.component.css']
})
export class EditSoftwareWindowComponent implements OnInit {
  AddForm: FormGroup;
  private software: Software;
  supportOptions: {value: string, text: string}[] = [{value: '0', text: "Brak"}, {value: '1', text: "Aktywne"}]

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private service: SoftwareServiceService, private notification: ToastrService, 
    private dialogRef: MatDialogRef<EditSoftwareWindowComponent>) { }

  ngOnInit(): void {
    this.createForm()
    this.loadData()
  }

  loadData(){
    this.service.getSoftwareInfo(this.data.SoftwareId).subscribe((response) => {
      this.software = response as Software;
      this.fillForm()
    })
  }

  createForm(){
    this.AddForm = new FormGroup({
      name: new FormControl(''),
      description: new FormControl(''),
      author: new FormControl(''),
      authorEmail: new FormControl(''),
      phoneNumber: new FormControl(''),
      support: new FormControl(''),
    })
  }

  fillForm(){
    this.AddForm = new FormGroup({
      name: new FormControl(this.software.name),
      description: new FormControl(this.software.description),
      author: new FormControl(this.software.author),
      authorEmail: new FormControl(this.software.authorEmail),
      phoneNumber: new FormControl(this.software.phoneNumber),
      support: new FormControl(this.software.support.toString()),
    })

  }

  submit(){
    const body = {
      id: this.data.SoftwareId,
      name: this.AddForm.value.name,
      description: this.AddForm.value.description,
      author: this.AddForm.value.author,
      authorEmail: this.AddForm.value.authorEmail,
      phoneNumber: this.AddForm.value.phoneNumber,
      support: parseInt(this.AddForm.value.support)
    }

    this.service.updateSoftwareInfo(body).subscribe(() => {
      this.notification.success("Pomyślnie zaktualizowan informacje")
      this.dialogRef.close()
    }, (err) => this.notification.error(getErrorMessage(err)))
  }
}
