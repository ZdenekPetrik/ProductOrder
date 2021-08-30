<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="ProductOrder.Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Customer </h1>
    <asp:GridView ID="gvCustomer" runat="server" AutoGenerateColumns="False" ShowFooter="True"
        OnRowCommand="gvCustomer_RowCommand" DataKeyNames="CustomerID"
        OnRowEditing="gvCustomer_RowEditing"
        OnRowUpdating="gvCustomer_RowUpdating"
        OnRowDeleting="gvCustomer_RowDeleting"
        CellPadding="4"  CellSpacing="8" OnRowCancelingEdit="gvCustomer_RowCancelingEdit">
       <AlternatingRowStyle BackColor="#DDDDDD" />
        <Columns>
            <asp:TemplateField HeaderText="ClientName" HeaderStyle-HorizontalAlign="Left">
                <EditItemTemplate>
                    <asp:TextBox ID="txtClientName" runat="server" Text='<%# Bind("ClientName") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valClientName" runat="server" ControlToValidate="txtClientName"
                        Display="Dynamic" ErrorMessage="Client Name is required." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="vldEditRecord">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblClientName" runat="server" Text='<%# Bind("ClientName") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtClientNameNew" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valClientNameNew" runat="server" ControlToValidate="txtClientNameNew"
                        Display="Dynamic" ErrorMessage="Client Name is required." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="vldNewRecord">*</asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Address" HeaderStyle-HorizontalAlign="Left">
                <EditItemTemplate>
                    <asp:TextBox ID="txtClientAddress" runat="server" Text='<%# Bind("ClientAddress") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valClientAddress" runat="server" ControlToValidate="txtClientAddress"
                        Display="Dynamic" ErrorMessage="Client address is required." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="vldEditRecord">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblClientAddress" runat="server" Text='<%# Bind("ClientAddress") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtClientAddressNew" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valClientAddress" runat="server" ControlToValidate="txtClientAddressNew"
                        Display="Dynamic" ErrorMessage="Client address is required." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="vldNewRecord">
                *</asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Orders" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="OrderCount" runat="server" Text='<%# GetCountOfOrders(Eval("Orders")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEdit" runat="server" Text="" CommandName="Edit" ToolTip="Edit">  
                                            <img src="../Images/Edit.png" width="30px" />  
                    </asp:LinkButton>
                    <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete"
                        ToolTip="Delete" OnClientClick='return confirm("Are you sure you want to delete Customer record?");'>  
                                            <img src="../Images/Delete.png"  width="30px" />  
                    </asp:LinkButton>
                </ItemTemplate>

                <EditItemTemplate>
                    <asp:LinkButton ID="lnkInsert" runat="server" Text="" ValidationGroup="vldEditRecord"
                        CommandName="Update" ToolTip="Save"
                        OnClientClick='return confirm("Customer Record Saved Successfully.");'>  
                                                 <img src="../Images/Save.ico"  width="30px" />  
                    </asp:LinkButton>
                    <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel">  
                                            <img src="../Images/Cancel.png"  width="30px" />  
                    </asp:LinkButton>
                </EditItemTemplate>

                <FooterTemplate>
                    <asp:LinkButton ID="lnkInsert" runat="server" Text="" ValidationGroup="vldNewRecord"
                        CommandName="InsertNew" ToolTip="Add New Customer"
                        OnClientClick='return confirm("Customer Record addedd Successfully.");'>  
                                                 <img src="../Images/Insert.png"  width="30px" />  
                    </asp:LinkButton>
                    <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="CancelNew" ToolTip="Cancel">  
                                            <img src="../Images/Cancel.png"  width="30px" />  
                    </asp:LinkButton>
                </FooterTemplate>

            </asp:TemplateField>

        </Columns>
         <EditRowStyle BackColor="#2461BF" />
         <RowStyle BackColor="#EFF3FB" />
     </asp:GridView>
</asp:Content>
