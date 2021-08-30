<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ProductOrder.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        Zdeněk Petřík<br />
        Na lepším 61, 25101 Březí<br />
        <abbr title="Phone">Telefon:</abbr>
        736535670
    </address>

    <address>
        <strong>Mail address:</strong>   <a href="mailto:zdenekpetrik@seznam.com">zdenekpetrik@seznam.com</a><br />
    </address>
</asp:Content>
