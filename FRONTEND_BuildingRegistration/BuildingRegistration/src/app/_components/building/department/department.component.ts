import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OccupantDTO } from 'src/app/_models/Occupant';
import { DepartmentService } from 'src/app/_services/department.service';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent {

  departmentOccupants:OccupantDTO[] = [];

  constructor(private route:ActivatedRoute, private departmentService:DepartmentService){}

  ngOnInit(){
    this.getDepartmentOccupants();
  }


  getDepartmentOccupants(){
    let departmentId =  this.route.snapshot.queryParamMap.get("departmentId");
    this.departmentService.getDepartmentOccupants(departmentId).subscribe({
      next: data => {
        this.departmentOccupants = data;
        console.log("[DepartmentComponent]: ", this.departmentOccupants);
      },
      error: error => console.log("[DepartmentComopnent]: Error while fetch department info ->", error)
    })
  }

}
