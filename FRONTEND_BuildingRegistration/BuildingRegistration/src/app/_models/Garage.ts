import { GarageSectionDTO } from "./GarageSection";

export interface GarageDTO{
    garageLevel?:string,
    garageSectionsDtos?:GarageSectionDTO[]
}
