import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { ErrorHandler, Injectable } from '@angular/core';
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
    let options = this.createBaseOptions()
    return this._http.get<OrdinateurDto[]>(environment.ordinateursUrl + "GetAllComputers", options)
  }

  public addComputer(ordinateur: Ordinateur): Observable<void> {
    let options = this.createBaseOptions()
    return this._http.post<void>(environment.ordinateursUrl + "AddComputer", ordinateur, options)
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

  private createBaseOptions(): { headers: HttpHeaders } {
    return {
      headers: new HttpHeaders({
        'ComputersApiKey': environment.serverApiKey
      })
    }
  }
}
