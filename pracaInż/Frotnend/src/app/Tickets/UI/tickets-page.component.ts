import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Tick } from 'chart.js/dist/core/core.scale';
import { TicketDTO } from 'src/app/Models/Ticket';
import { TicketService } from '../ticket.service';
import { ToastrService } from 'ngx-toastr';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { getErrorMessage } from 'src/app/Core/appip';
import { TicketComponent } from '../Components/ticket/ticket.component';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { PaginationResponse } from 'src/app/Models/Pagination';

@Component({
  selector: 'app-tickets-page',
  templateUrl: './tickets-page.component.html',
  styleUrls: ['./tickets-page.component.css']
})
export class TicketsPageComponent implements OnInit {
  SearchForm: FormGroup;
  PageLoaded: boolean = false
  data: MatTableDataSource<TicketDTO>
  displayedColumns = ['createdAt', 'status', 'computer', 'description' ,'acceptedBy']
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  Page: number = 1
  TotalCount: number;

  constructor(private service: TicketService, private notification: ToastrService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.loadData()
  }

  loadData(){
    this.service.getDataFromAPI(this.Page).subscribe((response) => {
      const responseValue = response as PaginationResponse<TicketDTO[]>
      this.data = new MatTableDataSource<TicketDTO>(responseValue.value)
      this.TotalCount = responseValue.totalCount
      this.data.paginator = this.paginator
      this.PageLoaded = true
    }, (err) => this.notification.error(getErrorMessage(err)))
  }

  loadNextPage(event: PageEvent){
    if(event.previousPageIndex! < event.pageIndex){
      this.Page++
    }else{
      this.Page--
    }

    if(this.Page <= 0){
      this.Page = 1
    }

    this.service.getDataFromAPI(this.Page).subscribe((response) => {
      const responseValue = response as PaginationResponse<TicketDTO[]>
      this.data = new MatTableDataSource<TicketDTO>(responseValue.value)
      this.PageLoaded = true
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

    dialogRef.afterClosed().subscribe(async () => this.loadData())
  }

}
