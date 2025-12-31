<%@ Page Title="供应商管理" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SupplierMaster.aspx.cs" Inherits="Admin_SupplierMaster" %>

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
  <table id="tblSupplier">
    <tr>
      <th>供应商名称</th>
      <th>地址1</th>
      <th>地址2</th>
      <th>城市</th>
      <th>区域</th>
      <th>邮编</th>
      <th>手机</th>
      <th></th>
    </tr>
    <asp:Repeater ID="rptSupplier" runat="server">
      <ItemTemplate>
        <tr>
          <td><%# Eval("Name") %></td>
          <td><%# Eval("Addr1") %></td>
          <td><%# Eval("Addr2") %></td>
          <td><%# Eval("City") %></td>
          <td><%# Eval("State") %></td>
          <td><%# Eval("Zip") %></td>
          <td><%# Eval("Phone") %></td>
          <td>
            <asp:HyperLink ID="hlUpdate" runat="server"
              NavigateUrl='<%# "~/Admin/SupplierUpdate.aspx?SupplierId=" +
                   Eval("SuppId") %>'>编辑</asp:HyperLink>
            <asp:LinkButton ID="btnDelete" runat="server" Text="删除" OnClick="BtnDelete_Click" CommandArgument='<%#Eval("SuppId") %>' />
          </td>
        </tr>
      </ItemTemplate>
    </asp:Repeater>
    <tr>
      <td colspan="8">
        <asp:HyperLink ID="hlAdd" NavigateUrl="~/Admin/SupplierInsert.aspx" runat="server">新建</asp:HyperLink></td>
    </tr>
  </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="Server">
</asp:Content>


