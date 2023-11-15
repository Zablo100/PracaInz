import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { DepartmentSelectDTO } from 'src/app/Models/Department';
import { InventoryService } from '../../inventory.service';
import { ToastrService } from 'ngx-toastr';
import { getErrorMessage } from 'src/app/Core/appip';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-add-inventory-window',
  templateUrl: './add-inventory-window.component.html',
  styleUrls: ['./add-inventory-window.component.css']
})
export class AddInventoryWindowComponent implements OnInit {
  AddForm: FormGroup;
  DepartmentsSelect: DepartmentSelectDTO[];
  constructor(private service: InventoryService, private notification: ToastrService, private dialogRef: MatDialogRef<AddInventoryWindowComponent>) { }

  async ngOnInit(): Promise<void> {
    this.createForm()
    await this.getDepartmentsList()
  }

  createForm(){
    this.AddForm = new FormGroup({
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

  async getDepartmentsList(){
    this.service.getDapartmentsForSelect().subscribe((response) => {
      this.DepartmentsSelect = response as DepartmentSelectDTO[];
    }, (err) => {
      this.notification.error(getErrorMessage(err))
    })
  }

  submit(){
    const body = {
      name: this.AddForm.value.name,
      description: this.AddForm.value.description,
      type: parseInt(this.AddForm.value.type),
      departmentId: parseInt(this.AddForm.value.departmentId),
      fixedAssetClassification: this.AddForm.value.fixedAssetClassification,
      inventoryNumber: this.AddForm.value.inventoryNumber,
      inventoryBookNumber: this.AddForm.value.inventoryBookNumber,
      amount: this.AddForm.value.amount,
      yearOfPurches: this.AddForm.value.yearOfPurches,
      orginalPrice: this.AddForm.value.orginalPrice
    }

    this.service.addNewAsset(body).subscribe(() => {
      this.notification.success("Pomyślnie dodano nową pozycje w arkuszy inwentarzowym")
      this.dialogRef.close()
    }, (err) => this.notification.error(getErrorMessage(err)))
  }

}
