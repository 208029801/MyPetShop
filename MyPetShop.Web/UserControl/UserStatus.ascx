<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserStatus.ascx.cs" Inherits="UserControl_UserStatus" %>

<asp:Label ID="lblWelcome" runat="server" Text="您还未登录！"></asp:Label>
<asp:LinkButton ID="lnkbtnPwd" runat="server" ForeColor="White" Visible="false" PostBackUrl="~/ChangePwd.aspx">密码修改</asp:LinkButton>
<asp:LinkButton ID="lnkbtnManage" runat="server" ForeColor="White" Visible="false" PostBackUrl="~/Admin/Default.aspx">系统管理</asp:LinkButton>
<asp:LinkButton ID="lnkbtnCart" runat="server" ForeColor="White" Visible="false" PostBackUrl="~/OrderList.aspx">购物记录</asp:LinkButton>
<asp:LinkButton ID="lnkbtnLogout" runat="server" ForeColor="White" Visible="false" OnClick="LnkbtnLogout_Click">退出登录</asp:LinkButton>