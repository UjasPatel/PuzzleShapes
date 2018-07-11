<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Puzzle._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron">
        <h1>Draw a Shape</h1>        
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:TextBox ID="TextBox1" runat="server" Width="1000"></asp:TextBox>             
        </div>
        <div class="col-md-4">
            <asp:Button ID="Button1" runat="server" Text="Draw" />            
        </div>
        <asp:Image ID="Image1" runat="server" />
    </div>

</asp:Content>

