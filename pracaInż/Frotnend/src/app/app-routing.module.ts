import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginPageComponent } from './Login/UI/login-page.component';
import { DashboardComponent } from './Employees/UI/dashboard.component';
import { EmployeePageComponent } from './Employees/Components/employee-page/employee-page.component';
import { InvoicesPageComponent } from './Invoice/UI/invoices-page.component';
import { PrintersPageComponent } from './Printer/UI/printers-page/printers-page.component';
import { ComputerPageComponent } from './Computers/UI/computer-page.component';
import { ComputerComponent } from './Computers/Components/computer/computer.component';
import { InfrastructurePageComponent } from './Infrastructure/Page/infrastructure-page/infrastructure-page.component';

const routes: Routes = [
  {path: "login", component: LoginPageComponent},
  {path: "dashboard", component: DashboardComponent},
  {path: "employee/:id", component: EmployeePageComponent},
  {path: "computers/:id", component: ComputerComponent},
  {path: "invoices", component: InvoicesPageComponent},
  {path: "printers", component: PrintersPageComponent},
  {path: "computers", component: ComputerPageComponent},
  {path: "infrastructure", component: InfrastructurePageComponent},
  {path: "", redirectTo: "infrastructure", pathMatch: "full"},
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
