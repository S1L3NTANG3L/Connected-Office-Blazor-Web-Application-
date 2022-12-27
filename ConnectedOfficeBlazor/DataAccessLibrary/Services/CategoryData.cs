using DataAccessLibrary.Data;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Services
{
    public class CategoryData : ICategoryData
    {
        //Data access code
		private readonly ISqlDataAccess _db;
        public CategoryData(ISqlDataAccess db)
        {
            _db = db;

        }
        //Get all category instances
		public Task<List<CategoryModel>> GetCategories()
		{
			string sql = "SELECT * FROM dbo.Category;";
			return _db.LoadData<CategoryModel, dynamic>(sql, new { });
		}
        //Get single category instance
        public Task<CategoryModel> GetCategoryById(Guid categoryId)
        {
            var parameters = new { CategoryId = categoryId };
            string sql = "SELECT * FROM dbo.Category where CategoryID = @CategoryId;";
            return _db.LoadSingle<CategoryModel, dynamic>(sql, parameters);
        }
        //Create a new category
        public Task InsertCategory(CategoryModel category)
		{
			string sql = @"INSERT INTO dbo.Category (CategoryID, 
                            CategoryName, CategoryDescription, DateCreated) 
							values (@CategoryID, 
                            @CategoryName, @CategoryDescription, @DateCreated);";
			return _db.SaveData(sql, category);
		}
        //Delete a category
        public Task DeleteCategory(Guid categoryId)
        {
            var parameters = new { CategoryId = categoryId };
            string sql = "DELETE FROM dbo.Category WHERE CategoryID = @CategoryId;";
            return _db.Delete(sql, parameters);
        }
        //Update a category
        public Task UpdateCategory(CategoryModel category)
        {
            string sql = @"UPDATE dbo.Category SET CategoryName = @CategoryName,
                           CategoryDescription = @CategoryDescription, DateCreated = @DateCreated
                           WHERE CategoryID = @CategoryID;";
            return _db.SaveData(sql, category);
        }
    }
}
