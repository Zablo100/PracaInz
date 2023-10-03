import { Component, ComponentRef, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { NewItemComponent } from '../new-item/new-item.component';
import { Subscription } from 'rxjs';
import { InvoiceItemRequest } from 'src/app/Models/Item';
import { FormControl, FormGroup } from '@angular/forms';
import { InvoiceService } from '../../invoice.service';

@Component({
  selector: 'app-new-invoice',
  templateUrl: './new-invoice.component.html',
  styleUrls: ['./new-invoice.component.css']
})
export class NewInvoiceComponent implements OnInit {
  @ViewChild('container', {read: ViewContainerRef}) container: ViewContainerRef;
  send = false;
  componenets: any[] = [];
  items: InvoiceItemRequest[] = [];
  form: FormGroup;
  
  constructor(private service: InvoiceService) { }

  ngOnInit(): void {
    this.createForm()
  }

  createForm() {
    this.form = new FormGroup({
      name: new FormControl(""),
      seller: new FormControl("")
    })
  }

  addComponent(){
    const component = this.container.createComponent(NewItemComponent);
    component.setInput("send",this.send)
    const sub: Subscription = component.instance.submitItem.subscribe((event) => {
      this.getDataFormChild(event)
    })
    component.onDestroy(() => sub.unsubscribe())
    this.componenets.push(component)

  }

  removeComponent(){
    const last = this.container.length -1
    this.container.remove(last)
  }


  createNewInvoice(){
    this.send = true;
    for(let e of this.componenets){
      e.setInput("send", true)
    }
  }

  getDataFormChild(data: InvoiceItemRequest){
    this.items.push(data)
    if (this.items.indexOf(data) === -1){
      this.items.push(data)
    }

    this.test()
  }

  test(){
    const itemsCount = this.componenets.length
    if (itemsCount == this.items.length){
      this.createInvoiceRequest();
    }
  }

  createInvoiceRequest(){
    var body = {
      name: this.form.value.name,
      seller: this.form.value.seller,
      items: this.items
    }

    //console.log(body)
    this.service.create(body).subscribe(() => {
      //window.location.reload()
    })
  }


}
