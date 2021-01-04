import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import { RestaurantRatingComponent } from './restaurant-rating/restaurant-rating.component';
import {MatCardModule} from '@angular/material/card';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {RatingModule} from 'ngx-bootstrap/rating';
import {RestaurantsRoutingModule} from './restaurants.routing.module';
import { RestaurantListComponent } from './restaurant-list/restaurant-list.component';
import {HttpClientModule} from '@angular/common/http';
import {BaseApiService} from '../services/base-api.service';
import {RestaurantService} from '../services/restaurant.service';
import { RestaurantResultComponent } from './restaurant-result/restaurant-result.component';



@NgModule({

  declarations: [RestaurantRatingComponent, RestaurantListComponent, RestaurantResultComponent],
  imports: [
    CommonModule,
    MatCardModule,
    FormsModule,
    RatingModule,
    RestaurantsRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  exports: [RestaurantRatingComponent, RestaurantListComponent],
  providers: [RestaurantService]
})
export class RestaurantsModule {
}
