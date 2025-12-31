using MyPetShop.BLL;
using System;


public partial class Admin_SupplierInsert : System.Web.UI.Page
{
  SupplierService supplierSrv = new SupplierService();
  protected void Page_Load(object sender, EventArgs e)
  {
    if (Session["AdminId"] == null)  //管理员用户未登录
    {
      Response.Redirect("~/Login.aspx");
    }
  }

  protected void BtnInsert_Click(object sender, EventArgs e)
  {
    supplierSrv.InsertSupplier(txtName.Text, txtAddr1.Text, txtAddr2.Text, txtCity.Text, txtState.Text, txtZip.Text, txtPhone.Text);
  }

  protected void BtnReturn_Click(object sender, EventArgs e)
  {
    Response.Redirect("SupplierMaster.aspx");
  }
}