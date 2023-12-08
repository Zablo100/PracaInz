import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { DocumentModel } from 'src/app/Models/DocumentModel';
import { DocumentServiceService } from '../../document-service.service';
import { ToastrService } from 'ngx-toastr';
import { getErrorMessage } from 'src/app/Core/appip';

@Component({
  templateUrl: './documents-page.component.html',
  styleUrls: ['./documents-page.component.css']
})
export class DocumentsPageComponent implements OnInit {
  SearchForm: FormGroup;
  PageLoaded: boolean = false
  data: MatTableDataSource<DocumentModel>
  displayedColumns = ['name', 'createAt', 'lastUpdate']
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  
  constructor(private service: DocumentServiceService, private notification: ToastrService) { }

  ngOnInit(): void {
    this.createForm();
    this.getDataFromApi();
  }

  createForm(){
    this.SearchForm = new FormGroup({
      search: new FormControl("")
    })
  }

  getDataFromApi(){
    this.service.getAllDocs().subscribe((response) => {
      this.data = new MatTableDataSource<DocumentModel>(response as DocumentModel[])
      console.log(response)
      this.data.paginator = this.paginator
      this.PageLoaded = true
    }, (err) => this.notification.error(getErrorMessage(err)))
  }

  openCreateWindow(){

  }

}
