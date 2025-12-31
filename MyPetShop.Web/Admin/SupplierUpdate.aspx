<%@ Page Title="供应商管理" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SupplierUpdate.aspx.cs" Inherits="Admin_SupplierUpdate" %>

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
      <td>供应商编号：</td>
      <td>
        <asp:TextBox ID="txtSupplierId" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
      <td>供应商名称：</td>
      <td>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
      <td>地址1：</td>
      <td>
        <asp:TextBox ID="txtAddr1" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
      <td>地址2：</td>
      <td>
        <asp:TextBox ID="txtAddr2" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
      <td>城市：</td>
      <td>
        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
      <td>区域：</td>
      <td>
        <asp:TextBox ID="txtState" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
      <td>邮编：</td>
      <td>
        <asp:TextBox ID="txtZip" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
      <td>手机：</td>
      <td>
        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Button ID="btnUpdate" runat="server" Text="修改" OnClick="BtnUpdate_Click" />
        <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="BtnReturn_Click" /></td>
    </tr>
  </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="Server">
</asp:Content>

