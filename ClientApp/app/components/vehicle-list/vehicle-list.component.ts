import { Component, OnInit } from '@angular/core';
import { Vehicle } from '../../models/Vehicle';
import { VehicleService } from '../../services/vehicle.service';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {
  vehicles: Vehicle[];

  constructor(private _vehicleService: VehicleService) {}

  ngOnInit() {
    this._vehicleService.allVehicles().subscribe(vehicles => {this.vehicles = vehicles;
      console.log('~~~~~', this.vehicles);});
  }

}
