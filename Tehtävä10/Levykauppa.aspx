<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Levykauppa.aspx.cs" Inherits="Levykauppa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Levykauppa</title>
    <style type="text/css">
        #form1 {
            height: 331px;
            width: 717px;
        }
        .auto-style1 {
            margin-left: 440px;
        }
    </style>
</head>
<body>
    <h1 class="auto-style1">Levykauppa</h1>

    <form id="form1" runat="server">
    <div>
        <asp:DataList ID="DataList" runat="server" DataSourceID="XmlData" CellPadding="2" ForeColor="Black" Height="569px" Width="1063px" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px">
            <AlternatingItemStyle BackColor="PaleGoldenrod" />
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <ItemTemplate>
                <div style="float:left">
                <img style="width:304px;height:228px" alt="kuva" src='Images/<%# XPath("@ISBN") %>.jpg'" />
                    </div>
                <div style="float:left";>
               <b> <%# XPath("@nimi") %></b>
                <br />
                    <br />
                    <br />
              <a href="Levy.aspx/?name=<%# XPath("@ISBN") %>"><b>  <%# XPath("@ISBN") %></b></a>
                <br />
                    <br />
                    <br />
                <b><%# XPath("@hinta") %>€</b>
                <br />
                    <br />
                    <br />
                </div>
               
            </ItemTemplate>
            <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        </asp:DataList>
        
        <asp:XmlDataSource ID="XmlData" runat="server" DataFile="~/levyt.xml" XPath="//levyt/levy"></asp:XmlDataSource>
    </div>
   
    </form>
</body>
</html>
