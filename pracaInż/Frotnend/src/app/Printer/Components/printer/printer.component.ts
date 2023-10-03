import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { map, Observable, Subscription } from 'rxjs';
import { Printer } from 'src/app/Models/Printer';
import { PrinterService } from '../../printer.service';
import { MatDialog } from '@angular/material/dialog';
import { GenerateInvoiceComponent } from '../generate-invoice/generate-invoice.component';

@Component({
  selector: 'app-printer',
  templateUrl: './printer.component.html',
  styleUrls: ['./printer.component.css']
})
export class PrinterComponent implements OnInit {
  displayedColumns: string[] = ["department", "serialNumber","description", 'InvoiceDescription','manufacturer', "model", "ip", "contractNumber", "options"];
  data: MatTableDataSource<Printer>;
  private printers: Printer[]
  searchForm: FormGroup
  
  
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private service: PrinterService, private matDialog: MatDialog) { }

  ngOnInit(): void {
    this.getDataToTable()

    this.createSearchForm()
    
  }

  getDataToTable(){
    this.service.getAll().subscribe((reponse) => {
      this.data = new MatTableDataSource<Printer>(reponse as Printer[]);
      this.printers = reponse as Printer[];
      this.data.paginator = this.paginator
      this.data.filterPredicate = 
  (printer: Printer, filter: string) => printer.serialNumber.indexOf(filter) != -1;
    })
  }

  createSearchForm() {
    this.searchForm = new FormGroup({
      search: new FormControl("", Validators.required)
    })
  }


  hasIP(ip: any): boolean{
    if (ip == null){
      return false
    }
    
    return true
  }

  applyFilter() {
    let filterValue = this.searchForm.value.search.toUpperCase()
    this.data.filter = filterValue;
  }

  addPrinterCheck(id: number){
    this.service.changeStauts(id)
    const index = this.printers.findIndex(p => p.id == id)
    this.printers[index].test = true;
    this.data.data = this.printers

    // this.matDialog.open(GenerateInvoiceComponent, {
    //   "autoFocus": false,
    //   data: {
    //     printer: this.printers[index],
    //   }
    // });
  }

  deletPrinterCheck(id: number){
    this.service.changeStauts(id)
    const index = this.printers.findIndex(p => p.id == id)
    this.printers[index].test = false;
    this.data.data = this.printers
  }

  cleareAllPrintersStatus(){
    this.printers.forEach(printer => {
      printer.test = false
    });
    this.service.cleareAll()
    this.data.data = this.printers
  }



}
