import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../../services/vehicle.service'
import { Event } from '@angular/router/src/events';
import { Router } from '@angular/router/src/router';
import { ToastyService } from 'ng2-toasty';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any[];
  models: any[];
  vehicle:any = {
    features: [],
    contact: {},
  };
  features: any[];
  private _allFeatures: any[];

  constructor(private _vehicleService: VehicleService, private _toastyService: ToastyService) { }

  ngOnInit() {
    this._vehicleService.getMakes().subscribe(m => 
    {
      this.makes = m;
      // console.log("Make: ", this.makes);
    });

    this._vehicleService.getFeatures().subscribe(f => {
      this._allFeatures = f;
    })
  }

  onMakeChange() {
    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);

    this.models = selectedMake? selectedMake.models:[];
    // console.log("POPULATE MODELS: ", this.models);
    delete this.vehicle.modelId;
  }

  onModelChange() {
    this.features = [];
    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    if (selectedMake != null)
    {
      var selectedModel = this.models.find(model => model.id == this.vehicle.modelId);
      
      let modelFeaturesOfSelectedModel = selectedModel.modelFeatures;
  
      modelFeaturesOfSelectedModel.map( (mf:any) => 
      {
        this.features.push(this._allFeatures.find(f => f.id == mf.featureId));
      });
    }
  }

  onFeatureToggle(featureId: number, $event: any) {
    if ($event.target.checked) {
      this.vehicle.features.push(featureId);
    } else {
      var index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }
  }

  submit() {
    this._vehicleService.create(this.vehicle)
    .subscribe(
      v => console.log(v));
  }

}
