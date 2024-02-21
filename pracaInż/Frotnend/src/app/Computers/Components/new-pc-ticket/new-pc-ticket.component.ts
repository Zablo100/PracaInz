import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { ComputerService } from '../../computer.service';
import { getErrorMessage } from 'src/app/Core/appip';

@Component({
  selector: 'app-new-pc-ticket',
  templateUrl: './new-pc-ticket.component.html',
  styleUrls: ['./new-pc-ticket.component.css']
})
export class NewPcTicketComponent implements OnInit {
  NewTicketForm: FormGroup;

  constructor(private dialogRef: MatDialogRef<NewPcTicketComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any, private notification: ToastrService, private service: ComputerService) { }

  ngOnInit(): void {
    this.NewTicketForm = new FormGroup({
      description: new FormControl(''),
      computerId: new FormControl(this.data.PcId)
    })

  }

  submit(){
    const body = this.NewTicketForm.value
    console.log(body)

    this.service.addTicket(body).subscribe(() => {
      this.dialogRef.close()
      this.notification.success("Pomylnie dodano interwencje")
    }, err => this.notification.error(getErrorMessage(err)))
  }

}
