import { Computer } from "./Computer";
import { Department } from "./Department";
import { Factory } from "./Factory";

export interface Employee {
    id: number;
    name: string;
    lastName: string;
    email: string;
    jobTitle: string;
    factory: Factory;
    department: Department;
    computer: Computer
}

export interface EmployeePC {
    id: number;
    name: string;
    lastName: string;
}