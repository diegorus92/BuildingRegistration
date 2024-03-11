import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BuildingResponse } from 'src/app/_models/Building';
import { DepartmentDTO } from 'src/app/_models/Department';
import { FloorDTO } from 'src/app/_models/Floor';
import { GarageDTO } from 'src/app/_models/Garage';
import {  GarageSectionOccupiedDTO } from 'src/app/_models/GarageSection';
import { OccupantDTO } from 'src/app/_models/Occupant';
import { BuildingService } from 'src/app/_services/building.service';
import { GarageService } from 'src/app/_services/garage.service';
import { OccupantService } from 'src/app/_services/occupant.service';
import { buildings } from 'src/assets/Mock_buildings';
import { GARAGE_SECTION_OCCUPIED } from 'src/assets/Mock_garage'; 

@Component({
  selector: 'app-create-update-occupant',
  templateUrl: './create-update-occupant.component.html',
  styleUrls: ['./create-update-occupant.component.css']
})
export class CreateUpdateOccupantComponent {

  buildings:BuildingResponse[] = [] //buildings;
  buildingSelected!:BuildingResponse;
  departmentSelected!:DepartmentDTO;
  garageSelected?:GarageDTO;
  isSpinnerShowing = false;
  isSubmitPressed = false;

  garageSectionsOccupied:GarageSectionOccupiedDTO[] = [] //GARAGE_SECTION_OCCUPIED;

  floorSelected:FloorDTO = {
    floorName: "x",
    departmentsDtos:[]
  };

  occupantForm:FormGroup = this.fb.group({
    //Occupant data
    occupantName:['',[Validators.required]],
    occupantSurname: ['',[Validators.required]],
    occupantCellPhone:[''],
    occupantEmail:['',[Validators.email]],
    //Building data
    buildingNameAndAddress:['',[Validators.required]],
    //Floor data
    floorName:['', [Validators.required]],
    //department data
    departmentName:['',[Validators.required]],
    //Garage data
    garageLevel:[''],
    //Garage Section data
    garageSectionName:[''],
    //Employee data
    employees: this.fb.array([]),
    //Vehicle data
    vehicles: this.fb.array([])
  });

  constructor(
    private fb:FormBuilder, 
    private occupantService:OccupantService, 
    private buildingService:BuildingService,
    private garageService:GarageService){

    this.loadBuildings();
  }

  

  loadBuildings(){
    this.buildingService.buildings.subscribe(buildingsResult => {
      this.buildings = buildings;
      console.log("Buildings from DB: ",this.buildings);
    })
  }

  loadGarageSectionsOccupied(buildingName:string, buildingAddress:string, garageLevel:string){
    this.garageService.getGarageSectionsOccupied(buildingName, buildingAddress, garageLevel).subscribe(gsOccupied => {
      this.garageSectionsOccupied = gsOccupied;
      console.log("garages sectins occupied from DB: ", this.garageSectionsOccupied);
    })
  }

  onSelectBuilding(selection:string):void{
    let option = selection.split("-");
    console.log(option);
    this.buildingSelected = this.buildings.
      find(building => building.buildingName?.toLowerCase() == option[0].toLowerCase() && building.buildingAddress?.toLowerCase() == option[1].toLowerCase())!;
  }

  onSelectFloor(selection:string){
    this.floorSelected = this.buildingSelected.floorDtos?.find(floor => floor.floorName?.toLowerCase() == selection.toLowerCase())!;
    console.log("Floor selected of Building: ",this.buildingSelected.buildingName, " - ", this.floorSelected);
  }

  onSelectDepartment(selection:string){
    this.departmentSelected = this.floorSelected.departmentsDtos?.find(department => department.departmentName?.toLowerCase() == selection.toLowerCase())!;
    console.log("Department selected of Floor: ",this.floorSelected.floorName, " - ", this.departmentSelected)
  }

  onSelectGarage(selection:string){
    this.garageSelected = this.buildingSelected.garageDtos?.
      find(garage => garage.garageLevel?.toLowerCase() == selection.toLowerCase());
      console.log("Garage selected from building: ", this.buildingSelected.buildingName, " - ", this.garageSelected);

      this.loadGarageSectionsOccupied(this.buildingSelected.buildingName!, this.buildingSelected.buildingAddress!, this.garageSelected?.garageLevel!);
  }

  //Forms array functions
  //Employees-------------------------------------
  createEmployeeFormGroup():FormGroup{
    return this.fb.group({
      employeeName:['',[Validators.required]],
      employeeSurname:['',[Validators.required]],
      employeeCheckIn:[''],
      employeeCheckOut:['']
    });
  }

  get employeesFormArray():FormArray{
    return this.occupantForm.get('employees') as FormArray;
  }

  addNewEmployeeFormGroup(){
    this.employeesFormArray.push(this.createEmployeeFormGroup());
  }

  removeEmployeeFormGroup(formGroupIndex:number){
    this.employeesFormArray.removeAt(formGroupIndex);
  }
  //---------------------------------------------

  //Vehicle------------------------------------
  createVehicleFormGroup():FormGroup{
    return this.fb.group({
      vehicleBrand: ['',[Validators.required]],
      vehicleModel: ['',[Validators.required]],
      vehicleColor: ['',[Validators.required]],
      vehicleLicensePlate: ['',[Validators.required]]
    });
  }

  get vehiclesFormGroup():FormArray{
    return this.occupantForm.get('vehicles') as FormArray;
  }

  addNewVehicleFormGroup(){
    this.vehiclesFormGroup.push(this.createVehicleFormGroup());
  }

  removeVehicleFormGroup(formGroupIndex:number){
    this.vehiclesFormGroup.removeAt(formGroupIndex);
  }
  //------------------------------------------

  onSubmit(){
    if(this.occupantForm.valid){
      console.log(this.occupantForm.value);
      const occupantToPost: OccupantDTO = this.occupantService.prepareDataOccupantDto(this.occupantForm.value);
      console.log("prepared occupant data: ", occupantToPost);
      
      this.isSubmitPressed = true;
      this.isSpinnerShowing = true;
      //do post
      this.occupantService.postOccupant(occupantToPost).subscribe({
        next: data => {
          console.log("[CreateUpdateOccupant] posting new occupant: --> ", data);
        },
        error: error => {
          console.log("[CreateUpdateOccupant] post occupant error: --> ", error);
          this.isSubmitPressed = false;
          this.isSpinnerShowing = false;
        },
        complete: () => {
          console.log("[CreateUpdateOccupant] post complete successfull: ");
          this.isSubmitPressed = false;
          this.isSpinnerShowing = false;
        }
      })
    }
    else{
      console.log("Occupant Form invalid");
    }
  }

  isGarageSectionOccupied(buildingName:string, buildingAddress:string, garageLevel:string, garageSection:string):boolean{
    return this.garageSectionsOccupied.some(item => 
      item.buildingName == buildingName &&
      item.buildingAddress == buildingAddress &&
      item.garageLevel == garageLevel &&
      item.garageSectionName == garageSection
    );
  }

  checkOccupadiedGarageSectionList(garageSectionSelectedList:any,buildingName:string, buildingAddress:string, garageLevel:string, garageSection:string):boolean{
    for(let garageSectionName of garageSectionSelectedList){
      if(this.isGarageSectionOccupied(buildingName, buildingAddress, garageLevel, garageSectionName))
        return true;
    }
    return false;
  }
}
