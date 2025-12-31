<%@ Page Title="分类管理" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CategoryMaster.aspx.cs" Inherits="Admin_CategoryMaster" %>

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
  <table id="tblCategory">
    <tr>
      <th>分类名称</th>
      <th>分类描述</th>
      <th></th>
    </tr>
    <asp:Repeater ID="rptCategory" runat="server">
      <ItemTemplate>
        <%--ItemTemplate模板用于控制数据源中每一个数据项的显示格式--%>
        <tr>
          <td><%# Eval("Name") %></td>
          <td><%# Eval("Descn") %></td>
          <td>
            <asp:HyperLink ID="hlUpdate" runat="server" NavigateUrl='<%# "~/Admin/CategoryUpdate.aspx?CategoryId=" + Eval("CategoryId") %>'>编辑</asp:HyperLink>
            <asp:LinkButton ID="btnDelete" runat="server" Text="删除" OnClick="BtnDelete_Click" CommandArgument='<%#Eval("CategoryId") %>' />
          </td>
        </tr>
      </ItemTemplate>
    </asp:Repeater>
    <tr>
      <td colspan="3">
        <asp:HyperLink ID="hlAdd" NavigateUrl="~/Admin/CategoryInsert.aspx" runat="server">新建</asp:HyperLink></td>
    </tr>
  </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="Server">
</asp:Content>


