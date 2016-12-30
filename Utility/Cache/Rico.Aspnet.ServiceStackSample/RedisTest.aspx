<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RedisTest.aspx.cs" Inherits="Rico.Aspnet.ServiceStackSample.RedisTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Button ID="btnOpenDB" runat="server" Text="打开Redis" OnClick="btnOpenDB_Click" />&nbsp;&nbsp;
    <asp:Label ID="lblShow" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="btnSetValue" runat="server" Text="显示全部" OnClick="btnSetValue_Click" /><asp:Button ID="Button1" runat="server" Text="显示全部Keys" OnClick="btnSetValueALL_Click" />
    <asp:Label ID="lblPeople" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="Label1" runat="server" Text="姓名："></asp:Label><asp:TextBox ID="txtName" runat="server" Width="100px"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" Text="部门："></asp:Label><asp:TextBox ID="txtPosition" runat="server" Width="100px"></asp:TextBox>
    <asp:Button ID="btnInsert" runat="server" Text="写入数据" OnClick="btnInsert_Click" />
    <br />
    <asp:Label ID="Label3" runat="server" Text="ID："></asp:Label><asp:TextBox ID="txtRedisId" runat="server" Width="100px"></asp:TextBox>
    <asp:Button ID="btnDel" runat="server" Text="删除数据" OnClick="btnDel_Click" />
    <br />
    <asp:Label ID="Label4" runat="server" Text="部门："></asp:Label><asp:TextBox ID="txtScreenPosition" runat="server" Width="100px"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="查询数据" OnClick="btnSearch_Click" />
    <br />
   <asp:Label ID="Label5" runat="server" Text="Key："></asp:Label><asp:TextBox ID="txtKey" runat="server" Width="100px"></asp:TextBox><asp:Label ID="Label9" runat="server" Text="新Key："></asp:Label><asp:TextBox ID="txtNewKey" runat="server" Width="100px"></asp:TextBox>
      <asp:Button ID="btnSearchByKey" runat="server" Text="查询Key中的数据" OnClick="btnSearchByKey_Click" />
    <asp:Button ID="btnRenameKey" runat="server" Text="重命名Key" OnClick="btnRenameKey_Click" />

     <br />
     <asp:Label ID="Label6" runat="server" Text="Key："></asp:Label><asp:TextBox ID="txtChangeKey" runat="server" Width="100px"></asp:TextBox>
     <asp:Label ID="Label7" runat="server" Text="姓名："></asp:Label><asp:TextBox ID="txtChangeName" runat="server" Width="100px"></asp:TextBox>
     <asp:Label ID="Label8" runat="server" Text="部门："></asp:Label><asp:TextBox ID="txtChangePosition" runat="server" Width="100px"></asp:TextBox>
      <asp:Button ID="btnUpdate" runat="server" Text="修改数据" OnClick="btnUpdate_Click" />
      <asp:Button ID="btnUpdateAll" runat="server" Text="一键修改" OnClick="btnUpdateAll_Click" />
</asp:Content>
