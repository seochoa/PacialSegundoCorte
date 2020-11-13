import { Vacuna } from './vacuna';
export class Persona {
    tipodocumeto: string;
    documento: string;
    nombre: string;
    fechanac: Date;
    institucion: string;
    nombreacudiente: string; 
    vacunas : Vacuna[];  
}
