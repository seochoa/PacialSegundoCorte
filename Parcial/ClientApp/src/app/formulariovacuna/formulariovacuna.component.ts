import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Persona } from '../Models/persona';
import { PersonaService } from '../Service/persona.service';
import { Vacuna } from '../Models/vacuna';
import { AlertModalComponent } from '../@base/alert-modal/alert-modal.component';

@Component({
  selector: 'app-formulariovacuna',
  templateUrl: './formulariovacuna.component.html',
  styleUrls: ['./formulariovacuna.component.css']
})
export class FormulariovacunaComponent implements OnInit {

  @Input() personavacunar :Persona;
  formGroupVacuna: FormGroup;
  vacuna: Vacuna;
  vacunas: Vacuna[];
  constructor(public activeModal: NgbActiveModal,private personaService : PersonaService, private formbuilder : FormBuilder,private modalService : NgbModal) { }

  ngOnInit(): void {
    this.buildform();
  }

  private buildform(){
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

  get control2(){
    return this.formGroupVacuna.controls;
  }

  onSave(){
    if(this.formGroupVacuna.invalid ){
      return;
    }
    this.add();
 
  }

  onReset(){
    this.formGroupVacuna.reset();
  }

  add(){
    this.vacuna = this.formGroupVacuna.value;
    const dateOfBorn = new Date(this.personavacunar.fechanac);
    const dateOfVaccine = new Date(this.vacuna.fechavacuna);
    const timeDiff = Math.abs(dateOfVaccine.getTime() - dateOfBorn.getTime());
    this.vacuna.edadaplicacion = Math.floor((timeDiff / (1000 * 3600 * 24)) / 365);
    this.vacunas = this.personavacunar.vacunas;
    this.vacunas.push(this.vacuna);
    this.personavacunar.vacunas = this.vacunas;
    console.log(this.personavacunar);
    this.personaService.postvacunas(this.personavacunar).subscribe(p=>{
      const menssageBox = this.modalService.open(AlertModalComponent)
      menssageBox.componentInstance.type = "success";
      menssageBox.componentInstance.message = 'Vacuna Registrada Correctamente';
      this.activeModal.close();
    });
    this.onReset();
  }


}
