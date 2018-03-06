<Query Kind="Statements">
  <Reference Relative="..\LinqInAction.LinqBooks.Common.dll">D:\00-github\00-Rocklee2015\RicoSamples\13-linqpad\00-sample\02-linq pad sample lib\queries\LinqInAction.LinqBooks.Common.dll</Reference>
  <Namespace>LinqInAction.LinqBooks.Common</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

// Section 4.4.2

// With Select
IEnumerable<IEnumerable<Author>> tmp1 = SampleData.Books.Select(book => book.Authors);
tmp1.Dump("With Select");
foreach (var authors in tmp1)
{
  foreach (var author in authors)
  {
    author.LastName.Dump();
  }
}

// With SelectMany
IEnumerable<Author> tmp2 = SampleData.Books.SelectMany(book => book.Authors);
tmp2.Dump("With SelectMany");
foreach (var author in tmp2)
{
  author.LastName.Dump();
}

var bookAuthors =
  from book in SampleData.Books
  from author in book.Authors
  select author.LastName;
bookAuthors.Dump("With a double from");