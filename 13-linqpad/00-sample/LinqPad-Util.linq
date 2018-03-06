<Query Kind="Statements">
  <Namespace>System.Net</Namespace>
</Query>

//当前query路径
Util.CurrentQueryPath.Dump();

Util.GetSamplesFolder().Dump();

Util.GetFullPath("LinqPad-Util").Dump();

//下载图片构造xml
var eatThis = new {
Image=Util.Image(new WebClient().DownloadData("http://images.cnblogs.com/cnblogs_com/luminji/586782/o_book1.jpg")),
Xml=XElement.Parse("<root type='foo'><inner>test</inner></root>"),

};

eatThis.Dump();