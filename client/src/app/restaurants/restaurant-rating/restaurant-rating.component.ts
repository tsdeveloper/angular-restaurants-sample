import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, NgForm} from '@angular/forms';
import {Restaurant} from '../../models/restaurants/restaurant.model';
import {Router} from '@angular/router';
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

  constructor(private router: Router, private formBuilder: FormBuilder, private restaurantService: RestaurantService) {
    this.createForm(new RestaurantRating());
  }


  ngOnInit(): void {
  }

  private createForm(restaurant: RestaurantRating): void {

    this.restaurantForm = this.formBuilder.group({
      rating: [restaurant.rating],
      emailUser: [restaurant.emailUser],
    });

  }

  onFormSubmit(form: FormGroup) {
    let restaurantRating = {
      emailUser: this.restaurantForm.get('emailUser')?.value,
      rating:  this.restaurantForm.get('rating')?.value,
    };

    this.restaurantService.postRestaurants(restaurantRating)
      .subscribe(res => {
          this.router.navigate(['/restaurants']);
        }, (err) => {
          console.log(err);
        }
      );
  }
}
