import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Observable, Subscription } from 'rxjs';
import { Invoice } from 'src/app/Models/invoice';
import { InvoiceService } from '../../invoice.service';
import { MatDialog } from '@angular/material/dialog';
import { InvoiceComponent } from '../invoice/invoice.component';
import { NewInvoiceComponent } from '../new-invoice/new-invoice.component';

@Component({
  selector: 'app-invoices',
  templateUrl: './invoices.component.html',
  styleUrls: ['./invoices.component.css']
})
export class InvoicesComponent implements OnInit {
  displayedColumns: string[] = ['Numer', "Sprzedawca", "Data wystawienia", "Całkowity koszt"];
  data: MatTableDataSource<Invoice>;
  PageLoaded: boolean = false
  
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private service: InvoiceService, private matDialog: MatDialog) { }

  ngOnInit(): void {

    this.service.getAll().subscribe((invoice) => {
      console.log(invoice)
      this.data = new MatTableDataSource<Invoice>(invoice as Invoice[]);
      this.data.paginator = this.paginator
      this.PageLoaded = true
    })

  }

  open(e: any){
    console.log(e)
    const id = e
    this.matDialog.open(InvoiceComponent, {
      "autoFocus": false,
      data: {
        invoiceId: id,
      }
    });
  }

  openNewInvoiceform(){
    this.matDialog.open(NewInvoiceComponent, {
      "autoFocus": false,
    });
    
  }
}
