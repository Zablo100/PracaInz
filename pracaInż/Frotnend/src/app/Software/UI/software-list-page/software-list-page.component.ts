import { Component, OnInit, ViewChild } from '@angular/core';
import { SoftwareServiceService } from '../../software-service.service';
import { ToastrService } from 'ngx-toastr';
import { getErrorMessage } from 'src/app/Core/appip';
import { FormGroup } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Software } from 'src/app/Models/Software';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { AddSoftwareWindowComponent } from '../../Components/add-software-window/add-software-window.component';
import { EditSoftwareWindowComponent } from '../../Components/edit-software-window/edit-software-window.component';

@Component({
  templateUrl: './software-list-page.component.html',
  styleUrls: ['./software-list-page.component.css']
})
export class SoftwareListPAgeComponent implements OnInit {
  SearchForm: FormGroup;
  PageLoaded: boolean = false
  data: MatTableDataSource<Software>
  displayedColumns = ["Support", "Name", "Author", "Email", "PhoneNumber", "Description", "options"]
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private service: SoftwareServiceService, private notification: ToastrService, private dialog: MatDialog) { }

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
    let dialogRef: MatDialogRef<AddSoftwareWindowComponent> = this.dialog.open(AddSoftwareWindowComponent, {
      "autoFocus": false,
      enterAnimationDuration: "180ms",
    })

    dialogRef.afterClosed().subscribe(async () => this.loadData())
  }

  openEditWindow(id: number){
    let dialogRef: MatDialogRef<EditSoftwareWindowComponent> = this.dialog.open(EditSoftwareWindowComponent, {
      "autoFocus": false,
      enterAnimationDuration: "180ms",
      data: {
        SoftwareId: id
      }
    })

    dialogRef.afterClosed().subscribe(async () => this.loadData())
  }

  openDeletWindow(id: number){

  }

  submit(){

  }

}
