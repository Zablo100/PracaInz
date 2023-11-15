import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { InventoryAsset } from 'src/app/Models/Inventory';
import { InventoryService } from '../../inventory.service';
import { ToastrService } from 'ngx-toastr';
import { MatPaginator } from '@angular/material/paginator';
import { getErrorMessage } from 'src/app/Core/appip';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { AddInventoryWindowComponent } from '../../Components/add-inventory-window/add-inventory-window.component';

@Component({
  templateUrl: './inventory-page.component.html',
  styleUrls: ['./inventory-page.component.css']
})
export class InventoryPageComponent implements OnInit {
  SearchForm: FormGroup = new FormGroup({search: new FormControl()});
  PageLoaded: boolean = false;
  data: MatTableDataSource<InventoryAsset>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  displayedColumns = [ "Icon" ,"InventoryNumber", "FixedAssetClassification", "Description", "BuyingUnit", "CostPosition", "InventoryBookNumber", 
  "OrginalPrice", "Amount", "Name" ,"YearOfPurches" ,"options"]


  constructor(private service: InventoryService, private notification: ToastrService, private matDialog: MatDialog) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData(){
    this.service.getItems().subscribe((response) => {
      this.data = new MatTableDataSource<InventoryAsset>(response as InventoryAsset[])
      this.data.paginator = this.paginator;
      this.PageLoaded = true; 
      console.log(this.data)
    }, (err) => this.notification.error(getErrorMessage(err)))
  }

  submit(){

  }

  openCreateWindow(){
    let dialog: MatDialogRef<AddInventoryWindowComponent> = this.matDialog.open(AddInventoryWindowComponent, {
      "autoFocus": false,
      enterAnimationDuration: "180ms",
    });

    dialog.afterClosed().subscribe(async () => {
      await this.loadData();
    })
  }

  openEditWindow(id: any){

  }

  openDeletWindow(id: any){

  }
}
