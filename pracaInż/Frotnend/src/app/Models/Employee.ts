import { Computer } from "./Computer";
import { Department } from "./Department";
import { Factory } from "./Factory";

export interface Employee {
    id: number;
    name: string;
    surname: string;
    email: string;
    workPhoneNumber: string;
    jobTitle: string;
    departmentName: string;
    departmentShortName: string;
    factoryLocation: string;
    computer: Computer
}

export interface EmployeePC {
    id: number;
    name: string;
    lastName: string;
}