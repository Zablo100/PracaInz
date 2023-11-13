import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../../employee.service';
import { Employee } from '../../../Models/Employee';
import { PcStatus } from '../../../Models/PcStatus';
import { Chart } from 'chart.js/auto';
import { ToastrService } from 'ngx-toastr';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { EmployeeEditWindowComponent } from '../employee-edit-window/employee-edit-window.component';

@Component({
  templateUrl: './employee-page.component.html',
  styleUrls: ['./employee-page.component.css']
})
export class EmployeePageComponent implements OnInit {
  public employee: Employee

  constructor(private service: EmployeeService, private route: ActivatedRoute, 
    private notification: ToastrService, private matDialog: MatDialog) { }

  ngOnInit(): void {
    this.getDataFromAPI()
    this.createChart()
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

  createChart(){
    const daty = ["Styczeń", "Luty", "Marzec", "Kwiecień", "Maj", "Czerwiec", "Lipiec", "Sierpień", "Wrzesień", "Październik", "Listopad", "Grudzień"]
    const dane = [2,5,2,7,5,4,3,2,1,0,0,3]
    new Chart("myChart", {
      type: 'bar',
      data: {
        labels: daty,
        datasets: [{
          label: 'Ilość zgłoszeń',
          data: dane,
          borderWidth: 1
        }]
      },
      options: {
        scales: {
          y: {
            beginAtZero: true,
            max: 8,
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
}
