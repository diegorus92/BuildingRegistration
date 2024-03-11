import { BuildingForOccupant } from "./Building";
import { EmployeeDTO } from "./Employee";
import { VehicleDTO } from "./Vehicle";

export interface OccupantDTO{
    occupantName: string,
    occupantSurname: string,
    occupantCellPhone: string,
    occupantEmail: string,
    building:BuildingForOccupant //include building, floor department, garage and garage section info
    employees:EmployeeDTO[],
    vehicles:VehicleDTO[]
}