using MyPetShop.BLL;
using System;
using System.Web.UI.WebControls;
public partial class Admin_SupplierMaster : System.Web.UI.Page
{
  SupplierService supplierSrv = new SupplierService();
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
    var Suppliers = supplierSrv.GetAllSupplier();
    rptSupplier.DataSource = Suppliers;
    rptSupplier.DataBind();
  }

  protected void BtnDelete_Click(object sender, EventArgs e)
  {
    LinkButton btnDel = (LinkButton)sender;
    int supplierId = int.Parse(btnDel.CommandArgument);
    supplierSrv.DeleteSupplier(supplierId);
    Bind();  
  }
}