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
        <asp:DataList ID="DataList" runat="server" DataSourceID="XmlDataSource1" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black">
            <AlternatingItemStyle BackColor="PaleGoldenrod" />
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        </asp:DataList>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/levyt.xml" XPath="//levyt/levy/@ISBN"></asp:XmlDataSource>
     </form>   
   
</body>
</html>
   
    
    
        

