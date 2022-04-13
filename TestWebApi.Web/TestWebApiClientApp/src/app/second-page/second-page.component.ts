import { Component, OnInit } from '@angular/core';
import { Ordinateur } from '../models/ordinateur'
import { ComputerService } from '../services/computer.service'

@Component({
  selector: 'app-second-page',
  templateUrl: './second-page.component.html',
  styleUrls: ['./second-page.component.scss']
})
export class SecondPageComponent implements OnInit {
  subtitle: string = "Liste des éléments. Ce sont des éléments de test"

  computers: Ordinateur[]

  constructor(
    private _computerService: ComputerService
  ) { }

  ngOnInit(): void {
    this.getComputers()
  }

  getComputers(): void {
    this.computers = this._computerService.getMockedComputers()
  }

}
