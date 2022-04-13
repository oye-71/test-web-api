import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ComputersPageComponent } from './computers-page/computers-page.component';
import { SecondPageComponent } from './second-page/second-page.component';


const routes: Routes = [
  {
    path: "computers",
    component: SecondPageComponent
  },
  {
    path: "realComputers",
    component: ComputersPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
