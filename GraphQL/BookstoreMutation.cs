using GraphQL.Types;
using GraphQLBookstore.Repositories;
using GraphQLBookstore.GraphQL.Types;
using GraphQLBookstore.Models;

namespace GraphQLBookstore.GraphQL
{
    public class BookstoreMutation : ObjectGraphType
    {
        AuthorRepository _authorRepository;
        BookRepository _bookRepository;
        public BookstoreMutation(AuthorRepository authorRepository, BookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            this.AuthorMutations();
            this.BookMutations();
        }

        private void AuthorMutations() {
            FieldAsync<AuthorType>(
                "createAuthor",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AuthorInputType>> { Name = "input", Description = "Author object" }
                ),
                resolve: async context => {
                    var author = context.GetArgument<Author>("input");
                    return await context.TryAsyncResolve(
                        async c => await _authorRepository.Add(author)
                    );
                }
            );

            FieldAsync<AuthorType>(
                "updateAuthor",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "id of the author to update" },
                    new QueryArgument<NonNullGraphType<AuthorInputType>> { Name = "input", Description = "Author object" }
                ),
                resolve: async context => {
                    var id = context.GetArgument<long>("id");
                    var author = context.GetArgument<Author>("input");
                    return await context.TryAsyncResolve(
                        async c => await _authorRepository.Update(id, author)
                    );
                }
            );

            FieldAsync<AuthorType>(
                "deleteAuthor",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "id of the author to remove" }
                ),
                resolve: async context => {
                    var id = context.GetArgument<long>("id");
                    return await context.TryAsyncResolve(
                        async c => await _authorRepository.Remove(id)
                    );
                }
            );
        }

        private void BookMutations() {
            FieldAsync<BookType>(
                "createBook",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BookInputType>> { Name = "input", Description = "Book object" }
                ),
                resolve: async context => {
                    var book = context.GetArgument<Book>("input");
                    return await context.TryAsyncResolve(
                        async c => await _bookRepository.Add(book)
                    );
                }
            );

            FieldAsync<BookType>(
                "updateBook",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "id of the book to update" },
                    new QueryArgument<NonNullGraphType<BookInputType>> { Name = "input", Description = "Book object" }
                ),
                resolve: async context => {
                    var id = context.GetArgument<long>("id");
                    var book = context.GetArgument<Book>("input");
                    return await context.TryAsyncResolve(
                        async c => await _bookRepository.Update(id, book)
                    );
                }
            );

            FieldAsync<BookType>(
                "deleteBook",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "id of the book to remove" }
                ),
                resolve: async context => {
                    var id = context.GetArgument<long>("id");
                    return await context.TryAsyncResolve(
                        async c => await _bookRepository.Remove(id)
                    );
                }
            );
        }
    }
}
