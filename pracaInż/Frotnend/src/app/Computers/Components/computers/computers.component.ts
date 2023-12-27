import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Computer, ComputerDTO, ComputerResponse, Dysk } from 'src/app/Models/Computer';
import { ComputerService } from '../../computer.service';
import { MatPaginator } from '@angular/material/paginator';
import { FormControl, FormGroup } from '@angular/forms';
import { MatSort, Sort } from '@angular/material/sort';

@Component({
  selector: 'app-computers',
  templateUrl: './computers.component.html',
  styleUrls: ['./computers.component.css']
})
export class ComputersComponent implements OnInit {
  PageLoaded: boolean = false
  displayedColumns: string[] = ["name", "person", "processorName", "graphicsCardName", "ram", "osName", "yearOfPurches"];
  data: MatTableDataSource<ComputerDTO>;
  form: FormGroup
  searchForm: FormGroup
  show: boolean = false
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private service: ComputerService) { }

  ngOnInit(): void {
    this.getDataToTable()

    this.createForm()
  }

  getDataToTable(){
    this.service.getAll().subscribe((reponse) => {
      console.log(reponse)
      this.data = new MatTableDataSource<ComputerDTO>(reponse as ComputerDTO[]);
      this.data.sort = this.sort;
      this.data.paginator = this.paginator
  this.PageLoaded = true;
    });
    
  }

  createForm(){
    this.form = new FormGroup({
      cpu: new FormControl(''),
      os: new FormControl(''),
      ram: new FormControl('all')
    })

    this.searchForm = new FormGroup({
      search: new FormControl()
    })
  }

  resetFilter(){

  }

  filterData(){

  }

  applyFilter(){

  }

}
