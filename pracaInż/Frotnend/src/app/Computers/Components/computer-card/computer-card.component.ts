import { Component, Input, OnInit } from '@angular/core';
import { ComputerCard } from 'src/app/Models/Computer';

@Component({
  selector: 'app-computer-card',
  templateUrl: './computer-card.component.html',
  styleUrls: ['./computer-card.component.css']
})
export class ComputerCardComponent implements OnInit {
  @Input() data: ComputerCard;

  constructor() { }

  ngOnInit(): void {
  }

}
