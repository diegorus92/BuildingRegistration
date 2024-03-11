import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http'; 
import { ENVIRONMENT } from 'src/assets/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GarageService {

  private url = ENVIRONMENT.apiUrl+"Garage"

  constructor(private http:HttpClient) { }

  getGarageSectionsOccupied(buildingName:string, buildingAddress:string, garageLevel:string):Observable<any>{
    return this.http.get(`${this.url}/garage-section/${buildingName}/${buildingAddress}/${garageLevel}`);
  }
}
