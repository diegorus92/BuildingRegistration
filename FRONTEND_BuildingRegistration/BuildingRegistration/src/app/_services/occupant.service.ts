import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ENVIRONMENT } from 'src/assets/environment';
import { OccupantDTO } from '../_models/Occupant';
import { BuildingForOccupant } from '../_models/Building';
import { GarageSectionDTO } from '../_models/GarageSection';
import { EmployeeDTO } from '../_models/Employee';
import { VehicleDTO } from '../_models/Vehicle';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OccupantService {
  
  private url = ENVIRONMENT.apiUrl+"occupant";

  constructor(private http:HttpClient) { }

  prepareDataOccupantDto(occupantRawData:any):OccupantDTO{
    const occupantToSend:OccupantDTO = {
      occupantName: occupantRawData.occupantName,
      occupantSurname: occupantRawData.occupantSurname,
      occupantCellPhone: occupantRawData.occupantCellPhone,
      occupantEmail: occupantRawData.occupantEmail,
      
      building: this.prepareDataBuilding(occupantRawData),
      employees: this.prepareDataEmployees(occupantRawData.employees),
      vehicles: this.prepareDataVehicles(occupantRawData.vehicles),
    }
    return occupantToSend;
  }

  postOccupant(newOccupant:OccupantDTO):Observable<string>{
    return this.http.post(this.url, newOccupant, {responseType:'text'});
  }


  private prepareDataBuilding(buildingRawData:any):BuildingForOccupant{
      
    let buildingNameAddressSeparated = buildingRawData.buildingNameAndAddress.split("-");
    const garageSections:GarageSectionDTO[] = [];

    for(let garageSection of buildingRawData.garageSectionName){
      garageSections.push({garageSectionName: garageSection});
    }

    const buildingToSend:BuildingForOccupant = {
      buildingName: buildingNameAddressSeparated[0],
      buildingAddress: buildingNameAddressSeparated[1],
      floorName: buildingRawData.floorName,
      departmentName: buildingRawData.departmentName,
      garageLevel: buildingRawData.garageLevel,
      garageSections: garageSections,
    }
    return buildingToSend;
  }

  private prepareDataEmployees(employeesList:any):EmployeeDTO[]{
    const employees:EmployeeDTO[] = [];

    for(let employee of employeesList){
      employees.push({
        employeeName: employee.employeeName,
        employeeSurname: employee.employeeSurname,
        employeeCheckIn: employee.employeeCheckIn,
        employeeCheckOut: employee.employeeCheckOut
      });
    }
    
    return employees;
  }

  private prepareDataVehicles(vehiclesList:any):VehicleDTO[]{
    const vehicles:VehicleDTO[] = [];

    for(let vehicle of vehiclesList){
      vehicles.push({
        vehicleBrand: vehicle.vehicleBrand,
        vehicleModel: vehicle.vehicleModel,
        vehicleColor: vehicle.vehicleColor,
        vehicleLicensePlate: vehicle.vehicleLicensePlate
      });
    }

    return vehicles;
  }
}
