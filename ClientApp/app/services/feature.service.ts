import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class FeatureService {

  constructor(private _http:Http) { }

  getFeatures(){
    return this._http.get('api/features')
    .map(resp => resp.json())
  }

}
