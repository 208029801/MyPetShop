using MyPetShop.BLL;
using System;

public partial class Admin_CategoryUpdate : System.Web.UI.Page
{
  CategoryService categorySrv = new CategoryService();
  protected void Page_Load(object sender, EventArgs e)
  {
    if (Session["AdminId"] == null)  //管理员用户未登录
    {
      Response.Redirect("~/Login.aspx");
    }

    if (!IsPostBack)
    {
      string categoryId = Request.QueryString["CategoryId"];
      var category = categorySrv.GetCategoryById(int.Parse(categoryId));
      txtCategoryId.Text = categoryId;
      txtCategoryId.ReadOnly = true;  //分类Id是标识，不能更改
      txtName.Text = category.Name;
      txtDescn.Text = category.Descn;
    }
  }

  protected void BtnUpdate_Click(object sender, EventArgs e)
  {
    categorySrv.UpdateCategory(int.Parse(txtCategoryId.Text),txtName.Text, txtDescn.Text);
  }

  protected void BtnReturn_Click(object sender, EventArgs e)
  {
    Response.Redirect("CategoryMaster.aspx");
  }
}