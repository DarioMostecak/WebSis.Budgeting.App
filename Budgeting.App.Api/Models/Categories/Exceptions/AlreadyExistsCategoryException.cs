﻿namespace Budgeting.App.Api.Models.Categories.Exceptions
{
    public class AlreadyExistsCategoryException : Exception
    {
        public AlreadyExistsCategoryException(Exception innerException)
            : base(message: "Category with same id already exists.", innerException) { }
    }
}
