import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Printer } from '../Models/Printer';
import { PrinterInvoiceRequest } from '../Models/invoice';
import { app } from '../Core/appip';

@Injectable({
  providedIn: 'root'
})
export class PrinterService {
  constructor(private http: HttpClient) { }
  
  getArcusPrinters(){
    return this.http.get(`https://${app.ip}/api/printers/GetArcusPrinters`)
  }

  changeStauts(id: number){
    const body = {}
    const headers = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }

    this.http.put(`https://${app.ip}/api/printers/ChangePrinterStatus/` + id, body, headers).subscribe((response) => {
      console.log(response)    
    })
  }

  cleareAll(){
    const body = {}
    const headers = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
    this.http.post(`https://${app.ip}/api/printers/ClearAllPrintersStatus`, body, headers).subscribe((response) => {
      
    })
  }

  createInvoice(request: PrinterInvoiceRequest){
    this.http.put(`http://${app.ip}/api/v1/printer/invoice`, request).subscribe((response) => {
      //window.location.reload()
    })
  }

  deleteArcusPrinter(id: number){
    this.http.delete(`https://${app.ip}/api/printers/DeletArcusPrinter` + id, )
  }

}
