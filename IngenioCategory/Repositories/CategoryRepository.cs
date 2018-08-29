using IngenioCategory.Entities;
using IngenioCategory.Models;
using System.Collections.Generic;

namespace IngenioCategory.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public CategoryTree<Category> GetCategoryTree()
        {
            var list = new List<Category>
            { 
                // id, parentId, name, keyword
                new Category(100, -1, "Business", "Money"),
                new Category(200, -1, "Tutoring", "Teaching"),
                new Category(101, 100, "Accounting", "Taxes"),
                new Category(102, 100, "Taxation"),
                new Category(201, 200, "Computer"),
                new Category(103, 101, "Corporate Tax"),
                new Category(202, 201, "Operating System"),
                new Category(109, 101, "Small business Tax")
            };

            var _categoryTree = new CategoryTree<Category>();
            return _categoryTree.Build(list);            
        }
    }
}
