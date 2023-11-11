export interface Factory {
    id: number;
    city: string;
    Street: string;
    streetNumber: number;
    postalCode: string;
}

export interface SelectFactoryDTO{
    id: number;
    city: string;
}