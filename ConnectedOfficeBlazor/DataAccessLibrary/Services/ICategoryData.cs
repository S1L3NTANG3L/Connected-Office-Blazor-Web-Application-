using DataAccessLibrary.Models;

namespace DataAccessLibrary.Services
{
    //Just an interface class
    public interface ICategoryData
    {
		Task<List<CategoryModel>> GetCategories();
		Task InsertCategory(CategoryModel category);
		Task<CategoryModel> GetCategoryById(Guid categoryId);
        Task DeleteCategory(Guid categoryId);
        Task UpdateCategory(CategoryModel category);
    }
}