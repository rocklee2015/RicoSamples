<Query Kind="Statements">
  <Connection>
    <ID>65e0892b-2c67-48c8-9d4f-3aa69a59de16</ID>
    <Server>.\SQLEXPRESS</Server>
    <Persist>true</Persist>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
     <AttachFileName>&lt;ApplicationData&gt;\LINQPad\Samples\LINQ in Action\lia6-8.mdf</AttachFileName>
  </Connection>
</Query>

//6.15: Multiple Aggregates
//LINQPad abstracts the context. We'll set it to this.
DataContext dataContext = this;

var books = dataContext.GetTable<Book>();
var query =
  	from book in books
	group book by book.Subject into groupedBooks
	select new 
	{
		groupedBooks.Key,
		TotalPrice = groupedBooks.Sum(b => b.Price),
		LowPrice = groupedBooks.Min(b => b.Price),
		HighPrice = groupedBooks.Max(b => b.Price),
		AveragePrice = groupedBooks.Average(b => b.Price)
	};
  
query.Dump();