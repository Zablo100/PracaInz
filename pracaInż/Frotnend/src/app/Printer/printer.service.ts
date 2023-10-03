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
  private printers$ = new BehaviorSubject<Printer[]>([])


  constructor(private http: HttpClient) { }
  

  // reaktywne
  getAllRX(): Observable<Printer[]> {
    return this.printers$
  }

  public init(): void{
    this.http
      .get<Printer[]>("https://192.168.1.224:4040/api/v1/Printer/getAll")
      .subscribe((printer) => {
        this.printers$.next(printer)
      })
  }

  getAll(){
    return this.http.get(`http://${app.ip}/api/v1/printer/all`)
  }

  changeStauts(id: number){
    const body = {}
    const headers = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
    this.http.patch(`http://${app.ip}/api/v1/printer/changeStatus/` + id, body, headers).subscribe((response) => {
      
    })
  }

  cleareAll(){
    const body = {}
    const headers = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
    this.http.patch(`http://${app.ip}/api/v1/printer/cleare`, body, headers).subscribe((response) => {
      
    })
  }

  createInvoice(request: PrinterInvoiceRequest){
    this.http.put(`http://${app.ip}/api/v1/printer/invoice`, request).subscribe((response) => {
      //window.location.reload()
    })
  }

}
