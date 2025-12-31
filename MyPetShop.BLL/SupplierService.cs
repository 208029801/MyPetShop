using System.Collections.Generic;
using System.Linq;

using MyPetShop.DAL;

namespace MyPetShop.BLL
{
  public class SupplierService
  {
    MyPetShopEntities db = new MyPetShopEntities();
    public List<Supplier> GetAllSupplier()
    {
      return db.Supplier.ToList();
    }
    public Supplier GetSupplierById(int supplierId)
    {
      return db.Supplier.Find(supplierId);
    }

    public void InsertSupplier( string name, 
      string addr1,string addr2,string city,string state,string zip,string phone)
    {
      Supplier supplier = new Supplier();
      supplier.Name = name;
      supplier.Addr1 = addr1;
      supplier.Addr2 = addr2;
      supplier.City = city;
      supplier.State = state;
      supplier.Zip = zip;
      supplier.Phone = phone;

      db.Supplier.Add(supplier);
      db.SaveChanges();
    }
    public void UpdateSupplier(int suppId, string name, 
      string addr1,string addr2,string city,string state,string zip,string phone)
    {
      Supplier supplier = db.Supplier.Find(suppId);
      supplier.Name = name;
      supplier.Addr1 = addr1;
      supplier.Addr2 = addr2;
      supplier.City = city;
      supplier.State = state;
      supplier.Zip = zip;
      supplier.Phone = phone;
      db.SaveChanges();
    }
    public void DeleteSupplier(int suppId)
    {
      Supplier supplier = db.Supplier.Find(suppId);
      db.Supplier.Remove(supplier);
      db.SaveChanges();
    }
  }
}
