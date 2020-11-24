import gql from 'graphql-tag';

export const CREATE_AUTHOR = gql`
  mutation($input: AuthorInput!) {
    createAuthor(input: $input){
      id
      name
    }
  }
`;

export const UPDATE_AUTHOR = gql`
  mutation($id: ID!, $input: AuthorInput!) {
    updateAuthor(id: $id, input: $input){
      id
      name
    }
  }
`;

export const DELETE_AUTHOR = gql`
  mutation($id: ID!) {
    deleteAuthor(id: $id){
      id
    }
  }
`;
