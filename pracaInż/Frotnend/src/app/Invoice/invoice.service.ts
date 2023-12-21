import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Invoice } from '../Models/invoice';
import { app } from '../Core/appip';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  constructor(private http: HttpClient) { }

  public getAll(){
    return this.http.get(`https://${app.ip}/api/invoice/GetAll`)
  }

  getById(id: number){
    return this.http.get(`https://${app.ip}/api/invoice/GetById/`+id)
  }

  public getMoneySpend(){
    return this.http.get(`https://${app.ip}/api/Invoice/TotalMoneySpendInYear/`)
  }

  public create(body : any){
    return this.http.put(`http://${app.ip}/api/v1/invoice/new`, body)
  }

}
