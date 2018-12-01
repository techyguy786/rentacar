import { Component, OnInit } from '@angular/core';
import { MakeService } from '../services/make.service';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any[];
  models: any[];
  vehicle: any = {};
  features: any;

  constructor(private makeService: MakeService) { }

  ngOnInit() {
    this.makeService.getMakes().subscribe((data: any[]) => {
      this.makes = data;
    });
    this.makeService.getFeatures().subscribe((data: any[]) => {
      this.features = data;
    });
  }

  onMakeChange() {
    // tslint:disable-next-line:triple-equals
    const selectedMake = this.makes.find(m => m.makeId == this.vehicle.make);
    this.models = selectedMake ? selectedMake.models : [];
  }
}
