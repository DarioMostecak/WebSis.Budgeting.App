﻿namespace Budgeting.App.Api.Models.Categories.Exceptions
{
    public class CategoryDependencyException : Exception
    {
        public CategoryDependencyException(Exception innerException) :
            base(message: "Service dependency error occurred, contact support.", innerException)
        { }
    }
}
