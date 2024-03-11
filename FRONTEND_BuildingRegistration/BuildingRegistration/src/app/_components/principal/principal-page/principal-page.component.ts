import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Building, BuildingResponse } from 'src/app/_models/Building';
import { Option } from 'src/app/_models/options';
import { BuildingService } from 'src/app/_services/building.service';


@Component({
  selector: 'app-principal-page',
  templateUrl: './principal-page.component.html',
  styleUrls: ['./principal-page.component.css']
})
export class PrincipalPageComponent {
  
  buildings:BuildingResponse[] = []
  buildingSelected!:BuildingResponse;
  isSpinnerShowing = false;


  constructor(private buildingService:BuildingService, private router:Router){}

  ngOnInit():void{
    this.loadBuildings();
  }

  loadBuildings(){
    this.isSpinnerShowing ! = true;

    var buildingsRecovery = this.buildingService.buildings.subscribe({
      next: result =>{
        this.buildings = this.buildingService.prepareDataBuildingsResponse(result);
      },

      error: error => console.log("[PrincipalPageComponent] error in get Buildings: ", error),
      complete: () => {
        console.log("[PrincipalPageComponent] Get Buildings complete! ",this.buildings);
        this.isSpinnerShowing = false;
      }
  })
  }

  onSelected(event:any){
    this.buildingSelected = this.buildingService.prepareDataBuildingResponse(event.value);
    console.log("Building response selected", this.buildingSelected);
  }

  onClick(){
    if(this.buildingSelected){
      this.buildingService.setSelectedBuildingSubject$(this.buildingSelected);
      this.router.navigateByUrl("building");
    }
  }
}
