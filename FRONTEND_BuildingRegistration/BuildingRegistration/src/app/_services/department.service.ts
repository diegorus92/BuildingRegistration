import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ENVIRONMENT } from 'src/assets/environment';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  private url = ENVIRONMENT.apiUrl+"department"


  constructor(private http:HttpClient) { }

  getDepartmentOccupants(departmentId:any):Observable<any>{
    return this.http.get(`${this.url}/occupants-department/${departmentId as number}`);
  }
}
