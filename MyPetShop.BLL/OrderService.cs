using System;
using System.Collections.Generic;
using System.Linq;

using MyPetShop.DAL;

namespace MyPetShop.BLL
{
  public class OrderService
  {
    MyPetShopEntities db = new MyPetShopEntities();
    public List<Order> GetAllOrder()
    {
      return db.Order.ToList();
    }
    public List<Order> GetOrderByCustomerId(int customerId)
    {
      return db.Order.Where(o => o.CustomerId == customerId)
                      .OrderByDescending(o => o.CustomerId)
                        .ToList();
    }

    public Order GetOrderByOrderId(int orderId)
    {
      return db.Order.Find(orderId);
    }
    public List<Order> GetOrderListByOrderId(int orderId)
    {
      return db.Order.Where(o=>o.OrderId == orderId).ToList();
    }

    public List<OrderItem> GetOrderItemByOrderId(int orderId)
    {
      return db.OrderItem.Where(o => o.OrderId == orderId).ToList();
    }

    public void CreateOrderFromCart(int cutomerId, string customerName, string addr1, string addr2,
      string city, string state, string zip, string phone)
    {
      //本项目使用数据库事务,EF框架提供了对数据库事务的支持
      using (var ts = db.Database.BeginTransaction() )
      {
        //获取购物车内商品项目
        List<CartItem> cartItemList = db.CartItem.Where(c => c.CustomerId == cutomerId).ToList();

        //根据送货地址信息创建订单头，状态为“未审核”
        Order order = new Order();
        order.CustomerId = cutomerId;
        order.UserName = customerName;
        order.OrderDate = DateTime.Now;
        order.Addr1 = addr1;
        order.Addr2 = addr2;
        order.City = city;
        order.State = state;
        order.Zip = zip;
        order.Phone = phone;
        order.Status = "未审核";

        //根据购物车商品清单创建订单明细
        OrderItem orderItem = null;
        Product product = null;
        foreach (CartItem cartItem in cartItemList) 
        {
          //依次添加每件商品为订单明细
          orderItem = new OrderItem();
          orderItem.OrderId = order.OrderId;
          orderItem.ProName = cartItem.ProName;
          orderItem.ListPrice = cartItem.ListPrice;
          orderItem.Qty = cartItem.Qty;
          orderItem.TotalPrice = cartItem.Qty * cartItem.ListPrice;
          order.OrderItem.Add(orderItem);

          //修改Product表的商品库存
          product = db.Product.Find(cartItem.ProId);
          product.Qty = product.Qty - cartItem.Qty;

          //从购物车中删除购物项
          db.CartItem.Remove(cartItem);
        }
        
        db.Order.Add(order);
        db.SaveChanges();
        ts.Commit(); //提交事务
      }
    }

    /// <summary>
    /// 将指定orderId的订单状态设置为“已审核”
    /// </summary>
    /// <param name="orderId">订单编号</param>
    public void UpdataOrder(int orderId)
    {
      Order order = db.Order.Find(orderId);
      order.Status = "已审核";
      db.SaveChanges();
    }
  }
}
