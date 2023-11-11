import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Factory } from 'src/app/Models/Factory';
import { EmployeeService } from '../../employee.service';
import { ToastrService } from 'ngx-toastr';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { query } from '@angular/animations';

@Component({
  selector: 'app-factory',
  templateUrl: './factory.component.html',
  styleUrls: ['./factory.component.css']
})
export class FactoryComponent implements OnInit {
  data!: MatTableDataSource<Factory>;
  FactoryForm: FormGroup = new FormGroup({search: new FormControl("")})
  PageLoaded: boolean = false;
  displayedColumns: string[] = ['city', 'address', 'postal', "options"];
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private service: EmployeeService, private notification: ToastrService, private dialog: MatDialog) { }

  async ngOnInit(): Promise<void> {
    await this.getDataFormApi()
  }

  async getDataFormApi(){
    this.service.getFactories().subscribe((response) => {
      this.data = new MatTableDataSource<Factory>(response as Factory[])
      this.data.paginator = this.paginator;
      this.PageLoaded = true
    }, (err) => {
      this.notification.error(err.error.description)
    })
  }

  submit(){
    const body = {
      query: this.FactoryForm.value.search
    }
    this.service.searchFactoryByQuery(body).subscribe((response) => {
      this.data = new MatTableDataSource<Factory>(response as Factory[])
      this.data.paginator = this.paginator;
    }, (err) => {
      console.log(err)
      this.data = new MatTableDataSource<Factory>([])
      this.notification.error(err.error.description)
    })
  }

  openCreateWindow(){

  }

  openEditWindow(id: number){

  }

  openDeletWindow(id: number){

  }
}
