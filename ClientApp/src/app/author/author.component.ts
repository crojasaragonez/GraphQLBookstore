import { Component } from '@angular/core';
import {Apollo} from 'apollo-angular';
import { AUTHORS_QUERY } from './queries';
import { CREATE_AUTHOR, UPDATE_AUTHOR, DELETE_AUTHOR } from './mutations';
import { Author } from './author.interface';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent {
  authors: Author[];
  currentAuthor: Author;
  loading = true;
  name: '';
  error: any;
  is_editting = false;
  constructor(private apollo: Apollo) {
    this.currentAuthor = { id: -1, name: '' };
    this.filter();
  }

  save(){
    let mutation = CREATE_AUTHOR;
    const variables = {
      input: { name: this.currentAuthor.name }
    };
    if(this.currentAuthor.id > 0) {
      variables['id'] = this.currentAuthor.id;
      mutation = UPDATE_AUTHOR;
    }
    this.apollo.mutate({
      mutation: mutation,
      variables: variables
    }).subscribe(() => {
      this.currentAuthor = { id: -1, name: '' };
      this.is_editting = false;
      this.filter();
    },(error) => {
      console.log('there was an error sending the query', error);
    });
  }

  delete(author){
    this.apollo.mutate({
      mutation: DELETE_AUTHOR,
      variables: { id: author.id }
    }).subscribe(() => {
      this.filter();
    },(error) => {
      console.log('there was an error sending the query', error);
    });
  }

  edit(author) {
    this.currentAuthor = {...author};
    this.is_editting = true;
  }

  filter(){
    this.apollo.watchQuery({
      query: AUTHORS_QUERY,
      fetchPolicy: 'network-only',
      variables: {
        name: this.currentAuthor.name
      }
    }).valueChanges.subscribe(result => {
      this.authors = result.data && result.data['authors'];
      this.loading = result.loading;
      this.error = result.error;
    })
  }
}
