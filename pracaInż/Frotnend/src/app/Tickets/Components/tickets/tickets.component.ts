import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Tick } from 'chart.js/dist/core/core.scale';
import { TicketDTO } from 'src/app/Models/Ticket';
import { ToastrService } from 'ngx-toastr';
import { MatPaginator } from '@angular/material/paginator';
import { getErrorMessage } from 'src/app/Core/appip';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { TicketService } from '../../ticket.service';
import { TicketComponent } from '../ticket/ticket.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-tickets',
  templateUrl: './tickets.component.html',
  styleUrls: ['./tickets.component.css']
})

export class TicketsComponent {
  @Input() type: number;
  @Input() id: string | null;
  data: MatTableDataSource<TicketDTO>
  displayedColumns = ['createdAt', 'status', 'computer', 'description' ,'acceptedBy']
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private service: TicketService, private notification: ToastrService, private dialog: MatDialog, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadData()
  }

  loadData(){
    if(this.type == 1){
      this.loadDataByUser()
    }else if(this.type == 2){
      this.loadDataByPC()
    }
  }

  getHeight(){
    if(this.type == 1){
      return 9
    }else if(this.type == 2){
      return 8
    }
    return 10
  }

  loadDataByUser(){
    const id = this.id
    this.service.getByPerson(id).subscribe((response) => {
      this.data = new MatTableDataSource<TicketDTO>(response as TicketDTO[])
      this.data.paginator = this.paginator
    }, (err) => this.notification.error(getErrorMessage(err)))
  }

  loadDataByPC(){
    const id = this.id
    this.service.getByPc(id).subscribe((response) => {
      this.data = new MatTableDataSource<TicketDTO>(response as TicketDTO[])
      this.data.paginator = this.paginator
    }, (err) => this.notification.error(getErrorMessage(err)))
  }

  openTicketWindow(id: number){
    let dialogRef: MatDialogRef<TicketComponent> = this.dialog.open(TicketComponent, {
      "autoFocus": false,
      enterAnimationDuration: "180ms",
      data: {
        TicketId: id
      }
    })
  }
}
