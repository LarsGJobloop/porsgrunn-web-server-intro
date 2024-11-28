var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Library library = new Library();

app.MapGet("/book/available", () =>
{
  return library.ListAvailableBooks();
});

app.MapPost("/loan/borrow", (LoanRequest loanRequest) =>
{
  Book? book = library.BorrowBook(loanRequest.Title);

  if (book == null)
  {
    // Vi har ingen bøker tilgjengelig
    return Results.BadRequest();
  }
  else
  {
    // Vi har en bok tilgjengelig
    return Results.Ok(book);
  }
});

app.MapPost("/loan/return", () => "Returning a book");

app.Run();
