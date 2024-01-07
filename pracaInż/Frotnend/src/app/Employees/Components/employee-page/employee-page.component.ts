import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../../employee.service';
import { Employee } from '../../../Models/Employee';
import { PcStatus } from '../../../Models/PcStatus';
import { Chart } from 'chart.js/auto';
import { ToastrService } from 'ngx-toastr';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { EmployeeEditWindowComponent } from '../employee-edit-window/employee-edit-window.component';
import { EmployeeSoftwareWindowComponent } from '../employee-software-window/employee-software-window.component';

@Component({
  templateUrl: './employee-page.component.html',
  styleUrls: ['./employee-page.component.css']
})
export class EmployeePageComponent implements OnInit {
  public employee: Employee
  Daty = []
  Dane = []

  constructor(private service: EmployeeService, private route: ActivatedRoute, 
    private notification: ToastrService, private matDialog: MatDialog) { }

  ngOnInit(): void {
    this.getDataFromAPI()
    this.getDataForChart()
  }

  getDataFromAPI(){
    const id = this.route.snapshot.paramMap.get('id')
    if (id != null){
      this.service.getEmployeeById(id).subscribe((response) => {
        this.employee = response as Employee
      }, (err) => {
        this.notification.error(err.error.description)
      })
    }
  }

  getStauts(): string{

    return "Offline"
  }

  getDataForChart(){
    const id = this.route.snapshot.paramMap.get('id')
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
          label: 'Ilość zgłoszeń',
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

  openEditWindow(){
    const id = this.route.snapshot.paramMap.get('id')

    let dialog: MatDialogRef<EmployeeEditWindowComponent> = this.matDialog.open(EmployeeEditWindowComponent, {
      "autoFocus": false,
      enterAnimationDuration: "180ms",
      data: {
        EmployeeId: id,
      }
    });

    dialog.afterClosed().subscribe(async () => {
      await this.getDataFromAPI();
    })
  }

  test(){
    console.log("Tak")
  }

  openSoftwareWindow(){
    const id = this.route.snapshot.paramMap.get('id')
    let dialog: MatDialogRef<EmployeeSoftwareWindowComponent> = this.matDialog.open(EmployeeSoftwareWindowComponent, {
      "autoFocus": false,
      enterAnimationDuration: "180ms",
      data: {
        EmployeeId: id,
      }
    });

    dialog.afterClosed().subscribe(async () => {
      await this.getDataFromAPI();
    })
  }
}
