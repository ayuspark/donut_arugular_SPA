import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../../services/vehicle.service'
import { Event, ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { ToastyService } from 'ng2-toasty';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/Observable/forkJoin';
import { SaveVehicle, Vehicle, KeyValuePair } from '../../models/Vehicle';


@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any[];
  models: any[];
  vehicle: SaveVehicle = {
    id: 0,
    makeId: 0,
    modelId: 0,
    isRegistered: false,
    features: [],
    contact: {
      name: '',
      phone: '',
      email: '',
    },
  }
  features: KeyValuePair[];
  private _allFeatures: any[];

  constructor(
    private _vehicleService: VehicleService, 
    private _toastyService: ToastyService,
    private route: ActivatedRoute,
    private router: Router,) { 
      route.params.subscribe(p => {
        this.vehicle.id = +p['id'];
      });
    }

  ngOnInit() {
    var sources = [
      this._vehicleService.getMakes(),
      this._vehicleService.getFeatures(),
    ]
    // if route is /vehicles/new, this.vehicle.id = NaN
    if (this.vehicle.id) {
      sources.push(this._vehicleService.getVehicle(this.vehicle.id))
    }

    Observable.forkJoin(sources)
      .subscribe(
        data => {
          this.makes = data[0];
          this._allFeatures = data[1];

          if (this.vehicle.id) {
            this.setVehicle(data[2]);
            this.populateModels();
          }
        }, 
        err => {
          if (err.status == 404) {
            this.router.navigate(['/home']);
          }
        })

    //+++++++++++ SEPARATE SUBSCRIBE ++++++++++++++++++++++++++
    // this._vehicleService.getMakes().subscribe(m => 
    // {
    //   this.makes = m;
    //   // console.log("Make: ", this.makes);
    // });

    // this._vehicleService.getFeatures().subscribe(f => {
    //   this._allFeatures = f;
    // })

    // this._vehicleService.getVehicle(this.vehicle.id).subscribe( v=> {
    //   this.vehicle = v;
    // }, err => {
    //   if (err.status == 404) {
    //     this.router.navigate(['/home']);
    //   }
    // })
    // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++
  }

  onMakeChange() {
    this.populateModels();
    delete this.vehicle.modelId;
  }

  private populateModels() {
    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models : [];

    this.populateFeatures();
  }

  private populateFeatures() {
    let selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    let modelFeaturesOfSelectedModel = []; 
    this.features = [];
    if (selectedMake != null)
    {
      var selectedModel = this.models.find(model => model.id == this.vehicle.modelId);
      
      if (selectedModel != null) {
        modelFeaturesOfSelectedModel = selectedModel.modelFeatures;
      }
      console.log("mf: ", modelFeaturesOfSelectedModel);
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
    if (this.vehicle.id) {
      this._vehicleService.update(this.vehicle).subscribe(u => {
        this.setVehicle(u);
        this._toastyService.success({
          title: "Success",
          msg: "The vehicle was successfully updated.",
          theme: "bootstrap",
          showClose: true,
          timeout: 5000,
        })
      });
    } else {
      delete this.vehicle.id; // cannot create new entry with id, so delete
      this._vehicleService.create(this.vehicle)
      .subscribe(
        v => console.log(v));
    }
  }

  private setVehicle(v: Vehicle): void {
    this.vehicle.id = v.id;
    this.vehicle.makeId = v.make.id;
    this.vehicle.modelId = v.model.id;
    v.features.map(f => this.vehicle.features.push(f.id));
    this.vehicle.isRegistered = v.isRegistered;
    this.vehicle.contact = v.contact;
  }

}
