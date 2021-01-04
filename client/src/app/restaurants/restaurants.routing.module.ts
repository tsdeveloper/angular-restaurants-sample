import {NgModule} from '@angular/core';
import {RouterModule} from '@angular/router';
import {RestaurantRatingComponent} from './restaurant-rating/restaurant-rating.component';
import {RestaurantListComponent} from './restaurant-list/restaurant-list.component';
import {RestaurantComponent} from './restaurant/restaurant.component';
import {RestaurantResultComponent} from './restaurant-result/restaurant-result.component';

const restaurantsRoutes = [
  {
    path: '', component: RestaurantComponent,
    children: [

      {path: 'avaliar/:id', component: RestaurantRatingComponent, pathMatch: 'full'},
      {path: 'resumo-votacao/:id', component: RestaurantResultComponent, pathMatch: 'full'},
      {path: '', component: RestaurantListComponent, pathMatch: 'full'}
    ]
  }
];


@NgModule({
  imports: [RouterModule.forChild(restaurantsRoutes)],
  exports: [RouterModule]
})
export class RestaurantsRoutingModule {

}
