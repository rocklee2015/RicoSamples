<Query Kind="Statements">
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
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Caching.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Framework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Tasks.v4.0.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>System.Web</Namespace>
</Query>

var merchantId = new List<string>() {
"20180611XX1185000001428500W93",
"20180611XX1185000001406800W604",
//"220180625XX1185000002925700W949",
"20180626XX1185000002603400W8",
"20180626XX1185000002574000W396"
};
var orders=Orders.Where(a => merchantId.Contains(a.MerchantOrderId)).Select(a => new {
//a.MerchantOrderId,
a.LockOrderId,
a.OutLockId,
a.PayCardNum
}).Dump();

var locakOrderIds = orders.Select(a => a.LockOrderId).ToList();
merchantId[0].Dump();

ApiRequests.Where(a=>
a.CreateTime>DateTime.Parse("2018-06-01") &&(
a.Url.Contains(locakOrderIds[0])&&a.InterfaceDesc.Contains("确认")||
a.Url.Contains(locakOrderIds[1])&&a.InterfaceDesc.Contains("确认")||
a.Url.Contains(locakOrderIds[2])&&a.InterfaceDesc.Contains("确认")||
a.Url.Contains(locakOrderIds[3])&&a.InterfaceDesc.Contains("确认")
)
)
.Select(a => new {
a.CreateTime,
a.InterfaceDesc,
Url = HttpUtility.UrlDecode(a.Url),
a.ResponseText,
})
.OrderBy(a=>a.CreateTime).Dump();