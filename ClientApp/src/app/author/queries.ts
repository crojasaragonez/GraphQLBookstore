import gql from 'graphql-tag';

export const AUTHORS_QUERY = gql`
  query($name: String){
    authors(name: $name) {
      id
      name
    }
  }
`;
