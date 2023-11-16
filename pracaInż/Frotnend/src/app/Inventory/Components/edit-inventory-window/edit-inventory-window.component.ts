import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DepartmentSelectDTO } from 'src/app/Models/Department';
import { InventoryAsset } from 'src/app/Models/Inventory';
import { InventoryService } from '../../inventory.service';
import { ToastrService } from 'ngx-toastr';
import { getErrorMessage } from 'src/app/Core/appip';

@Component({
  selector: 'app-edit-inventory-window',
  templateUrl: './edit-inventory-window.component.html',
  styleUrls: ['./edit-inventory-window.component.css']
})
export class EditInventoryWindowComponent implements OnInit {
  EditForm: FormGroup;
  Asset: any
  DepartmentsSelect: DepartmentSelectDTO[];
  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    private service: InventoryService, private notification: ToastrService, private dialogRef: MatDialogRef<EditInventoryWindowComponent>) { }

  async ngOnInit(): Promise<void> {
    this.createForm()
    await this.getDepartmentsList()
    await this.loadData()
  }

  loadData() {
    this.service.getAssetById(this.data.AssetId).subscribe((response) => {
      this.Asset = response
      this.fillform()
    }, (err) => this.notification.error(getErrorMessage(err)))
  }

  
  async getDepartmentsList(){
    this.service.getDapartmentsForSelect().subscribe((response) => {
      this.DepartmentsSelect = response as DepartmentSelectDTO[];
    }, (err) => {
      this.notification.error(getErrorMessage(err))
    })
  }

  
  createForm() {
    this.EditForm = new FormGroup({
      name: new FormControl(''),
      description: new FormControl(''),
      type: new FormControl(''),
      departmentId: new FormControl(''),
      fixedAssetClassification: new FormControl(''),
      inventoryNumber: new FormControl(''),
      inventoryBookNumber: new FormControl(''),
      amount: new FormControl(''),
      yearOfPurches: new FormControl(''),
      orginalPrice: new FormControl('')
    })
  }

  fillform(){
    this.EditForm = new FormGroup({
      name: new FormControl(this.Asset.name),
      description: new FormControl(this.Asset.description),
      type: new FormControl(this.Asset.type.toString()),
      departmentId: new FormControl(this.Asset.departmentId.toString()),
      fixedAssetClassification: new FormControl(this.Asset.fixedAssetClassification),
      inventoryNumber: new FormControl(this.Asset.inventoryNumber),
      inventoryBookNumber: new FormControl(this.Asset.inventoryBookNumber),
      amount: new FormControl(this.Asset.amount),
      yearOfPurches: new FormControl(this.Asset.yearOfPurches),
      orginalPrice: new FormControl(this.Asset.orginalPrice)
    })
  }

  submit(){
    const body = {
      name: this.EditForm.value.name,
      description: this.EditForm.value.description,
      type: parseInt(this.EditForm.value.type),
      departmentId: parseInt(this.EditForm.value.departmentId),
      fixedAssetClassification: this.EditForm.value.fixedAssetClassification,
      inventoryNumber: this.EditForm.value.inventoryNumber,
      inventoryBookNumber: this.EditForm.value.inventoryBookNumber,
      amount: this.EditForm.value.amount,
      yearOfPurches: this.EditForm.value.yearOfPurches,
      orginalPrice: this.EditForm.value.orginalPrice
    }

    this.service.updateAsset(body).subscribe(() => {
      this.notification.success("Pomyślnie zaktualizowano pozycje w arkuszy inwentarzowym")
      this.dialogRef.close()
    }, (err) => this.notification.error(getErrorMessage(err)))
  }

}


