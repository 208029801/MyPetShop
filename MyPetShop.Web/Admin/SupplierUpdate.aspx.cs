using MyPetShop.BLL;
using System;

public partial class Admin_SupplierUpdate : System.Web.UI.Page
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
      string supplierId = Request.QueryString["SupplierId"];
      var supplier = supplierSrv.GetSupplierById(int.Parse(supplierId));
      txtSupplierId.Text = supplierId;
      txtSupplierId.ReadOnly = true;  //分类Id是标识，不能更改
      txtName.Text = supplier.Name;
      txtAddr1.Text = supplier.Addr1;
      txtAddr2.Text = supplier.Addr2;
      txtCity.Text = supplier.City;
      txtState.Text = supplier.State;
      txtZip.Text = supplier.Zip;
      txtPhone.Text = supplier.Phone;
    }

  }

  protected void BtnUpdate_Click(object sender, EventArgs e)
  {
    supplierSrv.UpdateSupplier(int.Parse(txtSupplierId.Text),txtName.Text, txtAddr1.Text, txtAddr2.Text, txtCity.Text, txtState.Text, txtZip.Text, txtPhone.Text);
  }

  protected void BtnReturn_Click(object sender, EventArgs e)
  {
    Response.Redirect("SupplierMaster.aspx");
  }
}