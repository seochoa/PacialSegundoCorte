import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Persona } from '../Models/persona';
import { PersonaService } from '../Service/persona.service';
import { Vacuna } from '../Models/vacuna';
import { AlertModalComponent } from '../@base/alert-modal/alert-modal.component';

@Component({
  selector: 'app-formularioregistro',
  templateUrl: './formularioregistro.component.html',
  styleUrls: ['./formularioregistro.component.css']
})
export class FormularioregistroComponent implements OnInit {

  formGroupPersona: FormGroup;
  formGroupVacuna: FormGroup;
  vacuna: Vacuna;
  persona: Persona;
  constructor(public activeModal: NgbActiveModal,private personaService : PersonaService, private formbuilder : FormBuilder,private modalService : NgbModal) { }

  ngOnInit(): void {
    this.buildform();

  }

  private buildform(){
    this.persona = new Persona();
    this.persona.tipodocumeto= '';
    this.persona.documento = '';
    this.persona.nombre = '';
    this.persona.fechanac = null;
    this.persona.institucion = '';
    this.persona.nombreacudiente = '';

    this.formGroupPersona = this.formbuilder.group({
      tipodocumeto       :[this.persona.tipodocumeto, Validators.required],
      documento     :[this.persona.documento, Validators.required],
      nombre     :[this.persona.nombre,Validators.required],
      fechanac     :[this.persona.fechanac,Validators.required],
      institucion    :[this.persona.institucion,Validators.required],
      nombreacudiente     :[this.persona.nombreacudiente,Validators.required],
    });

    this.vacuna = new Vacuna();
    this.vacuna.idvacuna = '';
    this.vacuna.tipovacuna = '';
    this.vacuna.fechavacuna = null;

    this.formGroupVacuna = this.formbuilder.group({
      idvacuna       :[this.vacuna.idvacuna, Validators.required],
      tipovacuna     :[this.vacuna.tipovacuna, Validators.required],
      fechavacuna     :[this.vacuna.fechavacuna,Validators.required],
    });
  }

  

  get control(){
    return this.formGroupPersona.controls;
  }

  get control2(){
    return this.formGroupVacuna.controls;
  }

  onSave(){
    if(this.formGroupPersona.invalid ){
      return;
    }
    this.add();
 
  }

  onReset(){
    this.formGroupPersona.reset();
    this.formGroupVacuna.reset();
  }

  add(){
    this.persona = this.formGroupPersona.value;
    this.personaService.post(this.persona).subscribe(p=>{
      if(p!=null){
        const menssageBox = this.modalService.open(AlertModalComponent)
        menssageBox.componentInstance.type = 'success';
        menssageBox.componentInstance.message = 'Persona registrada Correctamente';
        this.persona= p;
      }
    });
    this.onReset();
  }

 

}
