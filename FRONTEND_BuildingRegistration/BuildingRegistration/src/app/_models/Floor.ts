import { DepartmentDTO } from "./Department";

export interface FloorDTO{
    floorName?:string,
    departmentsDtos?:DepartmentDTO[]
}
