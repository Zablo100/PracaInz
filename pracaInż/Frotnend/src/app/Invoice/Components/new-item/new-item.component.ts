import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { InvoiceItemRequest, Item } from 'src/app/Models/Item';

@Component({
  selector: 'app-new-item',
  templateUrl: './new-item.component.html',
  styleUrls: ['./new-item.component.css']
})
export class NewItemComponent implements OnInit {
  @Output() public submitItem: EventEmitter<any> = new EventEmitter();
  @Input() send: any;
  itemForm: FormGroup;

  constructor() { }

  ngOnInit(): void {
    this.createForm()
  }

  createForm() {
    this.itemForm = new FormGroup({
      name: new FormControl(""),
      description: new FormControl(""),
      quantity: new FormControl(""),
      price: new FormControl("")
    })
  }

  ngOnChanges(){
    if (this.send){
      this.submitItemRequest()
    }
  }

  submitItemRequest(){
    const data = this.itemForm.value as InvoiceItemRequest
    this.submitItem.emit(data)
  }

}
