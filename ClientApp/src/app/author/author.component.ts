import { Component } from '@angular/core';
import {Apollo} from 'apollo-angular';
import { AUTHORS_QUERY } from './queries';


@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent {

  authors: any[];
  loading = true;
  name: 'Julio';
  error: any;
  constructor(private apollo: Apollo) { }

  filter(){
    this.apollo.watchQuery({
      query: AUTHORS_QUERY,
      variables: {
        name: this.name
      }
    }).valueChanges.subscribe(result => {
      this.authors = result.data && result.data.authors;
      this.loading = result.loading;
      this.error = result.error;
    })
  }
}
