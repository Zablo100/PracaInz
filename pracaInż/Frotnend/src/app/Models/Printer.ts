export interface Printer {
    id: number;
    model: string;
    manufacturer: string;
    description: string | null;
    invoiceDescription: string | null;
    contractNumber: string | null;
    iP: string | null;
    monthlyCheck: boolean;
    department: string;
    serialNumber: string;
}