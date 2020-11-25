import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {AppModule} from '../app.module';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public categories: Categories[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Categories[]>(baseUrl + 'home').subscribe(result => {
      this.categories = result;
    }, error => console.error(error));
  }
}


interface Categories {
  name: string;
  slug: string;
  categoryPicUrl: string;
}