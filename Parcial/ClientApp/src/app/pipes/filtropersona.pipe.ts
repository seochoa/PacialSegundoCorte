import { Pipe, PipeTransform } from '@angular/core';
import { Persona } from '../Models/persona';

@Pipe({
  name: 'filtropersona'
})
export class FiltropersonaPipe implements PipeTransform {

  transform(Persona: Persona[], searchText: string): any {
    if (searchText == null) return Persona;
    return Persona.filter(p =>
      p.documento.indexOf(searchText) !== -1);
  }

}
