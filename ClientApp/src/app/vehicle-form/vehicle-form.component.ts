import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../services/vehicle.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any[];
  models: any[];
  vehicle: any = {
    features: [],
    contact: {}
  };
  features: any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private vehicleService: VehicleService
  ) {
    route.params.subscribe(data => {
      this.vehicle.id = +data['id'];
    });
  }

  ngOnInit() {
    this.vehicleService.getVehicle(this.vehicle.id)
      .subscribe(data => {
        this.vehicle = data;
      });

    this.vehicleService.getMakes().subscribe((data: any[]) => {
      this.makes = data;
    });
    this.vehicleService.getFeatures().subscribe((data: any[]) => {
      this.features = data;
    });
  }

  onMakeChange() {
    // tslint:disable-next-line:triple-equals
    const selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models : [];
    delete this.vehicle.modelId;
  }

  onFeatureToggle(featureId, $event) {
    if ($event.target.checked) {
      this.vehicle.features.push(featureId);
    }
    // when we uncheck the checkbox then checkbox value must pull from array
    // tslint:disable-next-line:one-line
    else {
      const index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }
  }

  submit() {
    this.vehicleService.create(this.vehicle)
      .subscribe(data => console.log(data));
  }
}
