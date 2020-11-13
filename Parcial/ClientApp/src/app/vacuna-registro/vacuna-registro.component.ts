import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormularioregistroComponent } from '../formularioregistro/formularioregistro.component';
import { FormulariovacunaComponent } from '../formulariovacuna/formulariovacuna.component';
import { PersonaService } from '../Service/persona.service';
import { Persona } from '../Models/persona';


@Component({
  selector: 'app-vacuna-registro',
  templateUrl: './vacuna-registro.component.html',
  styleUrls: ['./vacuna-registro.component.css']
})
export class VacunaRegistroComponent implements OnInit {
  persona: Persona;
  personas: Persona[];
  searchpersona:string;
  constructor(private modalService : NgbModal,private personaService:PersonaService) { }

  ngOnInit(): void {
    this.consultar();
  }

  registerpersona(){
    const menssageBox = this.modalService.open(FormularioregistroComponent)
  }

  consultar(){
    this.personaService.gets().subscribe(result =>{
      this.personas = result;
      console.log(result);
    });
  }

  vacunar(personavacunar : Persona){
    const menssageBox = this.modalService.open(FormulariovacunaComponent)
    
    menssageBox.componentInstance.personavacunar = personavacunar;
  }

  
}
