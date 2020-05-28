import { Injectable } from '@angular/core';
import {Usuario} from '../model/usuario';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  baseUrl: string;
  constructor(protected httpClient: HttpClient) {

    this['baseUrl'] = 'https://localhost:44308/api/roles/';
    // esto es la url osea  donde basa apungar para hacer get
  }

  getAll(): Observable<Usuario[]> {
    return this.httpClient.get<Usuario[]>(this.baseUrl + '/get');
  }

  create(usuario: Usuario): Observable<any> { // este metodo crea un artista  y recive un  artista por parametro
    return this.httpClient.post(this.baseUrl + '/guardar', usuario);
  }

  delete(id: string): Observable<Usuario> { // elimina
    return this.httpClient.delete<Usuario>(this.baseUrl + '/eliminar/' + id);
  }

  update(idrol: number, usuario: Usuario): Observable<any> {// este actualiza
    // return this.httpClient.put(`${this.baseUrl}/${idArtista}`, artista);
    return this.httpClient.post(this.baseUrl + '/actualizar/' + idrol, usuario);
    // return this.httpClient.post<Artista>(this.baseUrl + '/actualizar/' + idArtista , artista);
  }

  // para obtener rol falta los id
  //   getId(id: string)  Observable < rol> {
  // return this.httpClient.
  //   }
}
