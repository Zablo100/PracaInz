export interface Item {
    id: number;
    name: string;
    quantity: number;
    description: string;
    price: number;
}

export interface InvoiceItemRequest {
    name: string,
    quantity: number,
    description: string, 
    price: number
}