using System.Collections.Generic;
using System.Linq;

using MyPetShop.DAL;

namespace MyPetShop.BLL
{
  public class CartItemService
  {
    MyPetShopEntities db = new MyPetShopEntities();

    public CartItem Add(int customerId, int productId, int qty)
    {
      CartItem cartItem = null;

      Product product = db.Product.Find(productId);
      //当前需要添加的CartItem对象
      cartItem = new CartItem();
      cartItem.CustomerId = customerId;
      cartItem.ProId = product.ProductId;
      cartItem.ProName = product.Name;
      cartItem.ListPrice = product.ListPrice.Value;
      cartItem.Qty = qty;

      //如果客户当前宠物商品已在购物车内，则只要修改数量即可
      int ExistCartItemCount = db.CartItem.Where(c => c.CustomerId == customerId && c.ProId == productId)
                                                  .Count();
      if (ExistCartItemCount > 0) //修改
      {
        CartItem existCartItem = db.CartItem.Where(c => c.CustomerId == customerId && c.ProId == productId)
                                                .First();
        existCartItem.Qty += qty;//添加
      }
      else
      {
        db.CartItem.Add(cartItem);
      }

      db.SaveChanges();
      return cartItem;
    }

    /// <summary>
    /// 更新购物车中购物项的数量
    /// </summary>
    public CartItem Update(int customerId, int productId, int qty)
    {
      CartItem cartItem = null;

      //如果客户当前宠物商品已在购物车内，则只要修改数量即可;数量为0时删除该购物项
      cartItem = db.CartItem.Where(c => c.CustomerId == customerId && c.ProId == productId).First();
      if (cartItem != null)
      {
        cartItem.Qty = qty;
        //数量为0时删除
        if (cartItem.Qty <= 0)
        {
          db.CartItem.Remove(cartItem);
        }
        db.SaveChanges();
      }

      return cartItem;
    }

    /// <summary>
    /// 删除购物车中购物项
    /// </summary>
    public void Delete(int customerId, int productId)
    {
      CartItem cartItem = db.CartItem.Where(c => c.CustomerId == customerId && c.ProId == productId).First();
      if (cartItem != null)
      {
        db.CartItem.Remove(cartItem);
        db.SaveChanges();
      }
    }

    /// <summary>
    /// 清除购物车中所有购物项
    /// </summary>
    public void Clear(int customerId)
    {
      List<CartItem> cartItemList = db.CartItem.Where(c => c.CustomerId == customerId).ToList();
      db.CartItem.RemoveRange(cartItemList);
      db.SaveChanges();
    }

    public List<CartItem> GetCartItemByCustomerId(int customerId)
    {
      return db.CartItem.Where(c => c.CustomerId == customerId).ToList(); ;
    }

    public decimal GetTotalPriceByCustomerId(int customerId)
    {
      var cartItems = db.CartItem.Where(c => c.CustomerId == customerId);
      if (cartItems.Count() == 0)
      {
          return 0;
      }else
      {
          return cartItems.Sum(c => c.ListPrice * c.Qty);
      }
    }
  }
}
