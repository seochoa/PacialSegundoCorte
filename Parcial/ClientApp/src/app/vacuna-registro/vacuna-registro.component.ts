import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormularioregistroComponent } from '../formularioregistro/formularioregistro.component';


@Component({
  selector: 'app-vacuna-registro',
  templateUrl: './vacuna-registro.component.html',
  styleUrls: ['./vacuna-registro.component.css']
})
export class VacunaRegistroComponent implements OnInit {

  constructor(private modalService : NgbModal) { }

  ngOnInit(): void {
  }

  registerpersona(){
    const menssageBox = this.modalService.open(FormularioregistroComponent)
  }

  
}
