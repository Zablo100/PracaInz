import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort'
import { MatDialogRef, MatDialog, MatDialogModule } from '@angular/material/dialog';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatButtonModule} from '@angular/material/button';
import { ToastrModule } from 'ngx-toastr'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginPageComponent } from './Login/UI/login-page.component';
import { NavbarComponent } from './Core/navbar/navbar.component';
import { DashboardComponent } from './Employees/UI/dashboard.component';
import { SidebarComponent } from './Core/sidebar/sidebar.component';
import { EmployeeComponent } from './Employees/Components/employee/employee.component';
import { MatTabsModule } from '@angular/material/tabs';
import { DepartmentComponent } from './Employees/Components/department/department.component';
import { EmployeePageComponent } from './Employees/Components/employee-page/employee-page.component';
import { InvoicesPageComponent } from './Invoice/UI/invoices-page.component';
import { InvoicesComponent } from './Invoice/Components/invoices/invoices.component';
import { PrintersPageComponent } from './Printer/UI/printers-page/printers-page.component';
import { PrinterComponent } from './Printer/Components/printer/printer.component';
import { InvoiceComponent } from './Invoice/Components/invoice/invoice.component';
import { GenerateInvoiceComponent } from './Printer/Components/generate-invoice/generate-invoice.component';
import { NewInvoiceComponent } from './Invoice/Components/new-invoice/new-invoice.component';
import { NewItemComponent } from './Invoice/Components/new-item/new-item.component';
import { ComputerPageComponent } from './Computers/UI/computer-page.component';
import { ComputersComponent } from './Computers/Components/computers/computers.component';
import { ComputerComponent } from './Computers/Components/computer/computer.component';
import { ComputerCardComponent } from './Computers/Components/computer-card/computer-card.component';
import { PcLogComponent } from './Computers/Components/pc-log/pc-log.component';
import { NewLogFormComponent } from './Computers/Components/new-log-form/new-log-form.component';
import { InfrastructurePageComponent } from './Infrastructure/Page/infrastructure-page/infrastructure-page.component';
import { PcLogChartComponent } from './Computers/Components/pc-log-chart/pc-log-chart.component';
import {MatSelectModule} from '@angular/material/select';
import {MatIconModule} from '@angular/material/icon';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { EmployeeEditWindowComponent } from './Employees/Components/employee-edit-window/employee-edit-window.component';
import { DepartmentEditWindowComponent } from './Employees/Components/department-edit-window/department-edit-window.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    NavbarComponent,
    DashboardComponent,
    SidebarComponent,
    EmployeeComponent,
    DepartmentComponent,
    EmployeePageComponent,
    InvoicesPageComponent,
    InvoicesComponent,
    PrintersPageComponent,
    PrinterComponent,
    InvoiceComponent,
    GenerateInvoiceComponent,
    NewInvoiceComponent,
    NewItemComponent,
    ComputerPageComponent,
    ComputersComponent,
    ComputerComponent,
    ComputerCardComponent,
    PcLogComponent,
    NewLogFormComponent,
    InfrastructurePageComponent,
    PcLogChartComponent,
    EmployeeEditWindowComponent,
    DepartmentEditWindowComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatTabsModule,
    MatDialogModule,
    MatExpansionModule,
    MatButtonModule,
    MatSelectModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
