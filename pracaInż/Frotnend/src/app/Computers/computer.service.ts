import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { app } from '../Core/appip';

@Injectable({
  providedIn: 'root'
})
export class ComputerService {
  url: string = `https://${app.ip}`;

  constructor(private http: HttpClient) { }

  getPcList(page: number){
    return this.http.get(`${this.url}/Computers/GetComputers?page=${page}`)
  }

  getByID(id: string | null){
    return this.http.get(`${this.url}/Computers/GetById/${id}`)
  }

  getPcLogsById(id: string | null){
    return this.http.get(`${this.url}/Computers/GetLogsByPc/${id}`)
  }

  addPcLog(body: any){
    return this.http.post(`${this.url}/Computers/AddLogs`, body)
  }

  addTicket(body: any){
    return this.http.post(`${this.url}/Ticket/SubmitTicket`, body)
  }

}
