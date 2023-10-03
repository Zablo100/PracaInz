import { Component, OnInit } from '@angular/core';
import { ComputerService } from '../../computer.service';
import { Computer, log } from 'src/app/Models/Computer';
import { MatExpansionPanel, MatAccordion } from '@angular/material/expansion';
import { ActivatedRoute } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { NewLogFormComponent } from '../new-log-form/new-log-form.component';

@Component({
  templateUrl: './computer.component.html',
  styleUrls: ['./computer.component.css']
})
export class ComputerComponent implements OnInit {
  Computer: Computer
  PageLoaded: boolean = false
  PcLogs: log[];

  constructor(private service: ComputerService, private route: ActivatedRoute, private MatDialog: MatDialog) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id')
    this.service.getByID(id).subscribe((response) => {
      this.Computer = response as Computer
      this.PageLoaded = true
    })

    this.service.getPcLogsById(id).subscribe((response) => {
      this.PcLogs = response as log[]
    })
  }

  convertSpeed(speed: number){
    return speed/1000
  }

  hasMonitors(){
    if(this.Computer.monitors.length > 0){
      return true
    }

    return false
  }

  isPC(){
    if (this.Computer.model == "PC"){
      return true
    }

    return false
  }

  getTimeOfPurchase(){
    if (this.Computer.timeOfPurchase == null){
      return "Brak Danych"
    }

    const day = this.Computer.timeOfPurchase.slice(8,10)
    const month = this.Computer.timeOfPurchase.slice(5,7)
    const year = this.Computer.timeOfPurchase.slice(0,4)
    return `${day}-${month}-${year}`
  }

  openForm(){
    this.MatDialog.open(NewLogFormComponent, {
      data: {
        pcId: this.Computer.id
      }
    })
  }

}
