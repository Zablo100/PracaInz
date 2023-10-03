import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Computer, ComputerResponse, Dysk } from 'src/app/Models/Computer';
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
  displayedColumns: string[] = ["name", "employee", "cpu", 'ram','gpu', "os", "hardDrive", "workType"];
  data: MatTableDataSource<ComputerResponse>;
  rawData: ComputerResponse[];
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
      this.data = new MatTableDataSource<ComputerResponse>(reponse as ComputerResponse[]);
      this.data.sort = this.sort;
      this.rawData = reponse as ComputerResponse[]
      this.data.paginator = this.paginator
      this.data.filterPredicate = 
  (printer: ComputerResponse, filter: string) => printer.name.indexOf(filter) != -1;
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

  filterData(){
    this.show = true
    const cpu = this.form.value.cpu as string
    const os = this.form.value.os as string
    var afterFilter;

    if (typeof(this.form.value.ram) === "number"){
      const ram = this.form.value.ram as number
      afterFilter = this.rawData.filter(pc => pc.cpu.includes(cpu) && pc.ram == ram && pc.os.includes(os))

    }else{
      afterFilter = this.rawData.filter(pc => pc.cpu.includes(cpu) && pc.os.includes(os))
    }

    
    this.data = new MatTableDataSource<ComputerResponse>(afterFilter);
    this.data.sort = this.sort;
    this.data.paginator = this.paginator
    this.data.filterPredicate = 
    (printer: ComputerResponse, filter: string) => printer.name.indexOf(filter) != -1;
  }

  resetFilter(){
    this.show = false
    this.data = new MatTableDataSource<ComputerResponse>(this.rawData);
    this.data.sort = this.sort;
    this.data.paginator = this.paginator
  }

  sortData(sort: Sort){
    if (sort.active == "cpu"){
      this.sortByCPU()
    }else if(sort.active == "ram"){
      this.sortByRAM()
    }

    if(sort.direction == ""){
      this.sortByID()
    }

  }

  sortByID(){
    this.data.data.sort((a,b) => {
      const e1 = a.id
      const e2 = b.id

      return e1 < e2 ? -1 : 1
    });
  }

  sortByCPU(){
    this.data.data.sort((a,b) => {
      const e1 = a.cpuScore
      const e2 = b.cpuScore

      return e1 < e2 ? -1 : 1
    });
  }

  sortByRAM(){
    this.data.data.sort((a,b) => {
      const e1 = a.ram
      const e2 = b.ram

      return e1 < e2 ? -1 : 1
    });
  }

  applyFilter() {
    let filterValue: string = this.searchForm.value.search
    this.data.filter = filterValue.toUpperCase();
  }

}
