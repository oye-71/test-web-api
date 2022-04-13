import { Component, OnInit } from '@angular/core';
import { Ordinateur } from '../models/ordinateur';
import { ComputerService } from '../services/computer.service';

@Component({
  selector: 'app-add-computer',
  templateUrl: './add-computer.component.html',
  styleUrls: ['./add-computer.component.scss']
})
export class AddComputerComponent implements OnInit {
  public ordinateurName: string
  public ordinateurBrand: string
  public ordinateurPrice: number = 0

  constructor(
    private _computerService: ComputerService
  ) { }

  ngOnInit(): void {
  }

  onAddComputer(): void {
    let cpt: Ordinateur = {
      name: this.ordinateurName,
      brand: this.ordinateurBrand,
      price: this.ordinateurPrice
    } 
    this._computerService.addComputer(cpt).subscribe(
      res => null,
      err => console.error("Bad things happened !" + err),
      () => {
        this.ordinateurBrand = this.ordinateurName = null
        this.ordinateurPrice = 0
      }
    )
  }

  get canAdd() {
    return this.ordinateurName != null && this.ordinateurName != ""
    && this.ordinateurBrand != null && this.ordinateurBrand != ""
    && this.ordinateurPrice != null && this.ordinateurPrice != 0
  }
}
