import {NgModule} from '@angular/core';
import {RouterModule} from '@angular/router';
import {RestaurantRatingComponent} from './restaurant-rating/restaurant-rating.component';
import {RestaurantListComponent} from './restaurant-list/restaurant-list.component';
import {RestaurantComponent} from './restaurant/restaurant.component';

const restaurantsRoutes = [
  {
    path: '', component: RestaurantComponent,
    children: [
      {
        path: '', children: [
          {path: 'avaliar/:id', component: RestaurantRatingComponent},
          {path: '', component: RestaurantListComponent}
        ]
      }
    ]
  }
];


@NgModule({
  imports: [RouterModule.forChild(restaurantsRoutes)],
  exports: [RouterModule]
})
export class RestaurantsRoutingModule {

}
