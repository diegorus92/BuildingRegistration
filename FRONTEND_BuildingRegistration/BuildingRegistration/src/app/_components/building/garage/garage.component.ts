import { Component, Input } from '@angular/core';
import { GarageDTO } from 'src/app/_models/Garage';

@Component({
  selector: 'app-garage',
  templateUrl: './garage.component.html',
  styleUrls: ['./garage.component.css']
})
export class GarageComponent {

  @Input() garage!:GarageDTO;

}
