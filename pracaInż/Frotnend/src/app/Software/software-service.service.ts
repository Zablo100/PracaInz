import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { app, getErrorMessage } from '../Core/appip';
import { ToastrService } from 'ngx-toastr';
import { Software } from '../Models/Software';

@Injectable({
  providedIn: 'root'
})
export class SoftwareServiceService {
  private baseUrl = `https://${app.ip}`
  
  constructor(private http: HttpClient) { }

  getSoftwareList(){
    return this.http.get(`${this.baseUrl}/Software/GetAllSoftwareList`)
  }

}
