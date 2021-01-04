import { Component, OnInit } from '@angular/core';
import {Restaurant} from '../../models/restaurants/restaurant.model';
import {ActivatedRoute, Router} from '@angular/router';
import {FormBuilder} from '@angular/forms';
import {RestaurantService} from '../../services/restaurant.service';
import {RestaurantParams} from '../../models/restaurants/restaurant-params';
import {RestaurantDetails} from '../../models/restaurants/restaurant-details.model';

@Component({
  selector: 'app-restaurant-result',
  templateUrl: './restaurant-result.component.html',
  styleUrls: ['./restaurant-result.component.scss']
})
export class RestaurantResultComponent implements OnInit {
  restaurantDetails: RestaurantDetails = new RestaurantDetails();
  max = 5;
  rating: number = 0;

  constructor(private router: Router, private formBuilder: FormBuilder,
              private restaurantService: RestaurantService,
              private route: ActivatedRoute) {



    this.route.paramMap.subscribe(params => {
      this.restaurantDetails.id = params.get('id')?.toString();
    });
    const restaurantParams: RestaurantParams = {
      id: this.restaurantDetails.id
    };

    this.restaurantService.getRestaurant(restaurantParams).subscribe(res => {
      this.restaurantDetails = res;
      this.rating = res?.rating;
    }, error => console.log(error));
  }
  ngOnInit(): void {
  }

}
