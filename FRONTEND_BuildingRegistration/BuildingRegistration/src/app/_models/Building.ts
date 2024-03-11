import { FloorDTO } from "./Floor"
import { GarageDTO } from "./Garage"
import { GarageSectionDTO } from "./GarageSection"
import { Option } from "./options"

export interface BuildingResponse{
    buildingName?:string
    buildingAddress?:string

    buildingHasGuard?:string
    buildingHasCleaningService?:string
    buildingHasJanitor?:string
    buildingHasWifi?:string
    buildingAllowPet?:string

    buildingElevatorQty?:number
    buildingNote?:string
    
    floorDtos?:FloorDTO[],
    garageDtos?:GarageDTO[]
}

export interface Building{
    buildingName?:string
    buildingAddress?:string

    buildingHasGuard?:boolean
    buildingHasCleaningService?:boolean
    buildingHasJanitor?:boolean
    buildingHasWifi?:boolean
    buildingAllowPet?:boolean

    buildingElevatorQty?:number
    buildingNote?:string
}

export interface BuildingDTO extends Building{
    floorDtos?:FloorDTO[],
    garageDtos?:GarageDTO[]
}

export interface BuildingForOccupant{
    buildingName: string,
    buildingAddress: string,
    floorName: string,
    departmentName: string,
    garageLevel: string,
    garageSections:GarageSectionDTO[]
}


