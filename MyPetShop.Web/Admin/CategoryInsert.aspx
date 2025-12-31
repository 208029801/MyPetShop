<%@ Page Title="分类管理" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CategoryInsert.aspx.cs" Inherits="Admin_CategoryInsert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <a href="CategoryMaster.aspx">分类管理</a>
  <br />
  <br />
  <a href="SupplierMaster.aspx">供应商管理</a>
  <br />
  <br />
  <a href="ProductMaster.aspx">商品管理</a>
  <br />
  <br />
  <a href="OrderMaster.aspx">订单管理</a>
  <br />
  <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
  <table>
    <tr>
      <td>分类名称：</td>
      <td>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
      <td>分类描述：</td>
      <td>
        <asp:TextBox ID="txtDescn" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Button ID="btnInsert" runat="server" Text="插入" OnClick="BtnInsert_Click" />
        <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="BtnReturn_Click" /></td>
    </tr>
  </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="Server">
</asp:Content>

