import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { app } from '../Core/appip';

@Injectable({
  providedIn: 'root'
})
export class InventoryService {
  baseURL = `https://${app.ip}/api/Inventory`
  constructor(private http: HttpClient) { }

  getItems(){
    return this.http.get(`${this.baseURL}/GetInventoryAssets`)
  }
}
