import { Component, Input, OnInit } from '@angular/core';
import { Chart } from 'chart.js/auto';
import { ComputerService } from '../../computer.service';
import { ActivatedRoute, Route } from '@angular/router';

@Component({
  selector: 'app-pc-log-chart',
  templateUrl: './pc-log-chart.component.html',
  styleUrls: ['./pc-log-chart.component.css']
})
export class PcLogChartComponent implements OnInit {
  dates: string[] = []
  count: number[] = []
  max: number;

  constructor(private service: ComputerService, private route: ActivatedRoute) { }

  ngOnInit(): void {

  }


}

