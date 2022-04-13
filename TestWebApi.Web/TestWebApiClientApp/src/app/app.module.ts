import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SecondPageComponent } from './second-page/second-page.component';
import { HttpClientModule } from '@angular/common/http';
import { ComputersPageComponent } from './computers-page/computers-page.component';

@NgModule({
  declarations: [
    AppComponent,
    SecondPageComponent,
    ComputersPageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
