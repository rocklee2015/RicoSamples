<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Extensions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Services.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.ApplicationServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.Activation.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Services.Client.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>System.Dynamic</Namespace>
  <Namespace>System.Web.Script.Serialization</Namespace>
</Query>

void Main()
{
	Test3();
}
public void Test1()
{
	string json = "{" +
							  "\"0592\" : \"厦门市\"," +
							  "\"0351\" : \"太原市\"," +
							  "\"0411\" : \"大连市\"," +
							  "\"0459\" : \"大庆市\"" +
						  "}";
	JsonObjectReader rd = new JsonObjectReader(json);

	dynamic res = rd.GetObject();
	IDictionary<string, object> d = (IDictionary<string, object>)res;
	foreach (var item in d)
	{
		Console.WriteLine($"{item.Key} = {item.Value}");
	}
}
public void Test2()
{
	var json = "{\"Name\":\"小明\", \"Age\":25, \"Email\":\"abcd@dog.cc\"}";
	JsonObjectReader rd2 = new JsonObjectReader(json);
	dynamic res2 = rd2.GetObject();
	Console.WriteLine($"姓名：{res2.Name}");
	Console.WriteLine($"年龄：{res2.Age}");
	Console.WriteLine($"电邮：{res2.Email}");
}
public void Test3()
{
	var json = "{\"code\":200,\"msg\":\"成功\",\"content\":{\"YM51714921882795489\":{\"statu\":\"2\",\"message\":\"代发货\"}}}";
	JsonObjectReader rd2 = new JsonObjectReader(json);
	dynamic res2 = rd2.GetObject();
	Console.WriteLine($"code：{res2.code}");
	Console.WriteLine($"msg：{res2.msg}");
	Console.WriteLine($"content：{res2.content}");

	var order = res2.content["YM51714921882795489"];
	Console.WriteLine($"message：{order["message"]}");
	Console.WriteLine($"message：{order["statu"]}");
}

  

public sealed class JsonObjectReader
{
	private string innerJson = null;
	public JsonObjectReader(string json)
	{
		innerJson = json;
	}

	public dynamic GetObject()
	{
		dynamic d = new ExpandoObject();
		// 将JSON字符串反序列化
		JavaScriptSerializer s = new JavaScriptSerializer();
		object resobj = s.DeserializeObject(this.innerJson);
		// 拷贝数据
		IDictionary<string, object> dic = (IDictionary<string, object>)resobj;
		IDictionary<string, object> dicdyn = (IDictionary<string, object>)d;
		foreach (var item in dic)
		{
			dicdyn.Add(item.Key, item.Value);
		}
		return d;
	}
}
// Define other methods and classes here
