import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {NotFoundComponent} from './not-found/not-found.component';

const routes: Routes = [

  {
    path: 'restaurantes',
    loadChildren: () => import('./restaurants/restaurants.module').then(m => m.RestaurantsModule)
  },
  {path: '', redirectTo: '/', pathMatch: 'full'},
  {path: '**', component: NotFoundComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
