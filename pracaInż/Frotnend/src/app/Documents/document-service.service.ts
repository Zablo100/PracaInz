import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { app } from '../Core/appip';

@Injectable({
  providedIn: 'root'
})
export class DocumentServiceService {
  private baseUrl = `https://${app.ip}`


  constructor(private http: HttpClient) { }

  getAllDocs(){
    return this.http.get(`${this.baseUrl}/Document/GetAlldocuments`)
  }
}
