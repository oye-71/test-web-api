import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Ordinateur, OrdinateurDto } from '../models/ordinateur';

@Injectable({
  providedIn: 'root'
})
export class ComputerService {
  constructor(
    private _http: HttpClient
  ) { }

  public getComputers(): Observable<OrdinateurDto[]> {
    let options = {
      headers: new HttpHeaders({
        'ComputersApiKey': environment.serverApiKey
      })
    }
    return this._http.get<OrdinateurDto[]>(environment.ordinateursUrl + "GetAllComputers", options)
  }

  public getMockedComputers(): Ordinateur[] {
    return [
      {
        name: "Swift 3",
        brand: "Acer",
        price: 700
      },
      {
        name: "Katana GF66",
        brand: "msi",
        price: 1100
      },
    ]
  }
}
