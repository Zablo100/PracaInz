import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { app } from '../Core/appip';

@Injectable({
  providedIn: 'root'
})
export class ComputerService {
  url: string = `http://${app.ip}/api/computer`;

  constructor(private http: HttpClient) { }

  getAll(){
    return this.http.get(`${this.url}/all`)
  }

  getByID(id: string | null){
    return this.http.get(`${this.url}/get/${id}`)
  }

  getPcLogsById(id: string | null){
    return this.http.get(`${this.url}/get/log/${id}`)
  }

  getPcLogSummary(id: string | null){
    return this.http.get(`${this.url}/get/log/summary/${id}`)
  }

}
