import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, NgForm} from '@angular/forms';
import {Restaurant} from '../../models/restaurants/restaurant.model';
import {ActivatedRoute, ActivatedRouteSnapshot, Router} from '@angular/router';
import {RestaurantService} from '../../services/restaurant.service';
import {Observable} from 'rxjs';
import {RestaurantRating} from '../../models/restaurantRatings/restaurant-rating.model';

@Component({
  selector: 'app-restaurant-rating',
  templateUrl: './restaurant-rating.component.html',
  styleUrls: ['./restaurant-rating.component.scss']
})
export class RestaurantRatingComponent implements OnInit {
  max = 5;
  rate = 0;
  userName = undefined;
  restaurantRating: RestaurantRating = new RestaurantRating();
  restaurantForm!: FormGroup;


  setVote(vote: number): void {
    console.log(vote);
  }

  constructor(private router: Router, private formBuilder: FormBuilder,
              private restaurantService: RestaurantService,
              private route: ActivatedRoute) {



    this.route.paramMap.subscribe(params => {
      this.restaurantRating.restaurantId = params.get('id')?.toString();
    });

    this.createForm(this.restaurantRating);
  }


  ngOnInit(): void {
  }

  private createForm(restaurant: RestaurantRating): void {

    this.restaurantForm = this.formBuilder.group({
      id: [restaurant.id],
      rating: [restaurant.rating],
      emailUser: [restaurant.emailUser],
      restaurantId: [restaurant.restaurantId],
    });


  }

  onFormSubmit(form: FormGroup) {
    const restaurantRating = {
      id: this.restaurantForm.get('id')?.value,
      emailUser: this.restaurantForm.get('emailUser')?.value,
      rating: this.restaurantForm.get('rating')?.value,
      restaurantId: this.restaurantForm.get('restaurantId')?.value,
    };

    this.restaurantService.postRestaurants(restaurantRating)
      .subscribe(res => {

        this.router.navigate(['/restaurantes/resumo-votacao', res?.id]);
        }, (err) => {
          console.log(err);
        }
      );
  }
}
