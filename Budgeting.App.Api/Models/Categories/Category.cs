﻿// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2023 Dario Mostecak. All rights reserved.
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Budgeting.App.Api.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Budgeting.App.Api.Models.Categories
{
    [BsonCollection("categories")]
    public sealed class Category
    {
        [BsonId]
        [BsonElement("_categoryId")]
        [BsonRepresentation(BsonType.String)]
        public Guid CategoryId { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("icon")]
        public string Icon { get; set; }

        [BsonElement("time_created")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime TimeCreated { get; set; }

        [BsonElement("time_modify")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime TimeModify { get; set; }

    }
}
