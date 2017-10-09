<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Rico.S10.CacheWebSample.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="CacheTest.aspx" target="_blank"> 缓存测试页面</a><br/><br/>
            
            <hr/>
            <a href="NoSlidingExpiration_Set.aspx" target="_blank"> 绝对测试-设置缓存</a><br/><br/>
            
            <a href="NoSlidingExpiration_Get.aspx" target="_blank"> 绝对测试-获取缓存</a><br/><br/>
            <hr/>
            
            <a href="CacheDependencySet.aspx" target="_blank"> 缓存依赖-设置缓存</a><br/><br/>
            
            <a href="CacheDependencyGet.aspx" target="_blank"> 缓存依赖-获取缓存</a><br/><br/>
        </div>
    </form>
</body>
</html>
