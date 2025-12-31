using System;
using System.Web.UI;

public partial class MasterPage : System.Web.UI.MasterPage
{
  protected void Page_Load(object sender, EventArgs e)
  {

  }
  
  protected void ImgbtnSearch_Click(object sender, ImageClickEventArgs e)
  {
    //如果搜索框不为空，以查询字符串形式传递搜索文本到Search.aspx
    string strQuery = "";
    if (txtSearch.Text.Trim() == "")
    {
      strQuery = "";
    }
    else
    {
      strQuery = "?SearchText=" + txtSearch.Text.Trim();
    }
    Response.Redirect("~/Search.aspx" + strQuery);
  }
  protected void LbtnRegister_Click(object sender, EventArgs e)
  {
    if (Session["CustomerId"]!= null)  //用户已登录
    {
      Session.Clear();  //注销当前用户
    }
    Response.Redirect("~/NewUser.aspx");
  }
  protected void LbtnLogin_Click(object sender, EventArgs e)
  {
    if (Session["CustomerId"] != null)  //用户已登录
    {
      Session.Clear();  //注销当前用户
    }
    Response.Redirect("~/Login.aspx");
  }
}
