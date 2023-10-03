import { Component, Inject, Input, OnInit } from '@angular/core';
import { Invoice } from 'src/app/Models/invoice';
import { InvoiceService } from '../../invoice.service';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.css']
})
export class InvoiceComponent implements OnInit {
  invoice: Invoice
  PageLoaded: boolean = false

  constructor(private service: InvoiceService, @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    this.service.getById(this.data.invoiceId).subscribe((response) => {
      this.invoice = response as Invoice
      this.PageLoaded = true
    })
  }
  

}
