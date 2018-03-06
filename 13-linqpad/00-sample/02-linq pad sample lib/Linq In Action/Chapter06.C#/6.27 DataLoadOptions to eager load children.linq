<Query Kind="Statements">
  <Connection>
    <ID>65e0892b-2c67-48c8-9d4f-3aa69a59de16</ID>
    <Server>.\SQLEXPRESS</Server>
    <Persist>true</Persist>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
     <AttachFileName>&lt;ApplicationData&gt;\LINQPad\Samples\LINQ in Action\lia6-8.mdf</AttachFileName>
  </Connection>
  <Reference>C:\Projects\LinqInAction\Samples\LinqPad\ObjectDumper.dll</Reference>
</Query>

//6.25: Lazy loading child objects
//LINQPad abstracts the context. We'll set it to this.
DataContext dataContext = this;

DataLoadOptions options = new DataLoadOptions();
options.LoadWith<Subject>(Subject => Subject.Books);
dataContext.LoadOptions = options;

var subjects = dataContext.GetTable<Subject>();

ObjectDumper.Write(subjects,1);