import { Pipe, PipeTransform } from '@angular/core';
import { Vacuna } from '../Models/vacuna';

@Pipe({
  name: 'filtrovacuna'
})
export class FiltrovacunaPipe implements PipeTransform {

  transform(vacuna: Vacuna[], searchText: string): any {
    if (searchText == null) return vacuna;
    return vacuna.filter(p =>
      p.tipovacuna.indexOf(searchText) !== -1);
  }

}
