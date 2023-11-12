import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { EmployeeService } from '../../employee.service';
import { ToastrService } from 'ngx-toastr';
import { getErrorMessage } from 'src/app/Core/appip';

@Component({
  selector: 'app-factory-delete-window',
  templateUrl: './factory-delete-window.component.html',
  styleUrls: ['./factory-delete-window.component.css']
})
export class FactoryDeleteWindowComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<FactoryDeleteWindowComponent>, 
    private service: EmployeeService, 
    private notification: ToastrService) { }

  ngOnInit(): void {
  }

  submit(){
    this.service.deleteFactory(this.data.factoryId).subscribe(() => {
      this.notification.success("Pomyślnie usnięto fabrykę")
      this.dialogRef.close()
    }, (err) => {
      this.notification.error(getErrorMessage(err))
      this.dialogRef.close()
    })
  }

  cancel(){
    this.dialogRef.close()
  }
}
