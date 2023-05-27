﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace todoAPI.models
{
    public class ToDoItem
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
