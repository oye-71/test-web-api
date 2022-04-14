import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { ErrorHandler, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Ordinateur, OrdinateurDto } from '../models/ordinateur';
import { MagasinWithComputers } from '../models/magasin';

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

  public deleteComputer(ordinateurId: string): Observable<void> {
    let options = this.createBaseOptions()
    options.params = {
      computerId: ordinateurId
    }
    // On fait le delete en get pour éviter les soucis de CORS (header Allow-Method)
    return this._http.get<void>(environment.ordinateursUrl + "DeleteComputerById", options)
  }

  public getMagasinWithStocks(){
    let options = this.createBaseOptions()
    return this._http.get<MagasinWithComputers>(environment.ordinateursUrl + "GetAllMagasinWithComputers", options)
  }

  private createBaseOptions(): { headers: HttpHeaders, params: any } {
    return {
      headers: new HttpHeaders({
        'ComputersApiKey': environment.serverApiKey
      }),
      params: null
    }
  }
}
