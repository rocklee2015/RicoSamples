<Query Kind="Expression">
  <Connection>
    <ID>edb569e0-1029-4670-bd56-f4981986d255</ID>
    <Persist>true</Persist>
    <Server>101.132.69.71</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAABoybHsSXFUuz8AXaKmCqgAAAAAACAAAAAAAQZgAAAAEAACAAAADlMDTg8rh8stUlZgjvxKWfJkLaoJu5GrJnhua9EICUhQAAAAAOgAAAAAIAACAAAAB7x+0HnQ6b0YgF1diupbyFoqj8o5uo5sGeSJrsiKJKHBAAAABM8IUq4NDIt9vX4B4yLwcyQAAAAJFB1V+gp2sgHISifMpmzqEsGAOnWOnhx7O3RcsGhbmZYn41eVGBCO7ch97kncwveJgTFqk5lA+bm4awvliGAl0=</Password>
    <Database>CinemaWd</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.EnterpriseServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.RegularExpressions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.ApplicationServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ComponentModel.DataAnnotations.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.Protocols.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceProcess.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Utilities.v4.0.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Framework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Tasks.v4.0.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Caching.dll</Reference>
  <Namespace>System.Web</Namespace>
</Query>

(from api in ApiRequests
 join user in Users  on api.UserName  equals user.Id.ToString()  into userTemp
 from user2 in userTemp.DefaultIfEmpty()
 where 1==1
 &&api.InterfaceDesc.Contains("确认")
// &&api.Url.Contains("1185200004235")
// &&api.CreateTime< DateTime.Parse("2018-05-13")
//  &&api.CreateTime> DateTime.Parse("2018-05-12")
  &&user2.Mobile.Equals("13905880084")
 // &&api.ResponseText.Contains("请求超时")
 //&&api.ResponseText.Contains("1185200000999")
 //&& api.InerfaceName.Contains("schedule.getSchedules")
 //&& api.ResponseText.Contains("影院系统执行错误")
 //&& api.ResponseText.Contains("场次信息无效")
 //&& api.Url.Contains("59426623")
 orderby api.CreateTime descending
 select new { api,user2 }
 )
 .Take(100)
 .ToList()

.Select(a => new
{
	a.user2?.NickName,
	a.user2?.Mobile,
	CreateTime=a.api.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
	a.api.InterfaceDesc,
	a.api.InerfaceName,
	
	Url = HttpUtility.UrlDecode(a.api.Url),
	a.api.ResponseText,
	a.api.UserName,
	UrlEncode=a.api.Url,
})