using IngenioCategory.Entities;
using IngenioCategory.Models;

namespace IngenioCategory.Repositories
{
    public interface ICategoryRepository
    {
        CategoryTree<Category> GetCategoryTree();
    }
}
