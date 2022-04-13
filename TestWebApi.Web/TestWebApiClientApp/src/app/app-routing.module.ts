import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddComputerComponent } from './add-computer/add-computer.component';
import { ComputersPageComponent } from './computers-page/computers-page.component';
import { SecondPageComponent } from './second-page/second-page.component';


const routes: Routes = [
  {
    path: "",
    component: SecondPageComponent
  },
  {
    path: "realComputers",
    component: ComputersPageComponent
  },
  {
    path: "addComputer",
    component: AddComputerComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
