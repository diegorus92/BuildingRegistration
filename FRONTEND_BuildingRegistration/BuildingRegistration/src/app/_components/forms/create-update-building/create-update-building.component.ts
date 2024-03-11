import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BuildingDTO } from 'src/app/_models/Building';
import { BuildingService } from 'src/app/_services/building.service';

@Component({
  selector: 'app-create-update-building',
  templateUrl: './create-update-building.component.html',
  styleUrls: ['./create-update-building.component.css']
})
export class CreateUpdateBuildingComponent {

  building!:BuildingDTO;

  buildingFormGroup = this.fb.group({
    buildingName:[''],
    buildingAddress:['',[Validators.required]],
    buildingHasGuard:[""],
    buildingHasCleaningService:[""],
    buildingHasJanitor:[""],
    buildingHasWifi:[""],
    buildingAllowPet:[""],
    buildingElevatorQty:[0],
    buildingNote:[''],

    floorDtos: this.fb.array([]),
    garageDtos: this.fb.array([])
  });

  constructor(private fb:FormBuilder, private buildingService:BuildingService){}


  //FloorDtosGroup------------------------------
  createFloorDtoGroup():FormGroup{
    return this.fb.group({
      floorName:['',[Validators.required]],
      departmentsDtos: this.fb.array([])
    })
  }

  get floorDtosGroup():FormArray{
    return this.buildingFormGroup.get("floorDtos") as FormArray;
  }

  addFloorDtosGroup(){
    this.floorDtosGroup.push(this.createFloorDtoGroup());
  }

  removeFloor(floorIndex:number){
    this.floorDtosGroup.removeAt(floorIndex);
  }
  
  //--------------------------------------------

  //DepartmentsDtosGroup----------------------------
  createDepartmentDtoGroup():FormGroup{
    return this.fb.group({
      departmentName:['', [Validators.required]],
    })
  }

  getDepartmentsFloor(floorIndex:number):FormArray{
    return this.floorDtosGroup.at(floorIndex).get("departmentsDtos") as FormArray;
  }
  
  addDepartmentDtosGroup(floorIndex:number){
    this.getDepartmentsFloor(floorIndex).push(this.createDepartmentDtoGroup());
  }

  removeDepartment(floorIndex:number, departmentIndex:number){
    this.getDepartmentsFloor(floorIndex).removeAt(departmentIndex);
  }
  //------------------------------------------------------

  
  //GaragesDtos--------------------------------------------
  createGarageDtoGroup():FormGroup{
    return this.fb.group({
      garageLevel: ['',[Validators.required]],
      garageSectionsDtos: this.fb.array([])
    });
  }

  get garageDtosGroup():FormArray{
    return this.buildingFormGroup.get("garageDtos") as FormArray;
  }

  addGarageDtosGroup(){
    this.garageDtosGroup.push(this.createGarageDtoGroup());
  }

  removeGarage(garageIndex:number){
    this.garageDtosGroup.removeAt(garageIndex);
  }
  //-------------------------------------------------------

  //GarageSectionsDtos-----------------------------------
  createGarageSectionGroup():FormGroup{
    return this.fb.group({
      garageSectionName: ['', [Validators.required]]
    });
  }

  getGarageSections(garageIndex:number):FormArray{
    return this.garageDtosGroup.at(garageIndex).get("garageSectionsDtos") as FormArray;
  }

  addGarageSectionGroup(garageIndex:number){
    this.getGarageSections(garageIndex).push(this.createGarageSectionGroup());
  }

  removeGarageSection(garageIndex:number, garageSectionIndex:number){
    this.getGarageSections(garageIndex).removeAt(garageSectionIndex);
  }
  //----------------------------------------------------


  onSubmit(){
    if(this.buildingFormGroup.valid){

      console.log("form: ", this.buildingFormGroup.value);
      const buildingToSend:BuildingDTO = this.buildingService.prepareDataBuildingDTO(this.buildingFormGroup.value);
      console.log("obj to send: ",buildingToSend);
      this.buildingService.postBuilding(buildingToSend).subscribe({
        next: response => console.log("Posting a new Building", response),
        error: error => console.log("Error during post building: ", error),
        complete: () => console.log("Building post complete!")
      })

    }
    else{
      console.log("Form Building incorrect");
    }
  }
}
