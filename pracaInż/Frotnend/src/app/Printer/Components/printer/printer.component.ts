import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { map, Observable, Subscription } from 'rxjs';
import { PrinterService } from '../../printer.service';
import { MatDialog } from '@angular/material/dialog';
import { GenerateInvoiceComponent } from '../generate-invoice/generate-invoice.component';
import { Printer } from '../../../Models/Printer';

@Component({
  selector: 'app-printer',
  templateUrl: './printer.component.html',
  styleUrls: ['./printer.component.css']
})
export class PrinterComponent implements OnInit {
  PageLoaded: boolean = true
  displayedColumns: string[] = ["department", "serialNumber","description", 'InvoiceDescription','manufacturer', "model", "ip", "contractNumber", "options"];
  data: MatTableDataSource<Printer>;
  private printers: Printer[]
  SearchForm: FormGroup
  
  
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private service: PrinterService, private matDialog: MatDialog) { }

  ngOnInit(): void {
    this.getDataToTable()

    this.createSearchForm()
    
  }

  getDataToTable(){
    this.service.getArcusPrinters().subscribe((reponse) => {
      this.data = new MatTableDataSource<Printer>(reponse as Printer[]);
      this.printers = reponse as Printer[];
      this.data.paginator = this.paginator
      this.data.filterPredicate = 
  (printer: Printer, filter: string) => printer.serialNumber.indexOf(filter) != -1;
    })
  }

  createSearchForm() {
    this.SearchForm = new FormGroup({
      search: new FormControl("")
    })
  }


  hasIP(ip: any): boolean{
    if (ip == 'Brak'){
      return false
    }
    
    return true
  }

  addPrinterCheck(id: number){
    this.service.changeStauts(id)
    const index = this.printers.findIndex(p => p.id == id)
    console.log(this.printers)
    this.printers[index].monthlyCheck = true;
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
    this.printers[index].monthlyCheck = false;
    this.data.data = this.printers
  }

  cleareAllPrintersStatus(){
    this.printers.forEach(printer => {
      printer.monthlyCheck = false
    });
    this.service.cleareAll()
    this.data.data = this.printers
  }

  openEditWindow(id: any){

  }

  openDeletWindow(id: any){

  }

  search(){
    const query: string = this.SearchForm.value.search
    if(query){
      this.service.searchPrinter(query).subscribe((response) => {
        this.data = new MatTableDataSource<Printer>(response as Printer[]);
        this.printers = response as Printer[];
        this.data.paginator = this.paginator
        this.data.filterPredicate = 
        (printer: Printer, filter: string) => printer.serialNumber.indexOf(filter) != -1;
      })
    }else{
      this.getDataToTable()
    }
  }
}
