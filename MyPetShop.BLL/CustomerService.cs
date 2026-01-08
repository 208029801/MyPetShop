using System.Collections.Generic;
using System.Linq;
using MyPetShop.DAL;

namespace MyPetShop.BLL
{
    public class CustomerService
    {
        // 建立MyPetShop.DAL数据访问层中的MyPetShopEntities类实例db
        MyPetShopEntities db = new MyPetShopEntities();

        /// <summary>
        /// 检查输入的用户名和密码是否正确
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>若用户名和密码正确则返回用户Id，否则返回0</returns>
        public int CheckLogin(string name, string password)
        {
            // 改用FirstOrDefault，空结果返回null
            Customer customer = db.Customer
                .Where(c => c.Name.Equals(name) && c.Password.Equals(password))
                .FirstOrDefault();
            return customer?.CustomerId ?? 0; // 简化判空逻辑
        }

        /// <summary>
        /// 修改用户Id对应用户的密码
        /// </summary>
        /// <param name="customerId">用户Id</param>
        /// <param name="password">新密码</param>
        /// <exception cref="KeyNotFoundException">用户Id不存在时抛出</exception>
        public void ChangePassword(int customerId, string password)
        {
            Customer customer = db.Customer.Find(customerId);
            // 判空，避免空引用异常
            if (customer == null)
            {
                throw new KeyNotFoundException($"不存在ID为{customerId}的用户");
            }
            customer.Password = password;
            db.SaveChanges();
        }

        /// <summary>
        /// 将用户密码重置为相应的用户名
        /// </summary>
        /// <param name="name">输入的用户名</param>
        /// <param name="email">输入的Email</param>
        /// <exception cref="KeyNotFoundException">用户名+邮箱不存在时抛出</exception>
        public void ResetPassword(string name, string email)
        {
            // 改用FirstOrDefault，空结果返回null
            Customer customer = db.Customer
                .Where(c => c.Name.Equals(name) && c.Email.Equals(email))
                .FirstOrDefault();
            if (customer == null)
            {
                throw new KeyNotFoundException("用户名或邮箱错误，无法重置密码");
            }
            customer.Password = name;
            db.SaveChanges();
        }

        /// <summary>
        /// 判断输入的用户名是否重名
        /// </summary>
        /// <param name="name">输入的用户名</param>
        /// <returns>当用户名重名时返回true，否则返回false</returns>
        public bool IsNameExist(string name)
        {
            // 改用Any()更高效（无需查询整条数据，只判断是否存在）
            return db.Customer.Any(c => c.Name.Equals(name));
        }

        /// <summary>
        /// 判断输入的用户名+邮箱是否存在
        /// </summary>
        /// <param name="name">输入的用户名</param>
        /// <param name="email">输入的邮箱</param>
        /// <returns>存在返回true，否则返回false</returns>
        public bool IsEmailExist(string name, string email)
        {
            // 改用Any()更高效，避免First()抛异常
            return db.Customer.Any(c => c.Name.Equals(name) && c.Email.Equals(email));
        }

        /// <summary>
        /// 向MyPetShop数据库插入新用户记录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="email">电子邮件地址</param>
        public void Insert(string name, string password, string email)
        {
            Customer customer = new Customer();
            customer.Name = name;
            customer.Password = password;
            customer.Email = email;

            db.Customer.Add(customer);
            db.SaveChanges();
        }
    }
}
