import { Component, Input, OnInit } from '@angular/core';
import { log } from 'src/app/Models/Computer';

@Component({
  selector: 'app-pc-log',
  templateUrl: './pc-log.component.html',
  styleUrls: ['./pc-log.component.css']
})
export class PcLogComponent implements OnInit {
  @Input() log: log;

  constructor() { }

  ngOnInit(): void {

  }

}
