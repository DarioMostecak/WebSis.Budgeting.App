﻿using Budgeting.App.Api.Models.Categories;

namespace Budgeting.App.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Category> InsertCategoryAsync(Category category);
        IQueryable<Category> SelectAllCategories();
        ValueTask<Category> SelectCategoriesByIdAsync(Guid categoryId);
        ValueTask<Category> UpdateCategoryAsync(Category category);
        ValueTask<Category> DeleteCategoryAsync(Category category);
    }
}
