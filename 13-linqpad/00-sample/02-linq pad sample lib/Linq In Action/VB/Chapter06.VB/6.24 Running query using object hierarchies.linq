<Query Kind="VBStatements">
  <Connection>
    <ID>65e0892b-2c67-48c8-9d4f-3aa69a59de16</ID>
    <Server>.\SQLEXPRESS</Server>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\Samples\LINQ in Action\lia6-8.mdf</AttachFileName>
  </Connection>
  <Namespace>System.Data.Linq.Mapping</Namespace>
</Query>

Dim dataContext As DataContext = Me

Dim subjects = dataContext.GetTable(Of Subject)()

Dim query = From subject in subjects _
			Order By subject.Name _
			Select subject.Name, _
				Books = From book in subject.Books _
						Where book.Price < 30 _
						Select book.Title, book.Price
	
query.Dump()