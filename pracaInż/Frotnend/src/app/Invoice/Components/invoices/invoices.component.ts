import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Observable, Subscription } from 'rxjs';
import { Invoice } from 'src/app/Models/invoice';
import { InvoiceService } from '../../invoice.service';
import { MatDialog } from '@angular/material/dialog';
import { InvoiceComponent } from '../invoice/invoice.component';
import { NewInvoiceComponent } from '../new-invoice/new-invoice.component';
import { getErrorMessage } from 'src/app/Core/appip';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-invoices',
  templateUrl: './invoices.component.html',
  styleUrls: ['./invoices.component.css']
})
export class InvoicesComponent implements OnInit {
  displayedColumns: string[] = ['Numer', "Sprzedawca", "Data wystawienia", "Całkowity koszt"];
  data: MatTableDataSource<Invoice>;
  PageLoaded: boolean = false
  Daty = []
  Dane = []
  
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private service: InvoiceService, private matDialog: MatDialog) { }

  ngOnInit(): void {
    this.getDataForChart()
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
      autoFocus: false,
    });
  }

  getDataForChart(){
    this.service.getMoneySpend().subscribe((response) => {
      console.log(response)
      const lista = response as []
      lista.forEach(element => {
        this.Daty.push(element[0])
        this.Dane.push(element[1])
      });
      console.log(this.Dane)
      console.log(Math.max(...this.Dane as number[]))
      this.createChart()
    })
  }

  createChart(){
    new Chart("myChart", {
      type: 'bar',
      data: {
        labels: this.Daty,
        datasets: [{
          label: 'Wydatki',
          data: this.Dane,
          backgroundColor: ['#e63946',],
          borderWidth: 1
        }]
      },
      options: {
        scales: {
          y: {
            beginAtZero: true,
            max: Math.ceil(Math.max(...this.Dane)/1000)*1000,
            ticks: {
              stepSize: 500
            }
          },
          x: {
            max: 12
          }
        }
      }
    });
  }
}
