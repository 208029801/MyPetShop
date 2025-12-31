using System.Collections.Generic;
using System.Linq;

using MyPetShop.DAL;

namespace MyPetShop.BLL
{
  public class ProductService
  {
    MyPetShopEntities db = new MyPetShopEntities();
    public void Add(string imageFile, string name, int categoryId, int supplierId,
      decimal listPrice, decimal unitCost, string descn, int qty)
    {
      Product product = new Product();
      product.Image = imageFile;
      product.Name = name;
      product.CategoryId = categoryId;
      product.SuppId = supplierId;
      product.ListPrice = listPrice;
      product.UnitCost = unitCost;
      product.Descn = descn;
      product.Qty = qty;

      db.Product.Add(product);
      db.SaveChanges();
    }

    public void Update(int productId, string name, int categoryId, int suppId, decimal listPrice,
      decimal UnitCost, string descn, int qty)
    {
      Product product = db.Product.Find(productId);
      product.Name = name;
      product.CategoryId = categoryId;
      product.SuppId = suppId;
      product.ListPrice = listPrice;
      product.UnitCost = UnitCost;
      product.Descn = descn;
      product.Qty = qty;

      db.SaveChanges();
    }

    public List<Product> GetAllProduct()
    {
      return db.Product.ToList();
    }
    public Product GetProductByProductId(int productId)
    {
      return db.Product.Find(productId);
    }
    public List<Product> GetProductByCategoryId(int categoryId)
    {
      return db.Product.Where(p => p.CategoryId == categoryId).ToList();
    }

    public List<Product> GetNewProduct(int count)
    {
      return db.Product.OrderByDescending(p => p.ProductId).Take(count).ToList();
    }

    public List<Product> GetProductByProductIdOrCategoryId(string productId, string categoryId)
    {
      if (!string.IsNullOrEmpty(productId))
      {
        return db.Product.Where(p => p.ProductId.ToString().Equals(productId)).ToList();
      }
      else
      {
        return db.Product.Where(p => p.CategoryId.ToString().Equals(categoryId)).ToList();
      }
    }
    /// <summary>
    /// 模糊查找商品名中包含指定文本的商品，再返回满足条件的商品列表
    /// </summary>
    /// <param name="searchText">指定的文本</param>
    /// <returns>满足条件的商品列表</returns>
    public List<Product> GetProductBySearchText(string searchText)
    {
      return db.Product.Where(p => p.Name.Contains(searchText)).ToList();
    }

    public int GetProductCountByCategoryId(int categoryId)
    {
      return db.Product.Where(p => p.CategoryId == categoryId).Count();
    }
    public int GetProductCountBySupplierId(int supplierId)
    {
      return db.Product.Where(p => p.SuppId == supplierId).Count();
    }
    /// <summary>
    /// IsExitCS()方法判断Category和Supplier表中是否已有数据
    /// </summary>
    /// <returns>返回值true表示Category或Supplier表中无数据；返回值false表示Category和Supplier表中都有数据</returns>
    public bool IsExitCS()
    {
      if (db.Category.Count() == 0 || db.Supplier.Count() == 0)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    /// <summary>
    /// IsExitProduct()判断是否存在指定的商品
    /// </summary>
    /// <param name="name">指定的商品名</param>
    /// <returns>返回值true表示Product表中存在指定的商品；返回值false表示Product表中不存在指定的商品</returns>
    public bool IsExitProduct(string name)
    {
      var products = db.Product.Where(p => p.Name.Equals(name));
      if (products.Count() != 0)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public void DeletePro(int productId)
    {
      var product = db.Product.Find(productId);

      //产品如果已经有用户放入购物车或者下达了订单，该产品删除失败（外键约束）
      //异常: "The DELETE statement conflicted with the REFERENCE constraint "FK__CartItem__ProId". 
      //异常: "The DELETE statement conflicted with the REFERENCE constraint "FK__OrderItem__ProId". 
      db.Product.Remove(product);
      db.SaveChanges();
    }
  }
}
