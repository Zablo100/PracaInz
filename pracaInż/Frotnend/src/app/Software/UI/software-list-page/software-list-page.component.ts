import { Component, OnInit } from '@angular/core';
import { SoftwareServiceService } from '../../software-service.service';
import { ToastrService } from 'ngx-toastr';
import { getErrorMessage } from 'src/app/Core/appip';
import { FormGroup } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Software } from 'src/app/Models/Software';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  templateUrl: './software-list-page.component.html',
  styleUrls: ['./software-list-page.component.css']
})
export class SoftwareListPAgeComponent implements OnInit {
  SearchForm: FormGroup;
  PageLoaded: boolean = false
  data: MatTableDataSource<Software>
  displayedColumns = ["Support", "Name", "Author", "Email", "PhoneNumber", "Description"]
  paginator: MatPaginator
  constructor(private service: SoftwareServiceService, private notification: ToastrService) { }

  ngOnInit(): void {
    this.loadData()
  }

  loadData(){
    this.service.getSoftwareList().subscribe((response) => {
      this.PageLoaded = true
      this.data = new MatTableDataSource<Software>(response as Software[])
      this.data.paginator = this.paginator
    }, (err) => this.notification.error(getErrorMessage(err)))
  }

  openCreateWindow(){

  }

  openEditWindow(id: number){

  }

  openDeletWindow(id: number){

  }

  submit(){

  }

}
