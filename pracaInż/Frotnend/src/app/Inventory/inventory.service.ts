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

  getDapartmentsForSelect(){
    return this.http.get(`https://${app.ip}/api/department/GetDepartmentsForSelectElement`)
  }

  addNewAsset(body: any){
    return this.http.post(`${this.baseURL}/AddNewAsset`, body)
  }

  getAssetById(id: number | string){
    return this.http.get(`${this.baseURL}/GetAssetById/` + id)
  }

  updateAsset(body: any){
    return this.http.put(`${this.baseURL}/UpdateAsset`, body)
  }
}
