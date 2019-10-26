import { Injectable } from '@angular/core';
import { ServicesModule } from './services.module';
import { UserInterface } from '../entities/typings';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: ServicesModule
})
export class ManagerService {

  constructor(private _http: HttpClient) {

  }

  createNewUser(user: UserInterface): Observable<any> {
    return this._http.post('https://localhost:44336/api/user', {entity: user})
    return this._http.get('https://localhost:44336/api/user')
  }

}
