import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { VacunaConsultaComponent } from './vacuna-consulta/vacuna-consulta.component';
import { VacunaRegistroComponent } from './vacuna-registro/vacuna-registro.component';
import { FormularioregistroComponent } from './formularioregistro/formularioregistro.component';
import { AlertModalComponent } from './@base/alert-modal/alert-modal.component';
import { FormulariovacunaComponent } from './formulariovacuna/formulariovacuna.component';
import { FiltropersonaPipe } from './pipes/filtropersona.pipe';




@NgModule({
  declarations: [
    AlertModalComponent,
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    VacunaConsultaComponent,
    VacunaRegistroComponent,
    FormularioregistroComponent,
    FormulariovacunaComponent,
    FiltropersonaPipe,
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'registro', component: VacunaRegistroComponent },
      { path: 'consulta', component: VacunaConsultaComponent},
      { path: '', component: HomeComponent, pathMatch: 'full' },
    ]),
    NgbModule
  ],
  entryComponents: [FormularioregistroComponent,AlertModalComponent,FormulariovacunaComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
