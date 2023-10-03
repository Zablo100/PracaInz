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
    return this.http.get(`http://${app.ip}/api/v1/invoice`)
  }

  getById(id: number){
    return this.http.get(`http://${app.ip}/api/v1/invoice/`+id)
  }

  public create(body : any){
    return this.http.put(`http://${app.ip}/api/v1/invoice/new`, body)
  }

}
