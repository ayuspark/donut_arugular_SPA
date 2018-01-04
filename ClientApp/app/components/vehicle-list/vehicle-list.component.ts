import { Component, OnInit } from '@angular/core';
import { Vehicle, KeyValuePair } from '../../models/Vehicle';
import { VehicleService } from '../../services/vehicle.service';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {
  vehicles: Vehicle[];
  allVehicles: Vehicle[];
  makes: KeyValuePair[];
  filter: any = {};

  constructor(private _vehicleService: VehicleService) {}

  ngOnInit() {
    this._vehicleService.allVehicles().subscribe(vehicles =>
      {
        this.vehicles = vehicles;
        this.allVehicles = vehicles;
      });

    this._vehicleService.getMakes().subscribe(makes => this.makes = makes);
  }

  onFilterChange(){
    var vehicles = this.allVehicles;
    if(this.filter.makeId) {
      vehicles = vehicles.filter(v => v.make.id == this.filter.makeId);
    }
    this.vehicles = vehicles;
  }

  onResetClick(){
    this.vehicles = this.allVehicles;
  }

}
