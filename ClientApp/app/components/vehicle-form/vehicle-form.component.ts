import { Component, OnInit } from '@angular/core';
import { MakeService } from '../../services/make.service'

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any[];
  models: any[];
  vehicle:any = {};

  constructor(private _makeService: MakeService) { }

  ngOnInit() {
    this._makeService.getMakes().subscribe(m => {
      this.makes = m;
      console.log("Make: ", this.makes);
    });
  }

  onMakeChange() {
    console.log("VEHICLE MAKE CHOSEN: ", this.vehicle);
    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    console.log("SELECTED MAKE: ", selectedMake);
    this.models = selectedMake? selectedMake.models:[];
    console.log("POPULATE MODELS: ", this.models);
  }

}
