import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PrincipalPageComponent } from './_components/principal/principal-page/principal-page.component';
import { CreateUpdateBuildingComponent } from './_components/forms/create-update-building/create-update-building.component';
import { BuildingComponent } from './_components/building/building/building.component';
import { CreateUpdateOccupantComponent } from './_components/forms/create-update-occupant/create-update-occupant.component';
import { DepartmentComponent } from './_components/building/department/department.component';

const routes: Routes = [
  {path:"", component:PrincipalPageComponent, pathMatch:'full'},
  {path:"create-update-building", component:CreateUpdateBuildingComponent},
  {path:"create-update-occupant", component:CreateUpdateOccupantComponent},
  {path:"building", component:BuildingComponent},
  {path:"department", component:DepartmentComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
