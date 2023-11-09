import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../../employee.service';
import { Employee } from '../../../Models/Employee';
import { PcStatus } from '../../../Models/PcStatus';
import { ToastrService } from 'ngx-toastr';

@Component({
  templateUrl: './employee-page.component.html',
  styleUrls: ['./employee-page.component.css']
})
export class EmployeePageComponent implements OnInit {
  public employee: Employee

  constructor(private service: EmployeeService, private route: ActivatedRoute, private notification: ToastrService) { }

  ngOnInit(): void {
    this.getDataFromAPI()
  }

  getDataFromAPI(){
    const id = this.route.snapshot.paramMap.get('id')
    if (id != null){
      this.service.getEmployeeById(id).subscribe((response) => {
        this.employee = response as Employee
        console.log(this.employee)
      }, (err) => {
        this.notification.error(err.error.description)
      })
    }
  }

  getStauts(): string{

    return "Offline"
  }


}
