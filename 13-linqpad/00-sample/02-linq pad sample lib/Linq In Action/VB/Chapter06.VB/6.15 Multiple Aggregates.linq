<Query Kind="VBStatements">
  <Connection>
    <ID>65e0892b-2c67-48c8-9d4f-3aa69a59de16</ID>
    <Server>.\SQLEXPRESS</Server>
    <Persist>true</Persist>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
     <AttachFileName>&lt;ApplicationData&gt;\LINQPad\Samples\LINQ in Action\lia6-8.mdf</AttachFileName>
  </Connection>
  <Namespace>System.Data.Linq.Mapping</Namespace>
</Query>

Dim dataContext As DataContext = Me

Dim books = dataContext.GetTable(Of Book)()
Dim query = From book In books _
			Group By key = book.Subject Into Group _
			Select id = key, _
				BookCount = Group.Count, _
				TotalPrice = Group.Sum(Function(_book) _book.Price), _
				LowPrice = Group.Min(Function(_book) _book.Price), _
				HighPrice = Group.Max(Function(_book) _book.Price), _
				AveragePrice = Group.Average(Function(_book) _book.Price)
	
query.Dump()
