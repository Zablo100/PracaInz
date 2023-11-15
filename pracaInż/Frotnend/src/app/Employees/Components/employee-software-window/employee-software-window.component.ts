import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { getErrorMessage } from 'src/app/Core/appip';
import { Software } from 'src/app/Models/Software';
import { SoftwareServiceService } from 'src/app/Software/software-service.service';

@Component({
  selector: 'app-employee-software-window',
  templateUrl: './employee-software-window.component.html',
  styleUrls: ['./employee-software-window.component.css']
})
export class EmployeeSoftwareWindowComponent implements OnInit {
  software: MatTableDataSource<Software>
  displayedColumns = ['Name', 'Description', 'AccessLevel', 'InstallFile']

  constructor(public dialogRef: MatDialogRef<EmployeeSoftwareWindowComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any, public service: SoftwareServiceService, private notification: ToastrService) { }

  ngOnInit(): void {
    this.loadData()
  }

  loadData(){
    this.service.getEmployeeSoftware(this.data.EmployeeId).subscribe((response) => {
      this.software = new MatTableDataSource<Software>(response as Software[])
    }, (err) => this.notification.error(getErrorMessage(err)))
  }


}
