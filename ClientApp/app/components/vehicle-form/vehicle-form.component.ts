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

  constructor(private _makeService: MakeService, private _featureService: FeatureService) { }

  ngOnInit() {
    this._makeService.getMakes().subscribe(m => {
      this.makes = m;
      console.log("Make: ", this.makes);
    });

    this._featureService.getFeatures().subscribe(f => {this.features = f})
  }

  onMakeChange() {
    console.log("VEHICLE MAKE CHOSEN: ", this.vehicle);
    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    console.log("SELECTED MAKE: ", selectedMake);
    this.models = selectedMake? selectedMake.models:[];
    console.log("POPULATE MODELS: ", this.models);
  }

}
