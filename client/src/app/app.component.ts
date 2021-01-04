import {Component} from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'angular-restaurant';
  public items = [{
    src: 'assets/img/avatar-1'
  }];


}
