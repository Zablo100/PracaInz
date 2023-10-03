import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeeService } from '../../employee.service';
import { Employee } from '../../../Models/Employee';
import { PcStatus } from '../../../Models/PcStatus';

@Component({
  templateUrl: './employee-page.component.html',
  styleUrls: ['./employee-page.component.css']
})
export class EmployeePageComponent implements OnInit {
  public employee: Employee

  constructor(private service: EmployeeService, private router: Router) { }

  ngOnInit(): void {
    this.service.getEmployeeById(Number(this.router.url.substring(10))).subscribe(data =>{
      this.employee = data as Employee
    })


  }

  getStauts(): string{

    return "Offline"
  }


}
