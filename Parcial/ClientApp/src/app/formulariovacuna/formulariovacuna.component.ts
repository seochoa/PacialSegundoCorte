import { Component, OnInit, Input } from '@angular/core';
import { Persona } from '../Models/persona';

@Component({
  selector: 'app-formulariovacuna',
  templateUrl: './formulariovacuna.component.html',
  styleUrls: ['./formulariovacuna.component.css']
})
export class FormulariovacunaComponent implements OnInit {

  @Input() persona :Persona;
  constructor() { }

  ngOnInit(): void {
    this.persona = new Persona();
  }

}
