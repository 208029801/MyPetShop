using MyPetShop.BLL;
using System;


public partial class Admin_CategoryInsert : System.Web.UI.Page
{
  CategoryService categorySrv = new CategoryService();
  protected void Page_Load(object sender, EventArgs e)
  {
    if (Session["AdminId"] == null)  //管理员用户未登录
    {
      Response.Redirect("~/Login.aspx");
    }
  }

  protected void BtnInsert_Click(object sender, EventArgs e)
  {
    categorySrv.InsertCategory(txtName.Text, txtDescn.Text);
  }

  protected void BtnReturn_Click(object sender, EventArgs e)
  {
    Response.Redirect("CategoryMaster.aspx");
  }
}