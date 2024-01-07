import { Injectable } from '@angular/core';
import { app } from '../Core/appip';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TicketService {
  private baseUrl = `https://${app.ip}`

  constructor(private http: HttpClient) { }

  getDataFromAPI(page: number){
    return this.http.get(`${this.baseUrl}/Ticket/GetAllTickets?page=`+page)
  }

  getDataById(id: number | string | null){
    return this.http.get(`${this.baseUrl}/Ticket/GetTicketById/` + id)
  }

  addCommentToTicket(body: any){
    return this.http.post(`${this.baseUrl}/Ticket/AddCommentToTicket`, body)
  }

  getByPerson(id: string | null){
    return this.http.get(`${this.baseUrl}/Ticket/GetByPreson/` + id)
  }

  getByPc(id: string | null){
    return this.http.get(`${this.baseUrl}/Ticket/GetByPc/` + id)
  }
}
