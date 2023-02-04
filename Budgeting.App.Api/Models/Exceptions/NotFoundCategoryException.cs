﻿namespace Budgeting.App.Api.Models.Exceptions
{
    public class NotFoundCategoryException : Exception
    {
        public NotFoundCategoryException(Guid categoryId)
            : base(message: string.Format($"Couldn't find assignment with id: {categoryId}.")) { }

    }
}
