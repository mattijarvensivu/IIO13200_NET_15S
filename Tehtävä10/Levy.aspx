<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Levy.aspx.cs" Inherits="Levy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:DataList ID="DataList" runat="server" DataSourceID="XmlDataSource1">
        </asp:DataList>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/levyt.xml" XPath="//levyt/levy"></asp:XmlDataSource>
     <asp:ListBox ID="ListBox" runat="server" Height="140px" Width="199px"></asp:ListBox>
        
</body>
</html>
   
    </form>
    
        

