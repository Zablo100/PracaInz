import { Component, OnInit } from '@angular/core';
import { Chart } from 'chart.js';
import { EmployeeService } from 'src/app/Employees/employee.service';
import { Employee } from 'src/app/Models/Employee';
import { TicketService } from 'src/app/Tickets/ticket.service';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})
export class UserPageComponent implements OnInit {
  public employee: Employee
  Custom: boolean = false
  Daty = []
  Dane = []
  
  constructor(private service: EmployeeService) { }

  ngOnInit(): void {
    this.getDataForChart()
  }

  getData(){

  }

  customPc(){
    this.Custom = !this.Custom
  }

  getDataForChart(){
    const id = '1231241'
    this.service.getSummaryById(id).subscribe((response => {
      console.log(response)
      const lista = response as []
      lista.forEach(element => {
        this.Daty.push(element[0])
        this.Dane.push(element[1])
      });
      this.createChart()
    }))
  }

  createChart(){
    new Chart("myChart", {
      type: 'bar',
      data: {
        labels: this.Daty,
        datasets: [{
          label: 'Twoje zgłoszeń w tym roku',
          data: this.Dane,
          borderWidth: 1
        }]
      },
      options: {
        scales: {
          y: {
            beginAtZero: true,
            max: Math.ceil(Math.max(...this.Dane) +1),
            ticks: {
              stepSize: 1
            }
          },
          x: {
            max: 12
          }
        }
      }
    });
  }
}
