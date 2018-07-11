<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shapes.aspx.cs" Inherits="Puzzle.Shapes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label>Type Text for the Shape</label>
            <asp:TextBox ID="TextBox1" runat="server" Width ="500"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Show Shape"/>
        </div>
        
        <div style="margin-top: 25px;">
            <asp:Image ID="Image1" runat="server" ForeColor="Black" BackColor="Black" />
        </div>
    </form>
</body>
</html>
