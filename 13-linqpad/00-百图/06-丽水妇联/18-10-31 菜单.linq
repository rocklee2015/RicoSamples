<Query Kind="Program">
  <Connection>
    <ID>528e09b9-d416-4159-8623-8cca7676ec17</ID>
    <Persist>true</Persist>
    <Server>192.168.1.218</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAALPitMYg51kiwFKmWIo6xOgAAAAACAAAAAAAQZgAAAAEAACAAAADD32sJmEhByxll7PeoNmOY5pihV+KZy1+QOBtAatmx8gAAAAAOgAAAAAIAACAAAABeV1bGUZZP87CJD/h7HALpb0OSx51ZUAnA7oa2W8F4ZBAAAACy03FBNWpUXZb7SbzsTLzbQAAAAJLIXhIzwE030yp+OGNfBv7k7rOjvtsLxZjUmorkpHNtUWSJpEvhkJpvvCVp03q2F4/eHPYTo5S5zaShl6k3M+Y=</Password>
    <Database>Wfsp.Test</Database>
    <ShowServer>true</ShowServer>
  </Connection>
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
  <Namespace>System.Web.Script.Serialization</Namespace>
</Query>

void Main()
{
	var a = new List<MenuData>();
	a.Add(new MenuData()
	{
		Name = "111",
		Url = "sss",
		Icon = "ss",
		Sort=1,
		Children = new List<UserQuery.MenuData>() {
	 new MenuData(){ Name="2", Icon="22", Url="33",Sort=10},
	 }
	});
	var menu=new MenuOption();
	menu.MenuDatas.AddRange(a);
	JavaScriptSerializer js=new JavaScriptSerializer();
	js.Serialize(menu).Dump();
}
public class MenuOption
{
	public List<MenuData> MenuDatas = new List<MenuData>();
}
public class MenuData
{
	public string Name { get; set; }
	public string Url { get; set; }
	public string Icon { get; set; }
    public int Sort { get; set; }
	public List<MenuData> Children = new List<MenuData>();
}
// Define other methods and classes here
