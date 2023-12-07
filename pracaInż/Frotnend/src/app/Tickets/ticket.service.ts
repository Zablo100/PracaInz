import { Injectable } from '@angular/core';
import { app } from '../Core/appip';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TicketService {
  private baseUrl = `https://${app.ip}`

  constructor(private http: HttpClient) { }

  getDataFromAPI(){
    return this.http.get(`${this.baseUrl}/Ticket/GetAllTickets`)
  }

  getDataById(id: number){
    return this.http.get(`${this.baseUrl}/Ticket/GetTicketById/` + id)
  }

  addCommentToTicket(body: any){
    return this.http.post(`${this.baseUrl}/Ticket/AddCommentToTicket`, body)
  }
}
