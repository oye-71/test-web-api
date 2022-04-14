import { Component, OnInit } from '@angular/core';
import { MagasinDto } from '../models/magasin';
import { Ordinateur, OrdinateurDto } from '../models/ordinateur';
import { ComputerService } from '../services/computer.service';

@Component({
  selector: 'app-add-computer',
  templateUrl: './add-computer.component.html',
  styleUrls: ['./add-computer.component.scss']
})
export class AddComputerComponent implements OnInit {
  ordinateurName: string
  ordinateurBrand: string
  ordinateurPrice: number = 0

  isLoading: boolean = false
  isLoadingStocks: boolean = false

  allOrdinateurs: OrdinateurDto[] = []
  allMagasins: MagasinDto[] = []

  selectedOrdinateurId: string = null
  selectedMagasinId: string = null
  displayStockMsg: boolean = false

  constructor(
    private _computerService: ComputerService
  ) { }

  ngOnInit(): void {
    this.loadData()
  }

  private loadData(): void {
    this._computerService.getMagasins().subscribe(mgsns => this.allMagasins = mgsns)
    this._computerService.getComputers().subscribe(cptrs => this.allOrdinateurs = cptrs)
  }

  onAddComputer(): void {
    let cpt: Ordinateur = {
      name: this.ordinateurName,
      brand: this.ordinateurBrand,
      price: this.ordinateurPrice
    }
    this.isLoading = true
    this._computerService.addComputer(cpt).subscribe(
      () => null,
      err => console.error(err),
      () => {
        this.ordinateurBrand = this.ordinateurName = null
        this.ordinateurPrice = 0
        this.isLoading = false
      }
    )
  }

  onAddStock(): void {
    this.isLoadingStocks = true
    this._computerService.addStocks(this.selectedOrdinateurId, this.selectedMagasinId).subscribe(
      res => this.displayStockMsg = !res,
      err => console.error(),
      () => {
        this.selectedOrdinateurId = null
        this.selectedMagasinId = null
        this.isLoadingStocks = false
      }
    )
  }

  get canAdd() {
    return this.ordinateurName != null && this.ordinateurName != ""
      && this.ordinateurBrand != null && this.ordinateurBrand != ""
      && this.ordinateurPrice != null && this.ordinateurPrice != 0
  }

  get canAddStocks() {
    return this.selectedMagasinId != null && this.selectedMagasinId != ""
      && this.selectedOrdinateurId != null && this.selectedOrdinateurId != ""
  }
}
