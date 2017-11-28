import { Component, OnInit } from '@angular/core';
import { MakeService } from '../../services/make.service'
import { FeatureService } from '../../services/feature.service';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any[];
  models: any[];
  vehicle:any = {};
  features: any[];
  private _allFeatures: any[];

  constructor(private _makeService: MakeService, private _featureService: FeatureService) { }

  ngOnInit() {
    this._makeService.getMakes().subscribe(m => 
    {
      this.makes = m;
      // console.log("Make: ", this.makes);
    });

    this._featureService.getFeatures().subscribe(f => {
      this._allFeatures = f;
    })
  }

  onMakeChange() {
    console.log("VEHICLE MAKE CHOSEN: ", this.vehicle);
    this.features = [];
    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);

    this.models = selectedMake? selectedMake.models:[];
    // console.log("POPULATE MODELS: ", this.models);

    return selectedMake;
  }

  onModelChange() {
    this.features = [];
    var selectedMake = this.onMakeChange();
    var selectedModel = this.models.find(model => model.id == this.vehicle.modelId);
    
    let modelFeaturesOfSelectedModel = selectedModel.modelFeatures;

    modelFeaturesOfSelectedModel.map( (mf:any) => 
    {
      this.features.push(this._allFeatures.find(f => f.id == mf.featureId));
    });
  }

}
