import { Component, OnInit } from '@angular/core';
import {RestaurantService} from '../../services/restaurant.service';
import {RestaurantParams} from '../../models/restaurants/restaurant-params';
import {Restaurant} from '../../models/restaurants/restaurant.model';

@Component({
  selector: 'app-restaurant-list',
  templateUrl: './restaurant-list.component.html',
  styleUrls: ['./restaurant-list.component.scss']
})
export class RestaurantListComponent implements OnInit {
  public items?: Restaurant[] | null = [];
  restaurantParams = new RestaurantParams();

  constructor(private restaurantService: RestaurantService) {
        this.getRestaurants();
  }

  ngOnInit(): void {
  }
  getRestaurants(): void {
/*    this.restaurantParams.email = 'teste@email.com';
    this.restaurantParams.rate = 3;*/
    this.restaurantService.getRestaurants().subscribe(res => {
      this.items = res;
      console.log(res, this.items);
    }, error => console.log(error));
  }
}
