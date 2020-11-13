import { Component, OnInit } from '@angular/core';
import { Persona } from '../Models/persona';
import { PersonaService } from '../Service/persona.service';
import { Vacuna } from '../Models/vacuna';

@Component({
  selector: 'app-vacuna-consulta',
  templateUrl: './vacuna-consulta.component.html',
  styleUrls: ['./vacuna-consulta.component.css']
})
export class VacunaConsultaComponent implements OnInit {
  personas: Persona[];
  vacunas: Vacuna[] = [];
  vacuna: Vacuna;
  contador:number = 0;
  searchvacunas: string;
  constructor(private personaService:PersonaService) { }

  ngOnInit(): void {
    this.consultar();
  }
  consultar(){
    this.personaService.gets().subscribe(result =>{
      this.personas = result;
      var personasv = this.personas;
      for(let persona of personasv){
        this.contador +=1;
        for(let vacuna of persona.vacunas){ 
          this.vacuna = vacuna;
          this.vacunas.push(this.vacuna);
          
          
        }   
      }
      console.log(this.vacunas);
      
    });
  }

  
  

}
