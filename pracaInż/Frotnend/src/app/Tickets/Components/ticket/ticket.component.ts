import { Component, Inject, OnInit } from '@angular/core';
import { TicketService } from '../../ticket.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { TicketDTO } from 'src/app/Models/Ticket';
import { getErrorMessage } from 'src/app/Core/appip';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css']
})
export class TicketComponent implements OnInit {
  ticket: TicketDTO;
  PageLoaded: boolean = false

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
  private service: TicketService, private notification: ToastrService, 
  private dialogRef: MatDialogRef<TicketComponent>) { }

  ngOnInit(): void {
    this.getTicketData(this.data.TicketId)
  }

  getTicketData(id: number){
    this.service.getDataById(id).subscribe((response) => {
        this.ticket = response as TicketDTO;
        this.PageLoaded = true;
      }, 
      (err) => this.notification.error(getErrorMessage(err)))
  }

}
