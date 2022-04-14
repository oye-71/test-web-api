import { Component, OnInit } from '@angular/core';
import { OrdinateurDto } from '../models/ordinateur';
import { ComputerService } from '../services/computer.service';

@Component({
  selector: 'app-computers-page',
  templateUrl: './computers-page.component.html',
  styleUrls: ['./computers-page.component.scss']
})
export class ComputersPageComponent implements OnInit {
  subtitle: string = "Vrais ordinateurs"
  computerDtos: OrdinateurDto[] = []
  
  constructor(
    private _ordinateurService: ComputerService
  ) { }

  ngOnInit(): void {
    this.loadData()
  }

  loadData(): void {
    this._ordinateurService.getComputers().subscribe(elements => this.computerDtos = elements)
  }

  onDeleteComputer(cptid: string): void {
    this._ordinateurService.deleteComputer(cptid).subscribe(
      null,
      err => console.error(err),
      () => {
        this.loadData()
      } 
    )
  }
}
