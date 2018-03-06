<Query Kind="Statements">
  <Reference Relative="..\LinqInAction.LinqBooks.Common.dll">D:\00-github\00-Rocklee2015\RicoSamples\13-linqpad\00-sample\02-linq pad sample lib\queries\LinqInAction.LinqBooks.Common.dll</Reference>
  <Namespace>LinqInAction.LinqBooks.Common</Namespace>
</Query>

// Section 4.4.2

IEnumerable<String> titles1 = SampleData.Books.Select(book => book.Title);
titles1.Dump();

titles1 =
  from book in SampleData.Books
  select book.Title;
titles1.Dump();

var publishers =
  from book in SampleData.Books
  select book.Publisher;
publishers.Dump();

var books =
  from book in SampleData.Books
  select new { book.Title, Publisher = book.Publisher.Name, book.Authors };
books.Dump();