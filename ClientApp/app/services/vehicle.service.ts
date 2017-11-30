import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { resetFakeAsyncZone } from '@angular/core/testing';

@Injectable()
export class VehicleService {

  constructor(private _http: Http) { }
  getMakes() {
    return this._http.get('/api/makes').map(resp => resp.json());
  }

  getFeatures() {
    return this._http.get('api/features')
      .map(resp => resp.json())
  }

  create(vehicle:any) {
    return this._http.post('api/vehicles', vehicle).map(resp => resp.json())
  }

  getVehicle(id: number) {
    return this._http.get('api/vehicles/' + id).map(resp => resp.json())
  }
}
