import { Component, Input } from '@angular/core';
import { FloorDTO } from 'src/app/_models/Floor';

@Component({
  selector: 'app-floor',
  templateUrl: './floor.component.html',
  styleUrls: ['./floor.component.css']
})
export class FloorComponent {

  @Input() floor!:FloorDTO;

}
