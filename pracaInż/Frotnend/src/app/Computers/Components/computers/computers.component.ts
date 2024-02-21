import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Computer, ComputerDTO, ComputerResponse, Dysk, newComputerDTO } from 'src/app/Models/Computer';
import { ComputerService } from '../../computer.service';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { FormControl, FormGroup } from '@angular/forms';
import { MatSort, Sort } from '@angular/material/sort';
import { PaginationResponse } from 'src/app/Models/Pagination';
import { Action } from 'rxjs/internal/scheduler/Action';
import { Employee } from 'src/app/Models/Employee';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { NewPcTicketComponent } from '../new-pc-ticket/new-pc-ticket.component';

@Component({
  selector: 'app-computers',
  templateUrl: './computers.component.html',
  styleUrls: ['./computers.component.css']
})
export class ComputersComponent implements OnInit {
  PageLoaded: boolean = false
  displayedColumns: string[] = ["pcName", "employee", "ticketCount" ,"yearOfPurches", "action"];
  data: MatTableDataSource<newComputerDTO>;
  form: FormGroup
  searchForm: FormGroup
  show: boolean = false
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  private Page: number = 1
  TotalCount: number;

  constructor(private service: ComputerService, private MatDialog: MatDialog, private notification: ToastrService) { }

  ngOnInit(): void {
    this.getDataToTable()

    this.createForm()
  }

  getDataToTable(){
    this.service.getPcList(this.Page).subscribe((response) => {
      console.log(response)
      const responseValue = response as PaginationResponse<newComputerDTO[]>
      this.data = new MatTableDataSource<newComputerDTO>(responseValue.value as newComputerDTO[]);
      this.TotalCount = responseValue.totalCount;
      this.data.sort = this.sort;
      this.data.paginator = this.paginator
  this.PageLoaded = true;
    });
    
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

    this.PageLoaded = false
    this.service.getPcList(this.Page).subscribe((response) => {
      const responseValue = response as PaginationResponse<newComputerDTO[]>
      this.data = new MatTableDataSource<newComputerDTO>(responseValue.value as newComputerDTO[]);
      this.PageLoaded = true;
    });
  }

  getPcDepartment(employee: Employee | null){
    if(employee == null){
      return "Brak"
    }

    return `${employee.departmentShortName}`;
  }

  createForm(){
    this.form = new FormGroup({
      cpu: new FormControl('0'),
      os: new FormControl('0'),
      gpu: new FormControl('0')
    })

    this.searchForm = new FormGroup({
      search: new FormControl()
    })
  }

  checkPerson(person: string){
    if (person == null){
      return true
    }

    return false;
  }

  checkYear(year: number){
    if(year == 0){
      return true
    }

    return false
  }

  resetFilter(){

  }

  filterData(){

  }

  applyFilter(){

  }

  addNewTicket(element: any){
    let dialog: MatDialogRef<NewPcTicketComponent> = this.MatDialog.open(NewPcTicketComponent, {
      "autoFocus": false,
      enterAnimationDuration: "180ms",
      data: {
        PcId: element
      }
    });

    dialog.afterClosed().subscribe(() => {
      this.getDataToTable()
    })

  }



}
