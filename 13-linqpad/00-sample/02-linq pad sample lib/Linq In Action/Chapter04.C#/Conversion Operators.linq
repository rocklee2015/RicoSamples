<Query Kind="Statements">
  <Reference Relative="..\LinqInAction.LinqBooks.Common.dll">D:\00-github\00-Rocklee2015\RicoSamples\13-linqpad\00-sample\02-linq pad sample lib\queries\LinqInAction.LinqBooks.Common.dll</Reference>
  <Namespace>LinqInAction.LinqBooks.Common</Namespace>
</Query>

// Section 4.4.4

IEnumerable<String> titles = SampleData.Books.Select(book => book.Title);

String[] array = titles.ToArray();
array.Dump("ToArray");

List<String> list = titles.ToList();
list.Dump("ToList");

Console.WriteLine("ToDictionary:");
Dictionary<String, Book> isbnRef = SampleData.Books.ToDictionary(book => book.Isbn);
Book linqRules = isbnRef["0-111-77777-2"];
Console.WriteLine("Book found: " + linqRules);