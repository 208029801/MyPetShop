using System.Collections.Generic;
using System.Linq;

using MyPetShop.DAL;

namespace MyPetShop.BLL
{
    public class CategoryService
    {
        MyPetShopEntities db = new MyPetShopEntities();

        public Category GetCategoryById(int categoryId)
        {
            return db.Category.Find(categoryId);
        }
        public void InsertCategory(string name, string descn)
        {
            Category category = new Category();
            category.Name = name;
            category.Descn = descn;

            db.Category.Add(category);
            db.SaveChanges();
        }
        public void UpdateCategory(int categoryId, string name, string descn)
        {
            Category category = db.Category.Find(categoryId);
            category.Name = name;
            category.Descn = descn;

            db.SaveChanges();
        }
        public void DeleteCategory(int categoryId)
        {
            Category category = db.Category.Find(categoryId);
            db.Category.Remove(category);
            db.SaveChanges();
        }
        public List<Category> GetAllCategory()
        {
            return db.Category.ToList();
        }

        public int GetProductCountByCategoryId(int categoryId)
        {
            return db.Product.Where(p => p.CategoryId == categoryId).Count();
        }
    }
}
