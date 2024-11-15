import { Employee, EmployeePC } from "./Employee";

export interface ComputerOld {
    id: number;
    name: string;
    timeOfPurchase: string;
    status: boolean;
    ip: string | null;
}
export enum Dysk{
    "SSD",
    "HDD"
}

export interface HardDrive {
    id: number;
    name: string;
    size: number;
    type: Dysk;
    score: number;
}

export interface Monitor {
    id: number;
    hardwareID: string;
    name: string | null;
}


export interface Computer {
    id: number;
    name: string;
    cpu: string;
    cpuScore: number;
    cpuMaxclockSpeed: number;
    cpuCores: number;
    ram: number;
    ramSpeed: number;
    gpu: string | null;
    os: string;
    model: string | null;
    timeOfPurchase: string;
    hardDrives: HardDrive[];
    monitors: Monitor[];
}

export interface ComputerDTO {
    id: number;
    name: string;
    processorName: string;
    processorManufacturer: number;
    processorScore: number;
    graphicsCardName: string;
    graphicsCardManufacturer: number;
    graphicsCardScore: number;
    motherboardName: string;
    ramModel: string;
    ramType: string;
    osName: string;
    ramCapacity: number;
    yearOfPurches: string;
    inventoryName: string;
    totalScore: number;
    person: string;
    hardDrives: HardDrive[];
}

export interface newComputerDTO{
    id: number;
    pcName: string;
    employee: Employee | null;
    employeeId: number | null;
    type: number;
    ticketCount: number;
    yearOfPurchase: number;
    inventoryNumber: string;
}

export interface ComputerCard{
    icon: string;
    title: string;
    info: string;
}

export interface ComputerResponse{
    id: number;
    name: string;
    employeeFullName: string;
    cpu: string;
    cpuScore: number;
    ram: number;
    gpu: string;
    os: string;
    hardDriveType: string;
    workType: string;
}

export interface pcLog{
    date: string,
    message: string,
  }
