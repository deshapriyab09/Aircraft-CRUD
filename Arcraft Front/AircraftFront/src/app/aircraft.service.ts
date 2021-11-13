import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AircraftVM } from './Aircraft';

@Injectable({
  providedIn: 'root'
})
export class AircraftService {

  url = 'https://localhost:44309/api/Aircraft/';
  constructor(private http: HttpClient) { }

  GetAllAircraft(): Observable<AircraftVM[]> {
    return this.http.get<AircraftVM[]>(this.url + 'GetAllAircraft');
  }

//-----
AddAircrftPhoto(formData:any) {
  return this.http.post(this.url +'AddAircraftPhoto', formData, {reportProgress: true, observe: 'events'})
}
//----
    
  AddAircraftData(aircraftData: AircraftVM): Observable<AircraftVM> {
    // const formData: FormData = new FormData();
    // aircraftData.append('myFile', this.fileToUpload);
    // formData.append('altText', this.fileForm.value.altText);
    // formData.append('description', this.fileForm.value.description);
    // return this.http.post('http://localhost:48608/FileManager', formData,
    // {
    //   headers : new HttpHeaders()})
    // .subscribe(() => alert("File uploaded"));

    const httpHeaders = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<AircraftVM>(this.url + 'AddAircraft', aircraftData, httpHeaders);
  }

  UpdateAircraftData(aircraftData: AircraftVM): Observable<AircraftVM> {
    const httpHeaders = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<AircraftVM>(this.url + 'UpdateAircraft', aircraftData, httpHeaders);
  }

  DeleteAircraftById(id: number): Observable<number> {
    return this.http.delete<number>(this.url + 'DeleteAircraft?id=' + id);
  }

  GetAircraftById(id: number): Observable<AircraftVM> {
    return this.http.get<AircraftVM>(this.url + 'GetAircraftDetailsById?id=' + id);
  }

  // CreateImgPath(serverPath:string){
  //   return `https://localhost:44301/${serverPath}`;
  // }

  SearchAircrafData(search : string): Observable<AircraftVM[]> {
    return this.http.get<AircraftVM[]>(this.url + 'AircraftSearch?search=' + search);
  }

  // NewAirCraft(): AircraftVM {
  //   return {
  //     id: 0,
  //     make: '',
  //     model: '',
  //     registration: '',
  //     location: '',
  //     image:'',
  //     dateTime: '1900-01-01',
  //   }
  // }
}
