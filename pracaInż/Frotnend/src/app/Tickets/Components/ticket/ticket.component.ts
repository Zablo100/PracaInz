import { Component, Inject, OnInit } from '@angular/core';
import { TicketService } from '../../ticket.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { TicketDTO } from 'src/app/Models/Ticket';
import { getErrorMessage } from 'src/app/Core/appip';
import { FormControl, FormGroup } from '@angular/forms';
import { Comment } from 'src/app/Models/Ticket';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css']
})
export class TicketComponent implements OnInit {
  CommentForm: FormGroup;
  ticket: TicketDTO;
  PageLoaded: boolean = false

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
  private service: TicketService, private notification: ToastrService, 
  private dialogRef: MatDialogRef<TicketComponent>) { }

  ngOnInit(): void {
    this.createForm()
    this.getTicketData(this.data.TicketId)
  }

  createForm(){
    this.CommentForm = new FormGroup({
      comment: new FormControl("")
    })
  }

  getTicketData(id: number){
    this.service.getDataById(id).subscribe((response) => {
        this.ticket = response as TicketDTO;
        this.PageLoaded = true;
      }, 
      (err) => this.notification.error(getErrorMessage(err)))
  }

  postComment(){
    if(this.CommentForm.value.comment == ''){
      this.notification.error("Komentarz nie może być pusty")
      return;
    }

    const body = {
      text: this.CommentForm.value.comment,
      TicketId: this.ticket.id
    }

    this.service.addCommentToTicket(body).subscribe((response) => {
      this.ticket.comments?.push(response as Comment)
    })

    this.CommentForm.get('comment')?.setValue("")
  }

  
}
