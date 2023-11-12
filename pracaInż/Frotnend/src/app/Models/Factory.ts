export interface Factory {
    id: number;
    city: string;
    street: string;
    streetNumber: number;
    postalCode: string;
}

export interface SelectFactoryDTO{
    id: number;
    city: string;
}

export interface AddFactoryDTO{
    city: string;
    Street: string;
    streetNumber: number;
    postalCode: string;  
}