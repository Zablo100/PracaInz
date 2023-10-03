import { Component, Input, OnInit } from '@angular/core';
import { log, logSummary } from 'src/app/Models/Computer';
import { Chart } from 'chart.js/auto';
import { ComputerService } from '../../computer.service';
import { ActivatedRoute, Route } from '@angular/router';

@Component({
  selector: 'app-pc-log-chart',
  templateUrl: './pc-log-chart.component.html',
  styleUrls: ['./pc-log-chart.component.css']
})
export class PcLogChartComponent implements OnInit {
  pcLogs: logSummary[]
  dates: string[] = []
  count: number[] = []
  max: number;

  constructor(private service: ComputerService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getData()

  }

  getData(){
      const id = this.route.snapshot.paramMap.get('id')
      this.service.getPcLogSummary(id).subscribe((response) => {
        this.pcLogs = response as logSummary[]
        
        this.mapData()
        this.createChart()
      })
  }

  mapData(){
    for(const log of this.pcLogs){
      this.dates.push(log.month)
      this.count.push(log.count)
    }

    this.max = Math.max(...this.count) + 1

  }


  createChart(){
    new Chart("myChart", {
      type: 'bar',
      data: {
        labels: this.dates,
        datasets: [{
          label: 'Ilość interwencji',
          data: this.count,
          borderWidth: 1
        }]
      },
      options: {
        scales: {
          y: {
            beginAtZero: true,
            max: this.max,
            ticks: {
              stepSize: 1
            }
          },
          x: {
            max: 4
          }
        }
      }
    });
  }
}

