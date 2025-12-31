<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AutoShow.ascx.cs" Inherits="UserControl_AutoShow" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>

    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
      <ProgressTemplate>
        正在连接数据库服务器，请耐心等待......
      </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:Timer ID="tmrAutoShow" runat="server" Interval="3000" OnTick="TmrAutoShow_Tick" Enabled="False">
    </asp:Timer>
    热销商品
    <asp:GridView ID="gvProduct" runat="server" AllowPaging="True" AutoGenerateColumns="false" OnPageIndexChanging="GvProduct_PageIndexChanging" PagerSettings-Mode="NextPrevious" PageSize="1" Width="100%">
      <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NextPrevious" NextPageText="下一页" PreviousPageText="上一页" />
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
            <table>
              <tr>
                <td rowspan="7">
                  <asp:Image ID="imgImage" runat="server" ImageUrl='<%# Bind("Image") %>' />
                </td>
                <td>商品编号： </td>
                <td>
                  <asp:Label ID="lblProductId" runat="server" Text='<%# Bind("ProductId") %>'></asp:Label>
                </td>
              </tr>
              <tr>
                <td>商品名称： </td>
                <td>
                  <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </td>
              </tr>
              <tr>
                <td>商品价格： </td>
                <td>
                  <asp:Label ID="lblListPrice" runat="server" Text='<%# Bind("ListPrice") %>'></asp:Label>
                </td>
              </tr>
              <tr>
                <td>库存： </td>
                <td>
                  <asp:Label ID="lblQty" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                </td>
              </tr>
            </table>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:HyperLinkField DataNavigateUrlFields="ProductId" DataNavigateUrlFormatString="~/ShopCart.aspx?ProductId={0}" DataTextFormatString="{0:c}" HeaderText="放入购物车" Text="购买" />
      </Columns>
    </asp:GridView>
    <asp:CheckBox ID="chkAutoShow" runat="server" AutoPostBack="True" Text="3秒后显示下一个商品" OnCheckedChanged="ChkAutoShow_CheckedChanged" />
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="tmrAutoShow" EventName="Tick" />
  </Triggers>
</asp:UpdatePanel>
