<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="ProductOrder.Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1> Products </h1>
    <asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="False" ShowFooter="True"  
        OnRowCommand="gvProduct_RowCommand" DataKeyNames="ProductID"
        OnRowEditing="gvProduct_RowEditing"
        OnRowUpdating="gvProduct_RowUpdating"
        OnRowDeleting="gvProduct_RowDeleting"
        CellPadding="4" CellSpacing="8" OnRowCancelingEdit="gvProduct_RowCancelingEdit">
        <AlternatingRowStyle BackColor="#DDDDDD" />
        <Columns>
            <asp:TemplateField HeaderText="Product Name" HeaderStyle-HorizontalAlign="Left">
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valProductName" runat="server" ControlToValidate="txtProductName"
                        Display="Dynamic" ErrorMessage="Product Name is required." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="vldEditRecord">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtProductNameNew" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valProductNameNew" runat="server" ControlToValidate="txtProductNameNew"
                        Display="Dynamic" ErrorMessage="Product Name is required." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="vldNewRecord">*</asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price" HeaderStyle-HorizontalAlign="Left">
                <EditItemTemplate>
                    <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valPrice" runat="server" ControlToValidate="txtPrice"
                        Display="Dynamic" ErrorMessage="Price is required." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="vldEditRecord">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtPriceNew" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valPriceNew" runat="server" ControlToValidate="txtPriceNew"
                        Display="Dynamic" ErrorMessage="Price is required." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="vldNewRecord">
                *</asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="">  
                                    <ItemTemplate>  
                                        <asp:LinkButton ID="lnkEdit" runat="server" Text="" CommandName="Edit" ToolTip="Edit">  
                                            <img src="../Images/Edit.png" width="30px" />  
                                        </asp:LinkButton>  
                                        <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete"  
                                            ToolTip="Delete" OnClientClick='return confirm("Are you sure you want to delete Product record?");'>  
                                            <img src="../Images/Delete.png"  width="30px" />  
                                        </asp:LinkButton>  
                                    </ItemTemplate>  
  
                                    <EditItemTemplate>  
                                        <asp:LinkButton ID="lnkInsert" runat="server" Text="" ValidationGroup="vldEditRecord"   
                                            CommandName="Update" ToolTip="Save"  
                                            OnClientClick='return confirm("Product Record Saved Successfully.");'>  
                                                 <img src="../Images/Save.ico"  width="30px" />  
                                        </asp:LinkButton>  
                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel">  
                                            <img src="../Images/Cancel.png"  width="30px" />  
                                        </asp:LinkButton>  
                                    </EditItemTemplate>  
  
                                    <FooterTemplate>  
                                        <asp:LinkButton ID="lnkInsert" runat="server" Text="" ValidationGroup="vldNewRecord"   
                                            CommandName="InsertNew" ToolTip="Add New Product"  
                                            OnClientClick='return confirm("Product Record addedd Successfully.");'>  
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
