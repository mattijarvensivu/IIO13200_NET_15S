﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IIO13200 .Net Ohjelmointi</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>To 22.10.2015</h1>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Eka sivuni</asp:HyperLink>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/viinit.aspx">Viinit</asp:HyperLink>
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/DemoxOy.aspx">Maailman viininjuojat</asp:HyperLink>
    </div>
    </form>
</body>
</html>
