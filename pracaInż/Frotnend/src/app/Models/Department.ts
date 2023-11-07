export interface Department {
    id: number;
    name: string;
    shortName: string;
    invoiceCode: string;
    factoryLocation: string;
}

export interface DepartmentDTO {
    id: number;
    name: string;
    shortName: string;
    invoiceCode: string;
    factoryId: number;
}

export interface AddDepartmentDTO {
    name: string;
    shortName: string;
    invoiceCode: string;
    factoryId: number;
}
