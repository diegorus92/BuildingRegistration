import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { ENVIRONMENT } from 'src/assets/environment';
import { BehaviorSubject, Observable } from 'rxjs';
import { BuildingDTO, BuildingResponse } from '../_models/Building';
import { DepartmentDTO } from '../_models/Department';
import { FloorDTO } from '../_models/Floor';
import { GarageSectionDTO } from '../_models/GarageSection';
import { GarageDTO } from '../_models/Garage';
import { Option } from '../_models/options'; 

@Injectable({
  providedIn: 'root'
})
export class BuildingService {

  private url = ENVIRONMENT.apiUrl+"building"
  private selectedBuildingSubject: BehaviorSubject<BuildingResponse> = new BehaviorSubject<BuildingResponse>({})


  constructor(private http:HttpClient) { }


  //-----Subject--------------
  get selectedBuildingSubject$():Observable<BuildingResponse>{
    return this.selectedBuildingSubject as Observable<BuildingResponse>;
  }

  setSelectedBuildingSubject$(building:BuildingResponse){
    this.selectedBuildingSubject.next(building);
  }
  //---------------------------

  get buildings():Observable<any>{
    return this.http.get(this.url);
  }

  postBuilding(building:BuildingDTO):Observable<any>{
    return this.http.post(this.url, building, {responseType: 'text'});
  }



  prepareDataBuildingResponse(building:any):BuildingResponse{
    const buildingResponse:BuildingResponse={
      buildingName: building.buildingName,
        buildingAddress: building.buildingAddress,
        buildingHasGuard: building.buildingHasGuard ? Option[Option.YES] : Option[Option.NO],
        buildingHasCleaningService: building.buildingHasCleanginService ? Option[Option.NO] : Option[Option.YES],
        buildingHasJanitor: building.buildingHasJanitor ? Option[Option.YES] : Option[Option.NO],
        buildingAllowPet: building.buildingAllowPet ? Option[Option.YES] : Option[Option.NO],
        buildingHasWifi: building.buildingHasWifi ? Option[Option.YES] : Option[Option.NO],
        buildingElevatorQty: building.buildingElevatorQty,
        buildingNote: building.buildingNote,

        floorDtos: this._getFloorsFromBuilding(building),
        garageDtos: this._getGaragesFromBuilding(building)
    };

    return buildingResponse;
  }

  prepareDataBuildingsResponse(buildingsRequest:any):BuildingResponse[]{
    const buildingResponse:BuildingResponse[] = [] 
    
    for(let building of buildingsRequest){
      buildingResponse.push({
        buildingName: building.buildingName,
        buildingAddress: building.buildingAddress,
        buildingHasGuard: building.buildingHasGuard ? Option[Option.YES] : Option[Option.NO],
        buildingHasCleaningService: building.buildingHasCleanginService ? Option[Option.NO] : Option[Option.YES],
        buildingHasJanitor: building.buildingHasJanitor ? Option[Option.YES] : Option[Option.NO],
        buildingAllowPet: building.buildingAllowPet ? Option[Option.YES] : Option[Option.NO],
        buildingHasWifi: building.buildingHasWifi ? Option[Option.YES] : Option[Option.NO],
        buildingElevatorQty: building.buildingElevatorQty,
        buildingNote: building.buildingNote,

        floorDtos: this._getFloorsFromBuilding(building),
        garageDtos: this._getGaragesFromBuilding(building)
      });
    }
    
    return buildingResponse;
  }

  prepareDataBuildingDTO(buildingRequest:any):BuildingDTO{
    const building:BuildingDTO = {
      buildingName: buildingRequest.buildingName,
      buildingAddress: buildingRequest.buildingAddress,
      buildingHasGuard: buildingRequest.buildingHasGuard == "true" ? true : false,
      buildingHasCleaningService: buildingRequest.buildingHasCleaningService == "true" ? true : false,
      buildingHasJanitor: buildingRequest.buildingHasJanitor == "true" ? true : false,
      buildingHasWifi: buildingRequest.buildingHasWifi == "true" ? true : false,
      buildingAllowPet: buildingRequest.buildingAllowPet == "true" ? true : false,
      buildingElevatorQty: buildingRequest.buildingElevatorQty,
      buildingNote: buildingRequest.buildingNote,
      floorDtos: this._getFloorsFromBuilding(buildingRequest),
      garageDtos: this._getGaragesFromBuilding(buildingRequest),
    }

    return building;
  }

  private _getDepartmentsFromFloor(floor:any):DepartmentDTO[]{
    const departmentsOfFloor:DepartmentDTO[] = [];
    
    for(let department of floor.departmentsDtos){
      departmentsOfFloor.push({
        departmentId: department.departmentId,
        departmentName: department.departmentName,
        occupantsQty: department.occupantsQty
      });
    }

    return departmentsOfFloor;
  }

  private _getFloorsFromBuilding(building:any):FloorDTO[]{
    const floorsOfBuilding:FloorDTO[] = [];

    for(let floor of building.floorDtos){
      floorsOfBuilding.push({
        floorName: floor.floorName,
        departmentsDtos: this._getDepartmentsFromFloor(floor)
      });
    }

    return floorsOfBuilding;
  }

  private _getGarageSectionsFromGarage(garage:any):GarageSectionDTO[]{
    const garageSections:GarageSectionDTO[] = [];

    for(let garageSection of garage.garageSectionsDtos){
      garageSections.push({
        garageSectionName: garageSection.garageSectionName,
        occupantsQty : garageSection.occupantsQty
      })
    }

    return garageSections;
  }

  private _getGaragesFromBuilding(building:any): GarageDTO[]{
    const garages:GarageDTO[] = [];

    for(let garage of building.garageDtos){
      garages.push({
        garageLevel: garage.garageLevel,
        garageSectionsDtos: this._getGarageSectionsFromGarage(garage)
      });
    }

    return garages;
  }
}
