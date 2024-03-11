import { Component } from '@angular/core';
import { Subscriber, pipe } from 'rxjs';
import { BuildingResponse } from 'src/app/_models/Building';
import { BuildingService } from 'src/app/_services/building.service';
import { building } from 'src/assets/Mock_buildings';

@Component({
  selector: 'app-building',
  templateUrl: './building.component.html',
  styleUrls: ['./building.component.css']
})
export class BuildingComponent {
  
  building!:BuildingResponse;

  constructor(private buildingService:BuildingService){}

    ngOnInit(){
        this.buildingService.selectedBuildingSubject$.subscribe({
            next: data => {
                this.building = data;
                console.log("[BuildingComponent]: building data selected: ",data);
            },
            error: error => console.log("[BuildingComponent: error during retrieve building]"),
            complete: () => console.log("[BuildingComponent]: building load successfully => ", building)
        })
    }
}
