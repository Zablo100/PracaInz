import { Component, OnInit } from '@angular/core';
import { ComputerService } from '../../computer.service';
import { Computer, ComputerDTO, pcLog } from 'src/app/Models/Computer';
import { MatExpansionPanel, MatAccordion } from '@angular/material/expansion';
import { ActivatedRoute } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { NewLogFormComponent } from '../new-log-form/new-log-form.component';
import { ToastrService } from 'ngx-toastr';
import { getErrorMessage } from 'src/app/Core/appip';

@Component({
  templateUrl: './computer.component.html',
  styleUrls: ['./computer.component.css']
})
export class ComputerComponent implements OnInit {
  Computer: ComputerDTO
  PageLoaded: boolean = false
  PcLogs: pcLog[];

  constructor(private service: ComputerService, private route: ActivatedRoute, private MatDialog: MatDialog, private notification: ToastrService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id')
    this.service.getByID(id).subscribe((response) => {
      this.Computer = response as ComputerDTO
      this.PageLoaded = true
      console.log(this.Computer)
    })

    this.getLogs(id)
  }

  getLogs(id: string | null){
    this.service.getPcLogsById(id).subscribe((response) => {
      this.PcLogs = response as pcLog[]
    }, (err) => {
      console.log(err)
      if(err.status == 404){
        this.notification.info(getErrorMessage(err))
      }else{
        this.notification.error(getErrorMessage(err))
      }
    })
  }

  hasMonitors(){
    // if(this.Computer.monitors.length > 0){
    //   return true
    // }
    return false
  }

  isPC(){
    // if (this.Computer.model == "PC"){
    //   return true
    // }

    return true
  }

  openForm(){
    this.MatDialog.open(NewLogFormComponent, {
      data: {
        pcId: this.Computer.id
      }
    })
  }

}
