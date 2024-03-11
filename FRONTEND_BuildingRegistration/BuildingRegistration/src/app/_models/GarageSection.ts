export interface GarageSectionDTO{
    garageSectionId?:number,
    garageSectionName?:string,
    occupantsQty?:number
}

export interface GarageSectionOccupiedDTO{
    buildingName:string,
    buildingAddress:string,
    garageLevel:string,
    garageSectionName:string
}