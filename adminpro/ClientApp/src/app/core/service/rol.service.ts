import {Injectable} from '@angular/core';
import {Rol} from '../model/rol';

import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';


@Injectable({
  providedIn: 'root'
})


export class RolService {
  baseUrl: string;

  constructor(protected httpClient: HttpClient) {

    this.baseUrl = 'https://localhost:44308/api/roles/'; // esto es la url osea  donde basa apungar para hacer get
  }

  getAll(): Observable<Rol[]> {
    return this.httpClient.get<Rol[]>(this.baseUrl + '/get');
  }

  create(rol: Rol): Observable<any> { // este metodo crea un artista  y recive un  artista por parametro
    return this.httpClient.post(this.baseUrl + '/guardar', rol);
  }

  delete(id: string): Observable<Rol> { // elimina
    return this.httpClient.delete<Rol>(this.baseUrl + '/eliminar/' + id);
  }

  update(idrol: number, rol: Rol): Observable<any> {// este actualiza
    // return this.httpClient.put(`${this.baseUrl}/${idArtista}`, artista);
    return this.httpClient.post(this.baseUrl + '/actualizar/' + idrol, rol);
    // return this.httpClient.post<Artista>(this.baseUrl + '/actualizar/' + idArtista , artista);
  }

  // para obtener rol falta los id
  //   getId(id: string)  Observable < rol> {
  // return this.httpClient.
  //   }
}
