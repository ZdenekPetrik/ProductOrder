<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrdersManipulation.aspx.cs" Inherits="ProductOrder.OrdersManipulation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h1>Orders </h1>
    <asp:GridView ID="gvOrder" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderID" OnSelectedIndexChanged="gvOrder_SelectedIndexChanged" OnSelectedIndexChanging="gvOrder_SelectedIndexChanging"
        ShowFooter="True"
        OnRowCommand="gvCustomer_RowCommand"
        OnRowEditing="gvCustomer_RowEditing"
        OnRowUpdating="gvCustomer_RowUpdating"
        OnRowDeleting="gvCustomer_RowDeleting"
        OnRowCancelingEdit="gvCustomer_RowCancelingEdit"
        CellPadding="10" OnDataBound="gvOrder_DataBound">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" HeaderText="Select" SelectText="Editace Objednávky" />
            <asp:TemplateField HeaderText="Client Name" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblClientName" runat="server" Text='<%# Eval("Customer.ClientName") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlClientName" runat="server">
                    </asp:DropDownList>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Client Address" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblClientAdress" runat="server" Text='<%# Eval("Customer.ClientAddress") %>'></asp:Label>
                </ItemTemplate>

                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblDate" runat="server" Text='<%# Eval("InsertDate") %>' DataFormatString="{0:/dd/MM/yyyy}"></asp:Label>
                </ItemTemplate>

                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("PriceFull") %>'></asp:Label>
                </ItemTemplate>

                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Orders" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblOrderCount" runat="server" Text='<%# GetCountOfOrderItems(Eval("OrderItems")) %>'></asp:Label>
                </ItemTemplate>

                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete"
                        ToolTip="Delete" OnClientClick='return confirm("Are you sure you want to delete Order record?");'>  
                                            <img src="../Images/Delete.png"  width="30px" />  
                    </asp:LinkButton>
                </ItemTemplate>

                <EditItemTemplate>
                    <asp:LinkButton ID="lnkInsert" runat="server" Text="" ValidationGroup="vldEditRecord"
                        CommandName="Update" ToolTip="Save"
                        OnClientClick='return confirm("Order Record Saved Successfully.");'>  
                                                 <img src="../Images/Save.ico"  width="30px" />  
                    </asp:LinkButton>
                    <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel">  
                                            <img src="../Images/Cancel.png"  width="30px" />  
                    </asp:LinkButton>
                </EditItemTemplate>

                <FooterTemplate>
                    <asp:LinkButton ID="lnkInsert" runat="server" Text="" ValidationGroup="vldNewRecord"
                        CommandName="InsertNew" ToolTip="Add New Order"
                        OnClientClick='return confirm("Order Record addedd Successfully.");'>  
                                                 <img src="../Images/Insert.png"  width="30px" />  
                    </asp:LinkButton>
                </FooterTemplate>

            </asp:TemplateField>

        </Columns>
    </asp:GridView>

    <asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" OnRowDataBound="gvProduct_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Product Name" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price" HeaderStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Count" HeaderStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblCount" runat="server" Text='<%# Eval("CountItems") %>'></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="New Count" HeaderStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:TextBox ID="newCount2" runat="server" Width="50px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PriceFull" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblPriceFull" runat="server" Text='<%# Eval("PriceFull") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ProductID" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblProductID" runat="server" Text='<%# Eval("ProductID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="OrderID" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblOrderID" runat="server" Text='<%# Eval("OrderID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnSaveEdit" runat="server" Text="Potvrdit editaci objednávky" OnClick="btnSaveEdit_Click" />
    <asp:Button ID="btnCancelEdit" runat="server" Text="Zrušit editaci objednávky" OnClick="btnCancelEdit_Click" />

</asp:Content>
