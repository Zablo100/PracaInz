import { InvoiceItemRequest, Item } from "./Item";

export interface Invoice {
    id: number;
    name: string;
    seller: string;
    date: string;
    items: Item[];
    totalCost: number;
}

export interface PrinterInvoiceRequest{
    fv: string,
    itemRequest: InvoiceItemRequest
}