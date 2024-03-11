import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PrincipalPageComponent } from './_components/principal/principal-page/principal-page.component';
import { NavbarComponent } from './_shared/navbar/navbar.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatMenuModule} from '@angular/material/menu';
import {MatButtonModule} from '@angular/material/button';
import {MatSelectModule} from '@angular/material/select';
import { HttpClientModule } from '@angular/common/http';
import { CreateUpdateBuildingComponent } from './_components/forms/create-update-building/create-update-building.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BuildingComponent } from './_components/building/building/building.component';
import { FloorComponent } from './_components/building/floor/floor.component';
import { GarageComponent } from './_components/building/garage/garage.component';
import { CreateUpdateOccupantComponent } from './_components/forms/create-update-occupant/create-update-occupant.component';
import { WarningMessageComponent } from './_shared/warning-message/warning-message.component';
import { InputErrorMessageComponent } from './_shared/input-error-message/input-error-message.component';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { DepartmentComponent } from './_components/building/department/department.component'

@NgModule({
  declarations: [
    AppComponent,
    PrincipalPageComponent,
    NavbarComponent,
    CreateUpdateBuildingComponent,
    BuildingComponent,
    FloorComponent,
    GarageComponent,
    CreateUpdateOccupantComponent,
    WarningMessageComponent,
    InputErrorMessageComponent,
    DepartmentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatMenuModule,
    MatButtonModule,
    MatSelectModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    MatProgressSpinnerModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
