import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { SoftwareServiceService } from '../../software-service.service';
import { ToastrService } from 'ngx-toastr';
import { Software } from 'src/app/Models/Software';
import { MatDialogRef } from '@angular/material/dialog';
import { getErrorMessage } from 'src/app/Core/appip';

@Component({
  selector: 'app-add-software-window',
  templateUrl: './add-software-window.component.html',
  styleUrls: ['./add-software-window.component.css']
})
export class AddSoftwareWindowComponent implements OnInit {
  AddForm: FormGroup;

  constructor(private service: SoftwareServiceService, private notification: ToastrService, public dialogRef: MatDialogRef<AddSoftwareWindowComponent>) { }

  ngOnInit(): void {
    this.createForm()
  }

  createForm(){
    this.AddForm = new FormGroup({
      name: new FormControl(''),
      description: new FormControl(''),
      author: new FormControl(''),
      authorEmail: new FormControl(''),
      phoneNumber: new FormControl(''),
      support: new FormControl('0'),
    })
  }

  submit(){
    const body = {
      name: this.AddForm.value.name,
      description: this.AddForm.value.description,
      author: this.AddForm.value.author,
      authorEmail: this.AddForm.value.authorEmail,
      phoneNumber: this.AddForm.value.phoneNumber,
      support: parseInt(this.AddForm.value.support)
    }

    this.service.addNewSoftware(body).subscribe(() => {
      this.notification.success("Pomyślnie dodano nowe oprogramowanie do bazy")
      this.dialogRef.close()
    }, (err) => this.notification.error(getErrorMessage(err)))
  }
  
}
