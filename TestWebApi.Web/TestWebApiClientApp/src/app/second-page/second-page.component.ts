import { Component, OnInit } from '@angular/core';
import { MagasinWithComputers } from '../models/magasin';
import { ComputerService } from '../services/computer.service'

@Component({
  selector: 'app-second-page',
  templateUrl: './second-page.component.html',
  styleUrls: ['./second-page.component.scss']
})
export class SecondPageComponent implements OnInit {
  subtitle: string = "Bienvenue"

  magasins: MagasinWithComputers[]

  constructor(
    private _computerService: ComputerService
  ) { }

  ngOnInit(): void {
    this.getComputers()
  }

  getComputers(): void {
    this._computerService.getMagasinWithStocks().subscribe(
      mag => this.magasins = mag,
      err => console.error(err)
    )
  }

}
