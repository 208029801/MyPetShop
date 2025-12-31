using MyPetShop.BLL;
using System;
using System.Web.UI.WebControls;
public partial class Admin_CategoryMaster : System.Web.UI.Page
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
      Bind();
    }
  }

  protected void Bind()
  {
    var Categorys = categorySrv.GetAllCategory();
    rptCategory.DataSource = Categorys;
    rptCategory.DataBind();
  }

  protected void BtnDelete_Click(object sender, EventArgs e)
  {
    LinkButton btnDel = (LinkButton)sender;
    int categoryId = int.Parse(btnDel.CommandArgument);
    categorySrv.DeleteCategory(categoryId);
    Bind();
  }
}