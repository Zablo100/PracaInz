import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { EmployeeService } from '../employee.service';
import { Employee } from '../../Models/Employee';
import {MatTabsModule} from '@angular/material/tabs';

@Component({
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})

/*
TODO:
  * Inny sposób na sortowanie, a nie do każdej kolumnu osobna funkcja
  * Timer na dodanie obiektu sort to dataSource (Trzeba poprawić???)
*/
export class DashboardComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {

  }




}
