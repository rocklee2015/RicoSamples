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

//6.12: Sorting with LINQ to SQL
//LINQPad abstracts the context. We'll set it to this.
DataContext dataContext = this;

var books = dataContext.GetTable<Book>();
var query =
  	from book in books
	where book.Price < 30
	orderby book.Title
  	select book.Title;
  
query.Dump();