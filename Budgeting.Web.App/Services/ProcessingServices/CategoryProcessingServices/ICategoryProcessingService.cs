﻿using Budgeting.Web.App.Contracts;
using Budgeting.Web.App.OperationResults;

namespace Budgeting.Web.App.Services.ProcessingServices.CategoryProcessingServices
{
    public interface ICategoryProcessingService
    {
        ValueTask<OperationResult<List<CategoryViewModel>>> GetAllCategoriesAsync();
        ValueTask<OperationResult<CategoryViewModel>> CreateCategoryAsync(CategoryViewModel categoryViewModel);
        ValueTask<OperationResult<CategoryViewModel>> UpdateCategoryAsync(CategoryViewModel categoryViewModel);
        ValueTask<OperationResult<CategoryViewModel>> DeleteCategoryAsync(Guid id);
        ValueTask<OperationResult<CategoryViewModel>> GetCategoryById(string id);
    }
}
