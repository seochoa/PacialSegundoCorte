import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Persona } from '../Models/persona';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  baseUrl: string;
  constructor(
  private http: HttpClient,
  @Inject('BASE_URL') baseUrl: string,
  private handleErrorService: HandleHttpErrorService)
  {
    this.baseUrl = baseUrl;
  }

  post(persona: Persona): Observable<Persona> {
    return this.http.post<Persona>(this.baseUrl + 'api/Persona', persona)
        .pipe(
            tap(_ => this.handleErrorService.log('datos enviados')),
            catchError(this.handleErrorService.handleError<Persona>('Registrar Persona', null))
        );
  }
  get(idpersona: string): Observable<Persona> {
    return this.http.get<Persona>(this.baseUrl + 'api/Persona/'+idpersona)
        .pipe(
            tap(_ => this.handleErrorService.log('datos enviados')),
            catchError(this.handleErrorService.handleError<Persona>('Consulta Usuario', null))
        );
  }

  gets(): Observable<Persona[]> {
    return this.http.get<Persona[]>(this.baseUrl + 'api/Persona')
        .pipe(
            tap(_ => this.handleErrorService.log('datos enviados')),
            catchError(this.handleErrorService.handleError<Persona[]>('Consulta Usuario', null))
        );
  }

  postvacunas(persona: Persona):Observable<string>{
    return this.http.put<string>(this.baseUrl + 'api/Persona', persona)
    .pipe(
      tap(_ => this.handleErrorService.log('datos enviados')),
      catchError(this.handleErrorService.handleError<string>('Actualizar Persona', null))
    );
  }

}
