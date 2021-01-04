import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {BaseApiService} from './base-api.service';
import {Observable, Observer} from 'rxjs';

import {RestaurantParams} from '../models/restaurants/restaurant-params';
import {map} from 'rxjs/operators';
import {RestaurantRatingParams} from '../models/restaurantRatings/restaurant-rating-params';
import {RestaurantRating} from '../models/restaurantRatings/restaurant-rating.model';
import {Restaurant} from '../models/restaurants/restaurant.model';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService extends BaseApiService<Restaurant> {

  constructor(protected httpClient: HttpClient) {
    super(httpClient, 'restaurants');
  }

  /*getRestaurantList<T>(): Observable<T> {
    return ;
  }*/

  getRestaurants(restaurantParams?: RestaurantParams): Observable<Restaurant[] | null> {
    const options = {
      route: '/all-restaurants'
    };
    this.initOptionsRoute(options);
    const params = this.setRestaurantParams(restaurantParams);
    return this.findAll(params);

    /*return this.httpClient.get<Restaurant[]>('http://localhost:5000/api/restaurants/all-restaurants')
      .pipe(
        map(res => {
          console.log(res);
          return res;
        })
      );*/
  }

  private setRestaurantParams(restaurantParams?: RestaurantParams | undefined): HttpParams {
    let params = new HttpParams();

    if (restaurantParams?.name) {
      params = params.append('name', restaurantParams?.name);
    }

    if (restaurantParams?.description) {
      params = params.append('description', restaurantParams?.description.toString());
    }

    return params;
  }

  postRestaurants(restaurantParams?: RestaurantRating) {
    const options = {
      route: '/post-restaurant'
    };
    this.initOptionsRoute(options);
    const params = this.setCreateRestaurantParams(restaurantParams);
    return this.save(params);

    /*return this.httpClient.get<Restaurant[]>('http://localhost:5000/api/restaurants/all-restaurants')
      .pipe(
        map(res => {
          console.log(res);
          return res;
        })
      );*/
  }

  private setCreateRestaurantParams(restaurantParams?: RestaurantRatingParams | undefined): HttpParams {
    let params = new HttpParams();

    if (restaurantParams?.emailUser) {
      params = params.append('emailUser', restaurantParams?.emailUser);
    }

    if (restaurantParams?.rating && restaurantParams?.rating > 0) {
      params = params.append('rating', restaurantParams?.rating.toString());
    }

    return params;
  }
}
