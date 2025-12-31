using MyPetShop.BLL;
using System;

public partial class SubmitCart : System.Web.UI.Page
{
  OrderService orderSrv = new OrderService();
  protected void Page_Load(object sender, EventArgs e)
  {
    if (Session["CustomerId"] == null)
    {
      Response.Redirect("~/Login.aspx");
    }
    pnlConsignee.Visible = true;
    lblMsg.Text = "";
  }
  protected void BtnSubmit_Click(object sender, EventArgs e)
  {
    orderSrv.CreateOrderFromCart(
        Convert.ToInt32(Session["CustomerId"]),
        Session["CustomerName"].ToString(),
        txtAddr1.Text.Trim(), txtAddr2.Text.Trim(), txtCity.Text.Trim(),
        txtState.Text.Trim(), txtZip.Text.Trim(), txtPhone.Text.Trim());

    pnlConsignee.Visible = false;
    lblMsg.Text = "已经成功结算，谢谢光临！";
  }
}