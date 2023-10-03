import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { PrinterInvoiceRequest } from 'src/app/Models/invoice';
import { PrinterService } from '../../printer.service';

@Component({
  selector: 'app-generate-invoice',
  templateUrl: './generate-invoice.component.html',
  styleUrls: ['./generate-invoice.component.css']
})
export class GenerateInvoiceComponent implements OnInit {
  form: FormGroup;
  error = false;
  erroDescription: string;


  constructor(private matDialog: MatDialog,@Inject(MAT_DIALOG_DATA) public data: any, private service: PrinterService) { }

  ngOnInit(): void {

    this.createForm()
  }

  createForm() {
    this.form = new FormGroup({
      cost: new FormControl(""),
      name: new FormControl("")
    })
  }

  test(){
    this.validate(this.form.value)
  }

  validate(input: any){
    let x = input.cost.replace(',', '.')
    let y = x.split(".");

    if (isNaN(x)){
      this.showError()
      return;
    }

    if (this.isInt(y)){
      this.submitRequest();
      return;
    }

    if (this.validateDecimal(y)){
      this.submitRequest();
      return;
    }
    
    this.showError()
  }

  isInt(input: any){
    if (input.length == 1 ){
      return true;
    }

    return false
  }

  validateDecimal(input: any){
    if (input[1].length <= 2){
      return true
    }

    return false
  }

  showError(){
    this.error = true
    this.erroDescription = "Podany koszt jest nieprawdłową liczbą"
  }

  submitRequest(){

    let request: PrinterInvoiceRequest = {
      fv: this.form.value.name.toUpperCase(),
      itemRequest: {
        name: "Dzierżawa drukarki",
        description: `Opłata za drukarkę ${this.data.printer.description}`,
        quantity: 1,
        price: parseFloat(this.form.value.cost.replace(",", "."))
      }
    }

    this.service.createInvoice(request);
    this.matDialog.closeAll()
  }

}
